//usaremos o framework Entity, que nos ajuda a acessar dados de um database
namespace Empresas_CRUD.Server.Data
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex> options) : base(options) { }

        //alimentamos o banco de dados com algumas informações já na criação dele
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segmentos>().HasData(
                new Segmentos { Id = 1, Nome = "Indústria"},
                new Segmentos { Id = 2, Nome = "Tecnologia" }
                );

            modelBuilder.Entity<Empresas>().HasData(
                 new Empresas
                 {
                    Id = 1,
                    Nome = "ACME",
                    Site = "https://acme.com",
                    SegmentoId = 1,
                 },
                new Empresas
                {
                    Id = 2,
                    Nome = "Google",
                    Site = "https://google.com",
                    SegmentoId = 2,
                }
             );
        }

        public DbSet<Empresas> Empresas { get; set; }

        public DbSet<Segmentos> Segmentos { get; set; }
    }
}
