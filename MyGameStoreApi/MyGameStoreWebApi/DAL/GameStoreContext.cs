using Microsoft.EntityFrameworkCore;
using MyGameStoreWebApi.Model;

namespace MyGameStoreWebApi.DAL
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> dbContextOptions): base(dbContextOptions) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Store)
                .WithMany(s => s.Persons)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
