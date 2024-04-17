using Microsoft.EntityFrameworkCore;
using Casino.Model;
namespace Casino.DAL
{
    public class CasinoDbContext : DbContext
    {
        public DbSet<Transactions> Transactions {  get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results{ get; set; }
        public DbSet<Game> Games{ get; set; }
        public DbSet<Bandit> Bandits { get; set; }
        public DbSet<Roulette> Roulettes{ get; set; }
        public DbSet<BlackJack> BlackJacks{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Game).Assembly);
        }
    }
}