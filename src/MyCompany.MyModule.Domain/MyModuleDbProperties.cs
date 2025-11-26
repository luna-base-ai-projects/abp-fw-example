namespace MyCompany.MyModule;

public static class MyModuleDbProperties
{
    public static string DbTablePrefix { get; set; } = "MyModule";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "MyModule";
}
