using ContosoPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Services;
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController() {

        }
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => 
            PizzaService.GetPizzas(); 
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza == null) return NotFound();
            return Ok(pizza);
        }
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new {id = pizza.Id},pizza);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();
            PizzaService.Update(id, pizza);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();
            PizzaService.DeletePizza(id);
            return NoContent();
        }
    }
}
