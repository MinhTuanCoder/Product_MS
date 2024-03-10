using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Product_MS.Categories;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Product_MS.Web.Pages.Categories;

public class CreateModalModel : Product_MSPageModel
{
    [BindProperty]
    public CreateCategoryViewModel Category { get; set; }

    private readonly ICategoryAppService _categoryAppService;

    public CreateModalModel(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    public void OnGet()
    {
        Category = new CreateCategoryViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateCategoryViewModel, CreateCategoryDto>(Category);
        await _categoryAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateCategoryViewModel
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; } = string.Empty;
        [TextArea]
        public string? Description { get; set; }
    }
}
