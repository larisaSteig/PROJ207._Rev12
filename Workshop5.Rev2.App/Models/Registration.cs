using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
