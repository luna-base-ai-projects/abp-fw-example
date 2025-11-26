using Volo.Abp.Modularity;

namespace MyCompany.MyModule;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class MyModuleDomainTestBase<TStartupModule> : MyModuleTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
