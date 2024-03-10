using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Emailing;

namespace Product_MS.Categories;

public class Category: FullAuditedAggregateRoot<Guid>
{
    public string Name { get;private set; }
    public string? Description { get; set; }
    private Category()
    {

    }
    internal Category(Guid id, string name, string? description = null)
    {
        SetName(name);
        Description = description;
    }
    internal Category ChangeName(string name)
    {
        SetName(name);
        return this;
    }
    private void SetName(string name)
    {
        Name  = Check.NotNullOrWhiteSpace(
            name, nameof(name),
            maxLength: 64);
    }
}
