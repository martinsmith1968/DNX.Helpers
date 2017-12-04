using DNX.Helpers.Objects;
using NUnit.Framework;

namespace Test.DNX.Helpers.Objects
{
    internal class MyHashCodeClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [TestFixture]
    public class ObjectExtensionsTests
    {
        [TestCase(1, "Bob", 2, "Dave", ExpectedResult = false)]
        [TestCase(1, "Bob", 1, "Bob", ExpectedResult = false)]
        [TestCase(1, "Bob", null, null, ExpectedResult = true)]
        public bool GetUniqueInstanceId_can_generate_Ids_based_on_reference_instance(int id1, string name1, int? id2, string name2)
        {
            var instance1 = new MyHashCodeClass() { Id = id1, Name = name1 };
            var instance2 = id2.HasValue
                ? new MyHashCodeClass() { Id = id2.Value, Name = name2 }
                : instance1;

            var uniqueId1 = instance1.GetUniqueInstanceId();
            var uniqueId2 = instance2.GetUniqueInstanceId();

            return uniqueId1 == uniqueId2;
        }

        [TestCase(1, "Bob", 2, "Dave", ExpectedResult = false)]
        [TestCase(1, "Bob", 2, "Bob", ExpectedResult = false)]
        [TestCase(1, "Bob", 1, "Dave", ExpectedResult = false)]
        [TestCase(1, "Bob", 1, "Bob", ExpectedResult = true)]
        [TestCase(2, "Dave", 2, "Dave", ExpectedResult = true)]
        [TestCase(1, "Bob", null, null, ExpectedResult = true)]
        public bool GetUniqueInstanceId_can_generate_Ids_with_name_override(int id1, string name1, int? id2, string name2)
        {
            var instance1 = new MyHashCodeClass() { Id = id1, Name = name1 };
            var instance2 = id2.HasValue
                ? new MyHashCodeClass() { Id = id2.Value, Name = name2 }
                : instance1;

            var uniqueId1 = instance1.GetUniqueInstanceId(string.Format("{0}.{1}", instance1.Id, instance1.Name));
            var uniqueId2 = instance2.GetUniqueInstanceId(string.Format("{0}.{1}", instance2.Id, instance2.Name));

            return uniqueId1 == uniqueId2;
        }
    }
}
