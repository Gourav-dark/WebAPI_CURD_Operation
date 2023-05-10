using Microsoft.EntityFrameworkCore;
using WebAPI_CURD_Operations.Models;

namespace WebAPI_CURD_Operations.Data
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions options):base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
