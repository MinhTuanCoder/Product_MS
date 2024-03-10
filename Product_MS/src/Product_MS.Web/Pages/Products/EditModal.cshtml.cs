using System;
using System.Threading.Tasks;
using Product_MS.Products;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.Linq;

namespace Product_MS.Web.Pages.Products;

public class EditModalModel : Product_MSPageModel
{
    /*
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateProductDto Product { get; set; }

    private readonly IProductAppService _ProductAppService;
        
    public EditModalModel(IProductAppService ProductAppService)
    {
        _ProductAppService = ProductAppService;
    }

    public async Task OnGetAsync()
    {
        var ProductDto = await _ProductAppService.GetAsync(Id);
        Product = ObjectMapper.Map<ProductDto, CreateUpdateProductDto>(ProductDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _ProductAppService.UpdateAsync(Id, Product);
        return NoContent();
    }*/
    [BindProperty]
    public EditProductViewModel Product { get; set; }

    public List<SelectListItem> Categories { get; set; }

    private readonly IProductAppService _productAppService;

    public EditModalModel(IProductAppService ProductAppService)
    {
        _productAppService = ProductAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var ProductDto = await _productAppService.GetAsync(id);
        Product = ObjectMapper.Map<ProductDto, EditProductViewModel>(ProductDto);

        var authorLookup = await _productAppService.GetCategoryLookupAsync();
        Categories = authorLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _productAppService.UpdateAsync(
            Product.Id,
            ObjectMapper.Map<EditProductViewModel, CreateUpdateProductDto>(Product)
        );

        return NoContent();
    }

    public class EditProductViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [SelectItems(nameof(Categories))]
        [DisplayName("Categories")]
        public Guid CategoryId { get; set; }

        [Required]//validate
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [Required]//validate
        [StringLength(256)]
        public string Description { get; set; } = string.Empty;
        [Required]//validate


        [Range(0.01f, float.MaxValue, ErrorMessage = "Price must be a positive value")]
        public float Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Inventory must be a non-negative integer")]
        public int Inventory { get; set; } = 0;


    }
    
}
