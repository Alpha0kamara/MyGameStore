using Microsoft.EntityFrameworkCore;
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
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // seed stores
            modelBuilder.Entity<Store>().HasData(
                new Store { Id = 1, Name = "GameStore", Street = "GameStreet", Number = "1", Zipcode = "1234AB", City = "GameCity", IsFranchiseStore = false },
                new Store { Id = 2, Name = "GymeStore", Street = "GymeStreet", Number = "2", Zipcode = "1234AB", City = "GymeCity", IsFranchiseStore = true }
            );

            // seed persons
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = 1, // Assuming 1 is for Male
                    Email = "john.doe@example.com",
                    StoreId = 1
                },
            new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Gender = 2, // Assuming 2 is for Female
                Email = "jane.smith@example.com",
                StoreId = 1
            },
            new Person
            {
                Id = 3,
                FirstName = "Mike",
                LastName = "Johnson",
                Gender = 1,
                Email = "mike.johnson@example.com",
                StoreId = 2
            },
            new Person
            {
                Id = 4,
                FirstName = "Emily",
                LastName = "Brown",
                Gender = 2,
                Email = "emily.brown@example.com",
                StoreId = 2
            });
        }

    }
}
