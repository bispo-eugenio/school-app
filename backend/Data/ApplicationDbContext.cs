using Microsoft.EntityFrameworkCore;

namespace schoolApi.Data;

public class ApplicationDbContext : DbContext
{
    public static readonly string _connectionString = $"""
        Server={Environment.GetEnvironmentVariable("SERVER")};
        User ID={Environment.GetEnvironmentVariable("USERID")};
        Password={Environment.GetEnvironmentVariable("PASSWORD")};
        Database={Environment.GetEnvironmentVariable("DATABASE")}
    """;
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

}
