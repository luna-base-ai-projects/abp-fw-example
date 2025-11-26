using MyCompany.MyModule.Localization;
using Volo.Abp.Application.Services;

namespace MyCompany.MyModule;

public abstract class MyModuleAppService : ApplicationService
{
    protected MyModuleAppService()
    {
        LocalizationResource = typeof(MyModuleResource);
        ObjectMapperContext = typeof(MyModuleApplicationModule);
    }
}
