using Microsoft.EntityFrameworkCore;
using MyGameStoreWebApi.DAL.ModelBuilderExtension;
using MyGameStoreWebApi.Model;

namespace MyGameStoreWebApi.DAL
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            //modelBuilder.SeedData();
        }
        
    }
}
