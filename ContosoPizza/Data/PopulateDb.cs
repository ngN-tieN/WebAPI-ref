using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public class PopulateDb
    {
        public static void Populate(ContosoPizzaContext context)
        {
            if (context.Pizzas.Any())
            {
                return;
            }
            //Creates if not exists
            var Pizzas = new List<Pizza>
                {
                    new Pizza {  Name = "Classic Italian", IsGlutenFree = false },
                    new Pizza { Name = "Veggie", IsGlutenFree = true }
                };
            //Add entity to context
            context.Pizzas.AddRange(Pizzas);
            //Save data to database 
            context.SaveChanges();
        }

    }
}
