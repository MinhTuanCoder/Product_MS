using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product_MS.Data;
using Volo.Abp.DependencyInjection;

namespace Product_MS.EntityFrameworkCore;

public class EntityFrameworkCoreProduct_MSDbSchemaMigrator
    : IProduct_MSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProduct_MSDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Product_MSDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Product_MSDbContext>()
            .Database
            .MigrateAsync();
    }
}
