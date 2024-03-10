using AutoMapper;
using Product_MS.Products;
using Product_MS.Categories;
namespace Product_MS.Web;

public class Product_MSWebAutoMapperProfile : Profile
{
    public Product_MSWebAutoMapperProfile()

    {

        CreateMap<ProductDto, CreateUpdateProductDto>();
        CreateMap<Pages.Categories.CreateModalModel.CreateCategoryViewModel, CreateCategoryDto>();
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CategoryDto, Pages.Categories.EditModalModel.EditCategoryViewModel>();
        CreateMap<Pages.Categories.EditModalModel.EditCategoryViewModel,UpdateCategoryDto>();


        CreateMap<Pages.Products.CreateModalModel.CreateProductViewModel, CreateUpdateProductDto>();
        CreateMap<ProductDto, Pages.Products.EditModalModel.EditProductViewModel>();
        CreateMap<Pages.Products.EditModalModel.EditProductViewModel, CreateUpdateProductDto>();

    }
}
