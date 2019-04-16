namespace DataAccess
{
    using DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext():base("GoldJack")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataAccess.Migrations.Configuration>());
        }

        public DbSet <User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameDetails> GamesDetails { get; set; }

        public DbSet<Coin> GameCoins { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            
        }
    }
}