using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Product_MS.Products;

public class Product:AuditedAggregateRoot<Guid>
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public float? Price { get; set; }
    public int? Inventory { get; set; }
 
}
