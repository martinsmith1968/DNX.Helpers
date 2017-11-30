using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using DNX.Helpers.Threading;
using DNX.Helpers.Threading.Mutexes;
using NUnit.Framework;
using Should;
using Mutex = DNX.Helpers.Threading.Mutexes.Mutex;

namespace Test.DNX.Helpers.Threading.Mutexes
{
    [TestFixture]
    public class MutexManagerTests
    {
        [Test]
        public void Can_create_a_named_Mutex()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();

            // Act
            var result = MutexManager.Acquire(name);

            // Assert
            result.ShouldNotBeNull();
            result.Name.ShouldEqual(name);

            result.Dispose();
        }

        [Test]
        public void Creating_a_mutex_acquires_lock()
        {
            // Arrange
            var mutexName = "myname";

            // Act
            using (var mutex = new Mutex(mutexName))
            {
                // Assert
                mutex.Name.ShouldEqual(mutexName);
                MutexManager.Mutexes.ContainsKey(mutexName).ShouldBeTrue();
                MutexManager.Mutexes[mutexName].State.ShouldEqual(MutexState.Acquired);
                MutexManager.Mutexes[mutexName].Timestamp.ShouldBeGreaterThan(DateTime.MinValue);
                MutexManager.Mutexes[mutexName].ThreadId.ShouldEqual(Thread.CurrentThread.ManagedThreadId);
            }

            // Assert
            MutexManager.Mutexes.ContainsKey(mutexName).ShouldBeFalse();
        }

        [Test]
        public void Creating_a_mutex_via_MutexManager_acquires_lock()
        {
            // Arrange
            var mutexName = "myname";

            // Act
            using (var mutex = MutexManager.Acquire(mutexName))
            {
                // Assert
                mutex.Name.ShouldEqual(mutexName);
                MutexManager.Mutexes.ContainsKey(mutexName).ShouldBeTrue();
                MutexManager.Mutexes[mutexName].State.ShouldEqual(MutexState.Acquired);
                MutexManager.Mutexes[mutexName].Timestamp.ShouldBeGreaterThan(DateTime.MinValue);
                MutexManager.Mutexes[mutexName].ThreadId.ShouldEqual(Thread.CurrentThread.ManagedThreadId);
            }

            // Assert
            MutexManager.Mutexes.ContainsKey(mutexName).ShouldBeFalse();
        }

        [Test]
        public void Creating_a_mutex_via_MutexManager_with_nowait_returns_null_if_not_available()
        {
            // Arrange
            var mutexName = "myname";

            // Act
            var mutex1 = MutexManager.AcquireNoWait(mutexName);
            var mutex2 = MutexManager.AcquireNoWait(mutexName);

            // Assert
            mutex1.ShouldNotBeNull();
            mutex2.ShouldBeNull();

            MutexManager.Mutexes.ContainsKey(mutexName).ShouldBeTrue();

            mutex1.Dispose();

            MutexManager.Mutexes.ContainsKey(mutexName).ShouldBeFalse();
        }

        [Test]
        public void CanAcquire_can_always_acquire_something_not_yet_acquired()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();

            // Act
            var result = MutexManager.CanAcquire(name);

            // Assert
            result.ShouldBeTrue();
        }

        [Test]
        public void CanAcquire_returns_false_for_a_lock_already_acquired()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();

            // Act
            using (var result = MutexManager.Acquire(name))
            {
                MutexManager.CanAcquire(name).ShouldBeFalse();
            }

            // Assert
            MutexManager.Mutexes.Count.ShouldEqual(0);
        }

        [Test]
        public void Competing_threads_block_on_same_mutex()
        {
            // Arrange
            var starts = new ConcurrentDictionary<string, DateTime>();
            var stops = new ConcurrentDictionary<string, DateTime>();

            var mutexCreate = new Action<string, string, int>((id, mutexName, timeoutSeconds) =>
            {
                var ok = false;
                using (var mutex = new Mutex(mutexName))
                {
                    starts.GetOrAdd(id, DateTime.UtcNow);
                    Console.WriteLine("{0} started at {1}", id, starts[id]);

                    Thread.Sleep(TimeSpan.FromSeconds(timeoutSeconds));

                    stops.GetOrAdd(id, DateTime.UtcNow);
                    Console.WriteLine("{0} stopped at {1}", id, stops[id]);

                    ok = true;
                }

                ok.ShouldBeTrue();
            });

            var threadStart1 = new ThreadStart(() => mutexCreate("1", "Bob", 3));
            var threadStart2 = new ThreadStart(() => mutexCreate("2", "Bob", 2));
            var threadStart3 = new ThreadStart(() => mutexCreate("3", "Bob", 1));
            var threadStart4 = new ThreadStart(() => mutexCreate("4", "Jim", 2));

            // Act
            var thread1 = ThreadHelper.Start(threadStart1);
            var thread2 = ThreadHelper.Start(threadStart2);
            var thread3 = ThreadHelper.Start(threadStart3);
            var thread4 = ThreadHelper.Start(threadStart4);

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            // Assert
            starts.Count.ShouldEqual(4);
            stops.Count.ShouldEqual(4);

            var keys = starts
                .Where(s => s.Key != "4")   // Bob only
                .OrderBy(s => s.Value)
                .Select(s => s.Key);

            var lastStop = DateTime.MinValue;
            foreach (var key in keys)
            {
                var start = starts[key];
                var stop = stops[key];

                start.ShouldBeGreaterThanOrEqualTo(lastStop);
                stop.ShouldBeGreaterThan(start);

                lastStop = stop;
            }
        }
    }
}
