using Product_MS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Product_MS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Product_MSEntityFrameworkCoreModule),
    typeof(Product_MSApplicationContractsModule)
    )]
public class Product_MSDbMigratorModule : AbpModule
{
}
