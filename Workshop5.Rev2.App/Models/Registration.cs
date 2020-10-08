//coded by: David Hahner

using Microsoft.EntityFrameworkCore;

namespace Workshop5.Rev2.App.Models
{
    public class Registration : DbContext
    {
        public Registration(DbContextOptions<Registration> options) : base(options)
        {
        }
        public DbSet<RegistrationViewModel> Customers { get; set; }
    }
}
