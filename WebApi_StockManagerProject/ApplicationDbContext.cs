using Microsoft.EntityFrameworkCore;
using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* caso especifico: la tabla PedidoHerramienta y PedidoMaterial son una normalizacion
             * en la base de datos. El metodo HasKey() permite definir una 
             * llave primaria compuesta con los atributos seleccionados
             */
            modelBuilder.Entity<PedidoHerramienta>()
                .HasKey(ph => new { ph.PedidoId, ph.HerramientaId });

            modelBuilder.Entity<PedidoMaterial>()
                .HasKey(ph => new { ph.PedidoId, ph.MaterialId });
        }

        /*
         Las clases incluidas en la clase ApplicationDbContext son tomadas como referencia
         para la creacion de las tablas en la base de datos
         */
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Material> Materials { get; set; }

        public DbSet<PedidoHerramienta> PedidoHerramientas { get; set; }
        public DbSet<PedidoMaterial> PedidoMateriales { get; set; }

    }
}
