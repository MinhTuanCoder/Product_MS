using System.Threading.Tasks;

namespace Product_MS.Data;

public interface IProduct_MSDbSchemaMigrator
{
    Task MigrateAsync();
}
