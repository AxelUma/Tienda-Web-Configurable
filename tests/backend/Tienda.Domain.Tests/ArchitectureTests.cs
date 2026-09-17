using System.Xml.Linq;

namespace Tienda.Domain.Tests;

public class ArchitectureTests
{
    [Fact]
    public void Domain_has_no_project_package_or_framework_dependencies()
    {
        var project = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "Architecture", "Tienda.Domain.csproj"));

        Assert.Empty(project.Descendants("ProjectReference"));
        Assert.Empty(project.Descendants("PackageReference"));
        Assert.Empty(project.Descendants("FrameworkReference"));
    }
}
