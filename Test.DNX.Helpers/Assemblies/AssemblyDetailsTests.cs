using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Assemblies
{
    [TestFixture]
    public class AssemblyDetailsTests
    {
        [Test]
        public void AssemblyDetails_created_from_current_assembly()
        {
            // Arrange
            var targetAssembly = Assembly.GetExecutingAssembly();

            // Act
            var assemblyDetails = new AssemblyDetails();

            // Assert
            assemblyDetails.ShouldNotBeNull();
            assemblyDetails.AssemblyName.Name.ShouldBe(targetAssembly.GetName().Name);
            assemblyDetails.Name.ShouldBe(targetAssembly.GetName().Name);
            assemblyDetails.Location.ShouldBe(targetAssembly.Location);
            assemblyDetails.FileName.ShouldNotBeNull();
            assemblyDetails.FileName.ShouldNotBeEmpty();
            assemblyDetails.Title.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyTitleAttribute>().First().Title);
            assemblyDetails.Product.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyProductAttribute>().First().Product);
            assemblyDetails.Copyright.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyCopyrightAttribute>().First().Copyright);
            assemblyDetails.Company.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyCompanyAttribute>().First().Company);
            assemblyDetails.Description.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyDescriptionAttribute>().First().Description);
            assemblyDetails.Trademark.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyTrademarkAttribute>().First().Trademark);
            assemblyDetails.Configuration.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyConfigurationAttribute>().First().Configuration);
            assemblyDetails.Version.ShouldBe(targetAssembly.GetName().Version);
            assemblyDetails.FileVersion.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyFileVersionAttribute>().First().Version);
            assemblyDetails.InformationalVersion.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().First().InformationalVersion);
            assemblyDetails.SimplifiedVersion.ShouldBe(assemblyDetails.Version.Simplify());
        }

        [Test]
        public void AssemblyDetails_created_from_specific_assembly()
        {
            // Arrange
            var targetAssembly = typeof(AssemblyDetails).Assembly;

            // Act
            var assemblyDetails = new AssemblyDetails(targetAssembly);

            // Assert
            assemblyDetails.ShouldNotBeNull();
            assemblyDetails.AssemblyName.Name.ShouldBe(targetAssembly.GetName().Name);
            assemblyDetails.Name.ShouldBe(targetAssembly.GetName().Name);
            assemblyDetails.Location.ShouldBe(targetAssembly.Location);
            assemblyDetails.FileName.ShouldNotBeNull();
            assemblyDetails.FileName.ShouldNotBeEmpty();
            assemblyDetails.Title.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyTitleAttribute>().First().Title);
            assemblyDetails.Product.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyProductAttribute>().First().Product);
            assemblyDetails.Copyright.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyCopyrightAttribute>().First().Copyright);
            assemblyDetails.Company.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyCompanyAttribute>().First().Company);
            assemblyDetails.Description.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyDescriptionAttribute>().First().Description);
            assemblyDetails.Trademark.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyTrademarkAttribute>().First().Trademark);
            assemblyDetails.Configuration.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyConfigurationAttribute>().First().Configuration);
            assemblyDetails.Version.ShouldBe(targetAssembly.GetName().Version);
            assemblyDetails.FileVersion.ShouldBe(targetAssembly.GetCustomAttributes<AssemblyFileVersionAttribute>().First().Version);
            assemblyDetails.InformationalVersion.ShouldBeNull();
            assemblyDetails.SimplifiedVersion.ShouldBe(assemblyDetails.Version.Simplify());
        }
    }
}
