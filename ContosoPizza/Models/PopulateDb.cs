
namespace ContosoPizza.Models
{
    public class PopulateDb
    {
        public static void Populate()
        {
            //Creates db if not exists
            var context = new PizzaContext();
            context.Database.EnsureCreated();
            var Pizzas = new List<Pizza>
                {
                    new Pizza {  Name = "Classic Italian", IsGlutenFree = false },
                    new Pizza { Name = "Veggie", IsGlutenFree = true }
                };
            //Add entity to context
            foreach (var pizza in Pizzas) context.Pizzas.Add(pizza);

            //Save data to database 
            context.SaveChanges();
        }

    }
}
