using Product_MS.Samples;
using Xunit;

namespace Product_MS.EntityFrameworkCore.Domains;

[Collection(Product_MSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Product_MSEntityFrameworkCoreTestModule>
{

}
