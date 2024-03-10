using System.Threading.Tasks;
using Product_MS.Localization;
using Product_MS.MultiTenancy;
using Product_MS.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Product_MS.Web.Menus;

public class Product_MSMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<Product_MSResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                Product_MSMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.AddItem(
           new ApplicationMenuItem(
               "Product_MS",
               l["Menu:Products"], // Use L for localization
               icon: "fa fa-list-alt",
                url: "/Products",
                requiredPermissionName: Product_MSPermissions.Products.Default
        ));
        context.Menu.AddItem(
          new ApplicationMenuItem(
              "Product_MS",
              l["Menu:Categories"], // Use L for localization
              icon: "fa fa-book",
               url: "/Categories",
               requiredPermissionName: Product_MSPermissions.Categories.Default
       ));

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
