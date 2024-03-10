    using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product_MS.Products;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace Product_MS.Web.Pages.Products
{
    public class CreateModalModel : Product_MSPageModel
    {
        /*
                [[BindProperty]
                public CreateUpdateProductDto Product { get; set; }
                private readonly IProductAppService _productAppService;
                public CreateModalModel(IProductAppService productAppService)
                {
                    _productAppService = productAppService;
                }
                public void OnGet()
                {
                    Product = new CreateUpdateProductDto();

                }
                public async Task<IActionResult> OnPostAsync()
                {

                    await _productAppService.CreateAsync(Product);
                    return NoContent();
                }
                */
        [BindProperty]
        public CreateProductViewModel Product { get; set; }
        public List<SelectListItem> Categories { get; set; }
        private readonly IProductAppService _productAppService;
         public CreateModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task OnGetAsync()
        {
            Product = new CreateProductViewModel();

            var categoryLookup = await _productAppService.GetCategoryLookupAsync();
            Categories = categoryLookup.Items
                .Select(x => new SelectListItem(x.Name,x.Id.ToString()))
                .ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.CreateAsync(
                ObjectMapper.Map<CreateProductViewModel, CreateUpdateProductDto>(Product)
                );
            return NoContent();
        }
        public class CreateProductViewModel
        {
            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
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
            public int Inventory { get; set; } 

        }


    }
}
