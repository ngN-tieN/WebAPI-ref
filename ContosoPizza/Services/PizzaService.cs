using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;
namespace ContosoPizza.Services;

internal static class PizzaService
{
    static internal List<Pizza> GetPizzas()
    {
        using var db = new PizzaContext();
        var pizzas = db.Pizzas.ToList();
        return pizzas;
    }
    static internal Pizza Get(int id)
    {
        using var db = new PizzaContext();
        var pizza = db.Pizzas.FirstOrDefault(x => x.Id == id);
        return pizza; 
    }
    static internal void DeletePizza(int id)
    {
        var pizza = Get(id);
        using var db = new PizzaContext();
        db.Remove(pizza);
        db.SaveChanges();
    }
    static internal void Update(int id, Pizza newPizza)
    {
        
        using var db = new PizzaContext();
        var pizza = db.Pizzas.FirstOrDefault(x => x.Id == id);
        db.Pizzas.Attach(pizza);
        pizza.Name = newPizza.Name;
        pizza.IsGlutenFree = newPizza.IsGlutenFree;


        db.SaveChanges();
    }
    static internal void Add(Pizza newPizza)
    {
        
        using var db = new PizzaContext();
        db.Add(newPizza); 
        db.SaveChanges();
    }

}