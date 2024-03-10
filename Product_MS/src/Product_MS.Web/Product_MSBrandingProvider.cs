using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Product_MS.Web;

[Dependency(ReplaceServices = true)]
public class Product_MSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Product_MS";
}
