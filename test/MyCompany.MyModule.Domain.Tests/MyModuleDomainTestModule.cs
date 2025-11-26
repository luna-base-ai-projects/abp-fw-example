using Volo.Abp.Modularity;

namespace MyCompany.MyModule;

[DependsOn(
    typeof(MyModuleDomainModule),
    typeof(MyModuleTestBaseModule)
)]
public class MyModuleDomainTestModule : AbpModule
{

}
