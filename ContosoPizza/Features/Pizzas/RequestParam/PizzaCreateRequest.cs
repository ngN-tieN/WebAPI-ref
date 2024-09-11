namespace ContosoPizza.Features.Pizzas.RequestParam
{
    public class PizzaCreateRequest
    {

        public required string Name { get; set; }
        public bool IsGlutenFree { get; set; } = false;
    }
}
