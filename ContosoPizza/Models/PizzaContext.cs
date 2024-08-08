using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContosoPizza.Models
{
    internal class PizzaContext : DbContext
    {

        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection("ConnectionStrings")["mssql"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
