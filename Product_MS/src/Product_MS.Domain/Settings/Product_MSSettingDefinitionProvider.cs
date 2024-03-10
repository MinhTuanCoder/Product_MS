using Volo.Abp.Settings;

namespace Product_MS.Settings;

public class Product_MSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(Product_MSSettings.MySetting1));
    }
}
