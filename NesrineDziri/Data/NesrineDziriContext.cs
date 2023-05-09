using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NesrineDziri.Models;

namespace NesrineDziri.Data
{
    public class NesrineDziriContext : DbContext
    {
        public NesrineDziriContext(DbContextOptions<NesrineDziriContext> options)
            : base(options)
        {
        }

        public DbSet<MakeUp> MakeUp { get; set; }

        public DbSet<NesrineDziri.Models.Perfumery_Store>? Perfumery_Store { get; set; }
    }
}
