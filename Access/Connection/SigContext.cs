using Npgsql;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Access.Connection
{
    public class SigContext : DbContext
    {
        public DbSet<Frete> Fretes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        public SigContext() : base("PgSIG")
        {
           
        }
        
        public SigContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Frete>().ToTable("frete", "public");
            //modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
        }
    }
}
