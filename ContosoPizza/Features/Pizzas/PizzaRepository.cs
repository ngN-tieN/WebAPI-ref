using ContosoPizza.Data;
using ContosoPizza.Models;
using ContosoPizza.RepositoryManager;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Features.Pizzas
{
    public class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(ContosoPizzaContext _context) : base(_context)
        {

        }
        public async Task<Pizza> FindByIdAsync(int id)
        {

                var result = await GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) throw new Exception($"Couldnt retrieve entity");
                return result;


        }

    }
}
