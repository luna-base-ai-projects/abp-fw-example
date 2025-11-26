using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MyCompany.MyModule.EntityFrameworkCore;

[ConnectionStringName(MyModuleDbProperties.ConnectionStringName)]
public class MyModuleDbContext : AbpDbContext<MyModuleDbContext>, IMyModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public MyModuleDbContext(DbContextOptions<MyModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureMyModule();
    }
}
