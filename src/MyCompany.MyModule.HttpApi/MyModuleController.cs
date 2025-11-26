using MyCompany.MyModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyCompany.MyModule;

public abstract class MyModuleController : AbpControllerBase
{
    protected MyModuleController()
    {
        LocalizationResource = typeof(MyModuleResource);
    }
}
