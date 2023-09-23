using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RepairNinjaMVC.Data.Entities;
using System;
using System.Configuration; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace RepairNinjaMVC.Data
{
    public class RepairNinjaContext : DbContext
    {
        public RepairNinjaContext(DbContextOptions<RepairNinjaContext> options): base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
  
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Users> Users { get; set;}
        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<Provider_Details> Providers { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

    }

}
