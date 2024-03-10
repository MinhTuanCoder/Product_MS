using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product_MS.Products;

public interface IProductAppService: ICrudAppService< //Defines CRUD methods
        ProductDto, //Used to show products
        Guid, //Primary key of the product entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductDto>
{
    Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync(); //Khai báo hàm lấy ra tên danh mục

}
