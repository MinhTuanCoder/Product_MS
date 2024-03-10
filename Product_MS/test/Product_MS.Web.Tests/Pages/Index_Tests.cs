using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Product_MS.Pages;

public class Index_Tests : Product_MSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
