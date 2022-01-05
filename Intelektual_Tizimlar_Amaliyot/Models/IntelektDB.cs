using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Models
{
    public class IntelektDB : DbContext
    {
        public IntelektDB(DbContextOptions<IntelektDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("intelekt");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Agreement> Agreements { get; set; }

        public DbSet<Atribute> Atributes { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Situation> Situations { get; set; }
    }
}
