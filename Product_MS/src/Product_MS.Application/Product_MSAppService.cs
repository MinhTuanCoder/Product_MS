using System;
using System.Collections.Generic;
using System.Text;
using Product_MS.Localization;
using Volo.Abp.Application.Services;

namespace Product_MS;

/* Inherit your application services from this class.
 */
public abstract class Product_MSAppService : ApplicationService
{
    protected Product_MSAppService()
    {
        LocalizationResource = typeof(Product_MSResource);
    }
}
