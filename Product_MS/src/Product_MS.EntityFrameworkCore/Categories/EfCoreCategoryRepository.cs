using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Product_MS.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product_MS.Categories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.Product_MS.Categories;

public class EfCoreCategoryRepository
    : EfCoreRepository<Product_MSDbContext, Category, Guid>,
        ICategoryRepository
{
    public EfCoreCategoryRepository(
        IDbContextProvider<Product_MSDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Category> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(Category => Category.Name == name);
    }

    public async Task<List<Category>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                Category => Category.Name.Contains(filter)
                )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
