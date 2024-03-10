using Product_MS.Samples;
using Xunit;

namespace Product_MS.EntityFrameworkCore.Applications;

[Collection(Product_MSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<Product_MSEntityFrameworkCoreTestModule>
{

}
