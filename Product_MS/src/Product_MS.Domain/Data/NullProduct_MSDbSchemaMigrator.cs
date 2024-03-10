using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Product_MS.Data;

/* This is used if database provider does't define
 * IProduct_MSDbSchemaMigrator implementation.
 */
public class NullProduct_MSDbSchemaMigrator : IProduct_MSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
