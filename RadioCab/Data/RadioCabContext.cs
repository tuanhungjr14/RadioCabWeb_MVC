using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RadioCab.Models;

namespace RadioCab.Data
{
    public class RadioCabContext : DbContext
    {
        public RadioCabContext (DbContextOptions<RadioCabContext> options)
            : base(options)
        {
        }

        public DbSet<RadioCab.Models.Admin> Admin { get; set; } = default!;
    }
}
