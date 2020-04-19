using System;
using System.Threading.Tasks;
using DNX.Helpers.Internal;
using NUnit.Framework;
using Shouldly;

// ReSharper disable InconsistentNaming

namespace Test.DNX.Helpers.Internal
{
    public class RunSafelyTests
    {
        public class Execute_Tests
        {
            [Test]
            public void Can_run_simple_action_that_succeeds()
            {
                // Arrange
                var guid = Guid.NewGuid();
                var value = Guid.Empty;

                // Act
                RunSafely.Execute(() => value = guid);

                // Assert
                value.ShouldBe(guid);
            }

            [Test]
            public void Can_handle_simple_action_that_fails()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var value = 0;

                // Act
                RunSafely.Execute(() => value = dividend / divisor);

                // Assert
                value.ShouldBe(0);
            }

            [Test]
            public void Can_handle_simple_action_that_fails_and_extract_exception()
            {
                // Arrange
                var value = int.MaxValue;
                var guid = Guid.NewGuid();
                var message = "";

                // Act
                RunSafely.Execute(() => throw new Exception(guid.ToString()), ex => message = ex.Message);

                // Assert
                value.ShouldBe(int.MaxValue);
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain(guid.ToString());
            }

            [Test]
            public void Can_handle_simple_func_that_fails_and_extract_exception()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var value = 0;
                var message = "";

                // Act
                RunSafely.Execute(() => value = dividend / divisor, ex => message = ex.Message);

                // Assert
                value.ShouldBe(0);
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain("divide by zero");
            }
        }

        public class ExecuteT_Tests
        {
            [Test]
            public void Can_run_simple_func_that_succeeds()
            {
                // Arrange
                var guid = Guid.NewGuid();

                // Act
                var value = RunSafely.Execute(() => guid);

                // Assert
                value.ShouldBe(guid);
            }

            [Test]
            public void Can_handle_simple_func_that_fails()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;

                // Act
                var value = RunSafely.Execute(() => dividend / divisor);

                // Assert
                value.ShouldBe(default);
            }

            [Test]
            public void Can_handle_simple_func_with_default_that_fails()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var defaultResult = 500;

                // Act
                var value = RunSafely.Execute(() => dividend / divisor, defaultResult);

                // Assert
                value.ShouldBe(defaultResult);
            }

            [Test]
            public void Can_handle_simple_func_that_fails_and_extract_exception()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var message = "";

                // Act
                var value = RunSafely.Execute(() => dividend / divisor, ex => message = ex.Message);

                // Assert
                value.ShouldBe(default(int));
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain("divide by zero");
            }

            [Test]
            public void Can_handle_simple_func_with_default_that_fails_and_extract_exception()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var defaultResult = 500;
                var message = "";

                // Act
                var value = RunSafely.Execute(() => dividend / divisor, defaultResult, ex => message = ex.Message);

                // Assert
                value.ShouldBe(defaultResult);
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain("divide by zero");
            }
        }

        public class ExecuteAsync_Tests
        {
            [Test]
            public async Task Can_run_simple_task_that_succeeds()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 20;
                var value = 0;

                var task = new Task(() => value = dividend / divisor);
                task.Start();

                // Act
                await RunSafely.ExecuteAsync(task);

                // Assert
                value.ShouldBe(dividend / divisor);
            }

            [Test]
            public async Task Can_handle_simple_action_that_fails()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var value = 0;

                var task = new Task(() => value = dividend / divisor);
                task.Start();

                // Act
                await RunSafely.ExecuteAsync(task);

                // Assert
                value.ShouldBe(0);
            }

            [Test]
            public async Task Can_handle_simple_action_that_fails_and_extract_exception()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var value = 0;
                var message = "";

                var task = new Task(() => value = dividend / divisor);
                task.Start();

                // Act
                await RunSafely.ExecuteAsync(task, ex => message = ex.Message);

                // Assert
                value.ShouldBe(0);
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain("divide by zero");
            }
        }

        public class ExecuteAsyncT_Tests
        {
            private async Task<int> DivideAsync(int dividend, int divisor)
            {
                var quotient = await Task.Run(() => dividend / divisor);

                return quotient;
            }

            [Test]
            public async Task Can_run_simple_func_that_succeeds()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 50;

                // Act
                var value = await RunSafely.ExecuteAsync(DivideAsync(dividend, divisor));

                // Assert
                value.ShouldBe(dividend / divisor);
            }

            [Test]
            public async Task Can_run_simple_func_that_fails()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var value = 0;

                // Act
                value = await RunSafely.ExecuteAsync(DivideAsync(dividend, divisor));

                // Assert
                value.ShouldBe(default);
            }

            [Test]
            public async Task Can_run_simple_func_with_default_that_fails()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var defaultResult = 500;
                var value = 0;

                // Act
                value = await RunSafely.ExecuteAsync(DivideAsync(dividend, divisor), defaultResult);

                // Assert
                value.ShouldBe(defaultResult);
            }

            [Test]
            public async Task Can_handle_simple_func_that_fails_and_extract_exception()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var value = 0;
                var message = "";

                // Act
                value = await RunSafely.ExecuteAsync(DivideAsync(dividend, divisor), ex => message = ex.Message);

                // Assert
                value.ShouldBe(default);
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain("divide by zero");
            }

            [Test]
            public async Task Can_handle_simple_func_with_default_that_fails_and_extract_exception()
            {
                // Arrange
                var dividend = 1000;
                var divisor = 0;
                var defaultResult = 500;
                var value = 0;
                var message = "";

                // Act
                value = await RunSafely.ExecuteAsync(DivideAsync(dividend, divisor), defaultResult,
                    ex => message = ex.Message);

                // Assert
                value.ShouldBe(defaultResult);
                message.ShouldNotBeNullOrEmpty();
                message.ShouldContain("divide by zero");
            }
        }
    }
}
