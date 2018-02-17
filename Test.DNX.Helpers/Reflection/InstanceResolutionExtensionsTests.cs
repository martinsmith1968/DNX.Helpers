using System;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Reflection;
using NUnit.Framework;
using Shouldly;

// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeTypeMemberModifiers

namespace Test.DNX.Helpers.Reflection
{
    internal class MyTagAttribute : Attribute
    {
        public string Letter { get; private set; }
        public MyTagAttribute(string letter)
        {
            Letter = letter;
        }
    }

    internal interface IType { }
    [MyTag("A")]
    internal interface ITypeA : IType { }
    [MyTag("B")]
    internal interface ITypeB : IType { }
    [MyTag("C")]
    internal interface ITypeC : ITypeB { }
    [MyTag("D")]
    internal interface ITypeD : ITypeC, ITypeA { }

    internal class CTypeA : ITypeA { }
    internal class CTypeB : ITypeB { }
    [MyTag("CC")]
    internal class CTypeC : ITypeC { }
    [MyTag("CD")]
    internal class CTypeD : ITypeD { }
    internal class CTypeAB : ITypeA, ITypeB { }
    internal class CTypeAC : ITypeA, ITypeC { }
    internal class CTypeCA : CTypeC, ITypeA { }

    [TestFixture]
    public class InstanceResolutionExtensionsTests
    {
        [Test]
        public void ResolveInstancesOfTypeWithAttributeAndCondition_CC_inherit_default()
        {
            // Arrange
            var instances = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<IType>();

            // Act
            var result = instances.ResolveInstancesOfTypeWithAttributeAndCondition<IType, MyTagAttribute>(a => a.Letter == "CC");

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result.Count(x => x.GetType() == typeof(CTypeC)).ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeCA)).ShouldBe(1);
        }

        [Test]
        public void ResolveInstancesOfTypeWithAttributeAndCondition_CC_not_inherited()
        {
            // Arrange
            var instances = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<IType>();

            // Act
            var result = instances.ResolveInstancesOfTypeWithAttributeAndCondition<IType, MyTagAttribute>(a => a.Letter == "CC", false);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeC)).ShouldBe(1);
        }

        [Test]
        public void ResolveInstancesOfTypeWithAttributeAndCondition_CC_inherited()
        {
            // Arrange
            var instances = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<IType>();

            // Act
            var result = instances.ResolveInstancesOfTypeWithAttributeAndCondition<IType, MyTagAttribute>(a => a.Letter == "CC", true);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result.Count(x => x.GetType() == typeof(CTypeC)).ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeCA)).ShouldBe(1);
        }

        [Test]
        public void ResolveInstancesOfTypeWithAttributeAndCondition_D_inherited()
        {
            // Arrange
            var instances = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<IType>();

            // Act
            var result = instances.ResolveInstancesOfTypeWithAttributeAndCondition<IType, MyTagAttribute>(a => a.Letter == "D", true);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeD)).ShouldBe(1);
        }

        [Test]
        public void ResolveInstancesOfTypeWithAttributeAndCondition_D_not_inherited()
        {
            // Arrange
            var instances = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<IType>();

            // Act
            var result = instances.ResolveInstancesOfTypeWithAttributeAndCondition<IType, MyTagAttribute>(a => a.Letter == "D", false);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void ResolveInstancesOfTypeWithAttributeAndCondition_C_inherited()
        {
            // Arrange
            var instances = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<IType>();

            // Act
            var result = instances.ResolveInstancesOfTypeWithAttributeAndCondition<IType, MyTagAttribute>(a => a.Letter == "C", true);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(4);
            result.Count(x => x.GetType() == typeof(CTypeD)).ShouldBe(1);

            result.Count(x => x.GetType() == typeof(CTypeC)).ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeD)).ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeAC)).ShouldBe(1);
            result.Count(x => x.GetType() == typeof(CTypeCA)).ShouldBe(1);
        }
    }
}
