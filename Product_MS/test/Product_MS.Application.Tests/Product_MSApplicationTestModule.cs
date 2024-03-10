using Volo.Abp.Modularity;

namespace Product_MS;

[DependsOn(
    typeof(Product_MSApplicationModule),
    typeof(Product_MSDomainTestModule)
)]
public class Product_MSApplicationTestModule : AbpModule
{

}
