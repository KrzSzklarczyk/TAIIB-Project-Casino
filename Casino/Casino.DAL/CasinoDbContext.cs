using Microsoft.EntityFrameworkCore;
using Casino.Model;
namespace Casino.DAL
{
    public class CasinoDbContext : DbContext
    {
        DbSet<Transactions> transactions {  get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Result> Results{ get; set; }
        DbSet<Game> Games{ get; set; }
        DbSet<Bandit> Bandits { get; set; }
        DbSet<Roulette> Roulettes{ get; set; }
        DbSet<BlackJack> BlackJacks{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" "); // connecitonstring
        }
    }
}