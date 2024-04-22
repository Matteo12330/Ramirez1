using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ramirez1.Models;

namespace Ramirez1.Data
{
    public class Ramirez1Context : DbContext
    {
        public Ramirez1Context (DbContextOptions<Ramirez1Context> options)
            : base(options)
        {
        }

        public DbSet<Ramirez1.Models.Ramirez> Ramirez { get; set; } = default!;
    }
}
