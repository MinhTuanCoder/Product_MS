using Volo.Abp.Modularity;

namespace Product_MS;

public abstract class Product_MSApplicationTestBase<TStartupModule> : Product_MSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
