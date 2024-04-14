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
            optionsBuilder.UseSqlServer(" "); // connecitonstring
        }
    }
}