using System.Xml.Linq;

namespace Tienda.Application.Tests;

public class ArchitectureTests
{
    [Fact]
    public void Application_depends_only_on_domain()
    {
        var project = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "Architecture", "Tienda.Application.csproj"));
        var references = project.Descendants("ProjectReference")
            .Select(reference => Path.GetFileName((string?)reference.Attribute("Include")))
            .ToArray();

        Assert.Equal(["Tienda.Domain.csproj"], references);
        Assert.Empty(project.Descendants("PackageReference"));
        Assert.Empty(project.Descendants("FrameworkReference"));
    }
}
