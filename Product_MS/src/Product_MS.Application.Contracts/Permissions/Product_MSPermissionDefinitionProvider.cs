using Product_MS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Product_MS.Permissions;

public class Product_MSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {

        //Define your own permissions here. Example:
        //myGroup.AddPermission(Product_MSPermissions.MyPermission1, L("Permission:MyPermission1"));
        var Product_MSGroup = context.AddGroup(Product_MSPermissions.GroupName, L("Permission:Product_MS"));

        var ProductsPermission = Product_MSGroup.AddPermission(Product_MSPermissions.Products.Default, L("Permission:Products"));
        ProductsPermission.AddChild(Product_MSPermissions.Products.Create, L("Permission:Products.Create"));
        ProductsPermission.AddChild(Product_MSPermissions.Products.Edit, L("Permission:Products.Edit"));
        ProductsPermission.AddChild(Product_MSPermissions.Products.Delete, L("Permission:Products.Delete"));
        
        var categoriesPermission = Product_MSGroup.AddPermission(
    Product_MSPermissions.Categories.Default, L("Permission:Categories"));
        categoriesPermission.AddChild(
            Product_MSPermissions.Categories.Create, L("Permission:Categories.Create"));
        categoriesPermission.AddChild(
            Product_MSPermissions.Categories.Edit, L("Permission:Categories.Edit"));
        categoriesPermission.AddChild(
            Product_MSPermissions.Categories.Delete, L("Permission:Categories.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Product_MSResource>(name);
    }
}
