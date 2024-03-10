using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Product_MS.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Product_MS.Web.Pages.Categories;

public class EditModalModel : Product_MSPageModel
{
    [BindProperty]
    public EditCategoryViewModel Category { get; set; }
    private readonly ICategoryAppService _categoryAppService;
    public EditModalModel(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }
    public async Task OnGetAsync(Guid id)
    {
        var categoryDto = await _categoryAppService.GetAsync(id);
        Category = ObjectMapper.Map<CategoryDto, EditCategoryViewModel>(categoryDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _categoryAppService.UpdateAsync(
        Category.Id,
            ObjectMapper.Map<EditCategoryViewModel, UpdateCategoryDto>(Category)
        );

        return NoContent();
    }

    public class EditCategoryViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; } = string.Empty;


        [TextArea]
        public string? Description { get; set; }
    }


}
