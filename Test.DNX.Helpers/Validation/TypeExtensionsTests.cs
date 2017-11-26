using System;
using DNX.Helpers.Validation;
using NUnit.Framework;

namespace Test.DNX.Helpers.Validation
{
    internal class MyTestClass1
    {
        public int Number { get; set; }

        public MyTestClass1()
        {
            Number = 123;
        }
    }

    internal interface I1 { }
    internal interface I1A : I1 { }
    internal interface I2 { }

    internal class C1 : I1 { }
    internal class C1A : I1A { }
    internal class C2 : I2 { }
    internal class C1AI2 : I1A, I2 { }

    [TestFixture]
    public class TypeExtensionsTests
    {
        [TestCase(typeof(object), ExpectedResult = true)]
        [TestCase(typeof(TypeExtensionsTests), ExpectedResult = true)]
        [TestCase(typeof(MyTestClass1), ExpectedResult = true)]
        [TestCase(typeof(int), ExpectedResult = false)]
        [TestCase(typeof(int?), ExpectedResult = true)]
        [TestCase(typeof(DateTime), ExpectedResult = false)]
        [TestCase(typeof(DateTime?), ExpectedResult = true)]
        public bool IsNullableTest(Type type)
        {
            return type.IsNullable();
        }

        [TestCase(typeof(I1), ExpectedResult = true)]
        [TestCase(typeof(I1A), ExpectedResult = true)]
        [TestCase(typeof(I2), ExpectedResult = false)]
        [TestCase(typeof(C1), ExpectedResult = true)]
        [TestCase(typeof(C1A), ExpectedResult = true)]
        [TestCase(typeof(C2), ExpectedResult = false)]
        [TestCase(typeof(C1AI2), ExpectedResult = true)]
        public bool IsA_I1_Test(Type type)
        {
            return type.IsA<I1>();
        }

        [TestCase(typeof(I1), typeof(I1), ExpectedResult = true)]
        [TestCase(typeof(I1A), typeof(I1), ExpectedResult = true)]
        [TestCase(typeof(I2), typeof(I1), ExpectedResult = false)]
        [TestCase(typeof(C1), typeof(I1), ExpectedResult = true)]
        [TestCase(typeof(C1A), typeof(I1), ExpectedResult = true)]
        [TestCase(typeof(C2), typeof(I1), ExpectedResult = false)]
        [TestCase(typeof(C1AI2), typeof(I1), ExpectedResult = true)]
        [TestCase(typeof(C1AI2), typeof(I2), ExpectedResult = true)]
        [TestCase(typeof(C1AI2), typeof(I1A), ExpectedResult = true)]
        public bool IsA_Test(Type type, Type baseType)
        {
            return type.IsA(baseType);
        }

        [TestCase(typeof(object), ExpectedResult = null)]
        [TestCase(typeof(TypeExtensionsTests), ExpectedResult = null)]
        [TestCase(typeof(MyTestClass1), ExpectedResult = null)]
        [TestCase(typeof(int), ExpectedResult = 0)]
        [TestCase(typeof(int?), ExpectedResult = null)]
        [TestCase(typeof(DateTime?), ExpectedResult = null)]
        public object GetDefaultValueTest(Type type)
        {
            return type.GetDefaultValue();
        }

        [Test]
        public void CreateDefaultInstanceTest_Generic()
        {
            // Arrange

            // Act
            var instance1 = TypeExtensions.CreateDefaultInstance<TypeExtensionsTests>();
            var instance2 = TypeExtensions.CreateDefaultInstance<MyTestClass1>();
            var instance3 = TypeExtensions.CreateDefaultInstance<int>();

            // Assert
            Assert.IsNotNull(instance1);

            Assert.IsNotNull(instance2);
            Assert.AreEqual(123, instance2.Number);

            Assert.AreEqual(0, instance3);
        }

        [Test]
        public void CreateDefaultInstanceTest1()
        {
            // Arrange

            // Act
            var instance1 = typeof(TypeExtensionsTests).CreateDefaultInstance() as TypeExtensionsTests;
            var instance2 = typeof(MyTestClass1).CreateDefaultInstance() as MyTestClass1;

            // Assert
            Assert.IsNotNull(instance1);

            Assert.IsNotNull(instance2);
            Assert.AreEqual(123, instance2.Number);
        }
    }
}