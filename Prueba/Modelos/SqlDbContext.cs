using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Prueba.Modelos
{
    public class SqlDbContext :DbContext
    {
        //private readonly IConfiguration _configure;
        //public SqlDbContext(IConfiguration configure)
        //{
        //    _configure = configure;
        //}
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}

        //public virtual DbSet<Datos> Datos { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Datos>().ToTable("Datos");

            //modelBuilder.Entity<Datos>(e =>
            //{
            //    e.HasKey(p => p.Id);
            //    e.Property(p => p.Id).UseIdentityColumn();

            //});



            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            modelBuilder.Entity<Cliente>(e =>
            {
                e.HasKey(p => p.IdCliente);
                e.Property(p => p.IdCliente).UseIdentityColumn();
                e.Property(p => p.Nombre).HasMaxLength(500).IsRequired(true);
            });
        }

    }
}
