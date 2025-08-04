using DemoApis.Models;
using DemoApis.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApis.DBContext
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { 
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
