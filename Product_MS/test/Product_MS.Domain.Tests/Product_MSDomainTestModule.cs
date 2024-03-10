using Volo.Abp.Modularity;

namespace Product_MS;

[DependsOn(
    typeof(Product_MSDomainModule),
    typeof(Product_MSTestBaseModule)
)]
public class Product_MSDomainTestModule : AbpModule
{

}
