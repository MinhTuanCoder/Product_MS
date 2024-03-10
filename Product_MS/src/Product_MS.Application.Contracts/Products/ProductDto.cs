using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Product_MS.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public float? Price { get; set; }
    public int? Inventory { get; set; }

}
 