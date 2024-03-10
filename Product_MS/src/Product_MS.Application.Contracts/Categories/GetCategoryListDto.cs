using Volo.Abp.Application.Dtos;

namespace Product_MS.Categories;

public class GetCategoryListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
