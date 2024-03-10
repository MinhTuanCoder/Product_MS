using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Product_MS.Permissions;
using Product_MS.Categories;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Domain.Entities;
namespace Product_MS.Products;
[Authorize(Product_MSPermissions.Products.Default)]
public class ProductAppService : CrudAppService<
        Product, //The Product entity
        ProductDto, //Used to show Products
        Guid, //Primary key of the Product entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductDto>, //Used to create/update a Product
    IProductAppService //implement the IProductAppService
{ 
    private readonly ICategoryRepository _categoryRepository;
    public ProductAppService(IRepository<Product, Guid> repository,ICategoryRepository categoryRepository) : base(repository)
    {
        _categoryRepository = categoryRepository;
        GetPolicyName = Product_MSPermissions.Products.Default;
        GetListPolicyName = Product_MSPermissions.Products.Default;
        CreatePolicyName = Product_MSPermissions.Products.Create;
        UpdatePolicyName = Product_MSPermissions.Products.Edit;
        DeletePolicyName = Product_MSPermissions.Products.Delete;
    }

    public override async Task<ProductDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from product in queryable
                    join category in await _categoryRepository.GetQueryableAsync() on product.CategoryId equals category.Id
                    where product.Id == id
                    select new { product, category };

        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }

        var productDto = ObjectMapper.Map<Product, ProductDto>(queryResult.product);
        productDto.CategoryName = queryResult.category.Name;
        return productDto;

    }
    public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from product in queryable
                    join category in await _categoryRepository.GetQueryableAsync() on product.CategoryId equals category.Id
                    select new { product, category };

        //Paging
        query = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of BookDto objects
        var productDtos = queryResult.Select(x =>
        {
            var productDto = ObjectMapper.Map<Product, ProductDto>(x.product);
            productDto.CategoryName = x.category.Name;
            return productDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<ProductDto>(
            totalCount,
            productDtos
        );
    }


    public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
    {
        var categories = await _categoryRepository.GetListAsync();

        return new ListResultDto<CategoryLookupDto>(
            ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories)
        );
    }


    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"product.{nameof(Product.Name)}";
        }

        if (sorting.Contains("categoryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "categoryName",
                "category.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"product.{sorting}";
    }
}
