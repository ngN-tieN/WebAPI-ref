using ContosoPizza.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public class ContosoPizzaContext : IdentityDbContext<User>
{
    public ContosoPizzaContext(DbContextOptions<ContosoPizzaContext> options)
        : base(options)
    {

    }

    public DbSet<Pizza> Pizzas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().HasMany(e => e.Pizzas)
                              .WithOne(e => e.User)
                              .HasForeignKey(pizza => pizza.UserId)
                              .IsRequired(false);
    }
}
