using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
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
            public void FindTypesThatImplementType_should_find_all_that_implement_interface()
            {
                // Act
                var result = Assembly.GetExecutingAssembly().FindTypesThatImplementType<ITypeA>();

                // Assert
                result.ShouldNotBeNull();
                result.Count.ShouldBe(6);
                result.Count(x => x == typeof(ITypeD)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeA)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeD)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeAB)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeAC)).ShouldBe(1);
                result.Count(x => x == typeof(CTypeCA)).ShouldBe(1);
            }

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
    }
}
