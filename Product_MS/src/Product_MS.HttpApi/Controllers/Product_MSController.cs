using Product_MS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Product_MS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Product_MSController : AbpControllerBase
{
    protected Product_MSController()
    {
        LocalizationResource = typeof(Product_MSResource);
    }
}
