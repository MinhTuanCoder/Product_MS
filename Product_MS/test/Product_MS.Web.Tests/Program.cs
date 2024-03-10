using Microsoft.AspNetCore.Builder;
using Product_MS;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<Product_MSWebTestModule>();

public partial class Program
{
}
