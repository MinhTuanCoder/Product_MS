using AutoMapper;
using Product_MS.Categories;
using Product_MS.Products;

namespace Product_MS;

public class Product_MSApplicationAutoMapperProfile : Profile
{
    public Product_MSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. 
        */
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryLookupDto>();
    }
}
