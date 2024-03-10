using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Product_MS.Products;

public class CategoryLookupDto:EntityDto<Guid>
{
    public string Name { get; set; }
}
