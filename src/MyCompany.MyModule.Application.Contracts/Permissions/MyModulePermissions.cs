using Volo.Abp.Reflection;

namespace MyCompany.MyModule.Permissions;

public class MyModulePermissions
{
    public const string GroupName = "MyModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(MyModulePermissions));
    }
}
