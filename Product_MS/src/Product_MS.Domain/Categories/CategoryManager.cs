using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Product_MS.Categories;

public class CategoryManager: DomainService
{
    private readonly ICategoryRepository _CategoryRepository;

    public CategoryManager(ICategoryRepository CategoryRepository)
    {
        _CategoryRepository = CategoryRepository;
    }

    public async Task<Category> CreateAsync(
        string name,
   
        string? description = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingCategory = await _CategoryRepository.FindByNameAsync(name);
        if (existingCategory != null)
        {
            throw new CategoryAlreadyExistsException(name);
        }

        return new Category(
            GuidGenerator.Create(),
            name,
            description
        );
    }

    public async Task ChangeNameAsync(
        Category Category,
        string newName)
    {
        Check.NotNull(Category, nameof(Category));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingCategory = await _CategoryRepository.FindByNameAsync(newName);
        if (existingCategory != null && existingCategory.Id != Category.Id)
        {
            throw new CategoryAlreadyExistsException(newName);
        }

        Category.ChangeName(newName);
    }
}
