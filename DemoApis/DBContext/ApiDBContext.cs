using DemoApis.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApis.DBContext
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { 
        }

    }
}
