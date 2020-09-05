using System;
using System.Linq;
using System.Reflection;
using System.Resources;
using DNX.Helpers.Assemblies;
using NUnit.Framework;
using Shouldly;

// ReSharper disable InconsistentNaming

namespace Test.DNX.Helpers.Assemblies
{
    internal interface ITypeA { }
    internal interface ITypeB { }
    internal interface ITypeC : ITypeB { }
    internal interface ITypeD : ITypeC, ITypeA { }

    internal class CTypeA : ITypeA { }
    internal class CTypeB : ITypeB { }
    internal class CTypeC : ITypeC { }
    internal class CTypeD : ITypeD { }
    internal class CTypeAB : ITypeA, ITypeB { }
    internal class CTypeAC : ITypeA, ITypeC { }
    internal class CTypeCA : CTypeC, ITypeA { }

    public class InstanceResolutionExtensionsTests
    {
        public class GetTypesThatImplementInterface_ITypeA
        {
            [Test]
            public void FindTypesThatImplementType_should_find_all_that_implement_interface()
            {
                // Act
                var result = Assembly.GetExecutingAssembly().FindTypesThatImplementType<ITypeA>();

                // Assert
                result.ShouldNotBeNull();
                result.Count.ShouldBe(7);
                result.Count(x => x == typeof(ITypeA)).ShouldBe(1);
                result.Count(x => x == typeof(ITypeD)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeA)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeD)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeAB)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeAC)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeCA)).ShouldBe(1);
            }

            [Test]
            public void FindConcreteTypesThatImplementType_should_find_all_that_implement_interface()
            {
                // Act
                var result = Assembly.GetExecutingAssembly().FindConcreteTypesThatImplementType<ITypeA>();

                // Assert
                result.ShouldNotBeNull();
                result.Count.ShouldBe(5);
                result.Count(x => x == typeof(CTypeA)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeD)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeAB)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeAC)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeCA)).ShouldBe(1);
            }

            [Test]
            public void CreateInstancesOfClassesThatImplementInterface_should_create_instances_for_all_that_implement_interface()
            {
                // Act
                var result = Assembly.GetExecutingAssembly().CreateInstancesOfConcreteTypesThatImplementType<ITypeA>();

                // Assert
                result.ShouldNotBeNull();
                result.Count.ShouldBe(5);
                result.Count(x => x.GetType() == typeof(CTypeA)).ShouldBe(1);
                result.Count(x => x.GetType() == typeof(CTypeD)).ShouldBe(1);
                result.Count(x => x.GetType() == typeof(CTypeAB)).ShouldBe(1);
                result.Count(x => x.GetType() == typeof(CTypeAC)).ShouldBe(1);
                result.Count(x => x.GetType() == typeof(CTypeCA)).ShouldBe(1);
            }
        }

        public class GetEmbeddedResourceTextTests
        {
            [Test]
            public void GetEmbeddedResourceText_can_read_resource_successfully()
            {
                // Arrange
                var name = "TestData.SampleData.json";

                // Act
                var result = Assembly.GetExecutingAssembly().GetEmbeddedResourceText(name);

                Console.WriteLine("Result: {0}", result);

                // Assert
                result.ShouldNotBeNull();
            }

            [Test]
            public void GetEmbeddedResourceText_throws_on_unknown_resource_name()
            {
                // Arrange
                var name = $"{Guid.NewGuid()}.json";

                // Act
                var ex = Assert.Throws<MissingManifestResourceException>(
                    () => Assembly.GetExecutingAssembly().GetEmbeddedResourceText(name)
                );

                Console.WriteLine("Exception Message: {0}", ex?.Message);

                // Assert
                ex.ShouldNotBeNull();
                ex.Message.ShouldContain(name);
            }

            [Test]
            public void GetEmbeddedResourceText_can_read_resource_with_specific_namespace_successfully()
            {
                // Arrange
                var name = "SampleData.json";
                var nameSpace = $"Test.DNX.Helpers.TestData";

                // Act
                var result = Assembly.GetExecutingAssembly().GetEmbeddedResourceText(name, nameSpace);

                Console.WriteLine("Result: {0}", result);

                // Assert
                result.ShouldNotBeNull();
            }
        }
    }
}
