using Product_MS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Product_MS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class Product_MSPageModel : AbpPageModel
{
    protected Product_MSPageModel()
    {
        LocalizationResourceType = typeof(Product_MSResource);
    }
}
