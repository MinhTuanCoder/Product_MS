using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product_MS.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Product_MS.Categories;
namespace Product_MS.Categories;

[Authorize(Product_MSPermissions.Categories.Default)]
public class CategoryAppService : Product_MSAppService, ICategoryAppService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryManager _categoryManager;

    public CategoryAppService(
        ICategoryRepository CategoryRepository,
        CategoryManager CategoryManager)
    {
        _categoryRepository = CategoryRepository;
        _categoryManager = CategoryManager;
    }

    //...SERVICE METHODS WILL COME HERE...
    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var author = await _categoryRepository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(author);
    }
    public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Category.Name);
        }

        var categories = await _categoryRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _categoryRepository.CountAsync()
            : await _categoryRepository.CountAsync(
                author => author.Name.Contains(input.Filter));

        return new PagedResultDto<CategoryDto>(
            totalCount,
            ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories)
        );
    }
    [Authorize(Product_MSPermissions.Categories.Create)]
    public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
    {
        var category = await _categoryManager.CreateAsync(
            input.Name,
            input.Description
        );

        await _categoryRepository.InsertAsync(category);

        return ObjectMapper.Map<Category, CategoryDto>(category);
    }
    [Authorize(Product_MSPermissions.Categories.Edit)]
    public async Task UpdateAsync(Guid id, UpdateCategoryDto input)
    {
        var category = await _categoryRepository.GetAsync(id);

        if (category.Name != input.Name)
        {
            await _categoryManager.ChangeNameAsync(category, input.Name);
        }

        category.Description = input.Description;
      

        await _categoryRepository.UpdateAsync(category);
    }
    [Authorize(Product_MSPermissions.Categories.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }





}
