using MyCompany.MyModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyCompany.MyModule.Permissions;

public class MyModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MyModulePermissions.GroupName, L("Permission:MyModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MyModuleResource>(name);
    }
}
