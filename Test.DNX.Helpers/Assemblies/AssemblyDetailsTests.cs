using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using NUnit.Framework;
using Should;

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
            assemblyDetails.AssemblyName.Name.ShouldEqual(targetAssembly.GetName().Name);
            assemblyDetails.Name.ShouldEqual(targetAssembly.GetName().Name);
            assemblyDetails.Location.ShouldEqual(targetAssembly.Location);
            assemblyDetails.FileName.ShouldNotBeNull();
            assemblyDetails.FileName.ShouldNotBeEmpty();
            assemblyDetails.Title.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyTitleAttribute>().First().Title);
            assemblyDetails.Product.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyProductAttribute>().First().Product);
            assemblyDetails.Copyright.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyCopyrightAttribute>().First().Copyright);
            assemblyDetails.Company.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyCompanyAttribute>().First().Company);
            assemblyDetails.Description.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyDescriptionAttribute>().First().Description);
            assemblyDetails.Trademark.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyTrademarkAttribute>().First().Trademark);
            assemblyDetails.Configuration.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyConfigurationAttribute>().First().Configuration);
            assemblyDetails.Version.ShouldEqual(targetAssembly.GetName().Version);
            assemblyDetails.FileVersion.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyFileVersionAttribute>().First().Version);
            assemblyDetails.InformationalVersion.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().First().InformationalVersion);
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
            assemblyDetails.AssemblyName.Name.ShouldEqual(targetAssembly.GetName().Name);
            assemblyDetails.Name.ShouldEqual(targetAssembly.GetName().Name);
            assemblyDetails.Location.ShouldEqual(targetAssembly.Location);
            assemblyDetails.FileName.ShouldNotBeNull();
            assemblyDetails.FileName.ShouldNotBeEmpty();
            assemblyDetails.Title.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyTitleAttribute>().First().Title);
            assemblyDetails.Product.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyProductAttribute>().First().Product);
            assemblyDetails.Copyright.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyCopyrightAttribute>().First().Copyright);
            assemblyDetails.Company.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyCompanyAttribute>().First().Company);
            assemblyDetails.Description.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyDescriptionAttribute>().First().Description);
            assemblyDetails.Trademark.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyTrademarkAttribute>().First().Trademark);
            assemblyDetails.Configuration.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyConfigurationAttribute>().First().Configuration);
            assemblyDetails.Version.ShouldEqual(targetAssembly.GetName().Version);
            assemblyDetails.FileVersion.ShouldEqual(targetAssembly.GetCustomAttributes<AssemblyFileVersionAttribute>().First().Version);
            assemblyDetails.InformationalVersion.ShouldBeNull();
        }
    }
}
