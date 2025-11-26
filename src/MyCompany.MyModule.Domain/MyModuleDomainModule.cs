using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MyCompany.MyModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(MyModuleDomainSharedModule)
)]
public class MyModuleDomainModule : AbpModule
{

}
