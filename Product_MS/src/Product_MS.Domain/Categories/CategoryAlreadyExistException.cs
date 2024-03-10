using Volo.Abp;

namespace Product_MS.Categories;

public class CategoryAlreadyExistsException : BusinessException
{
    public CategoryAlreadyExistsException(string name)
        : base(Product_MSDomainErrorCodes.CategoryAlreadyExists)
    {
        WithData("name", name);
    }
}
