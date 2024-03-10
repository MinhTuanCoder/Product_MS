using Volo.Abp.Modularity;

namespace Product_MS;

/* Inherit from this class for your domain layer tests. */
public abstract class Product_MSDomainTestBase<TStartupModule> : Product_MSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
