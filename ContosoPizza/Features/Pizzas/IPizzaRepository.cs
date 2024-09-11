using ContosoPizza.Models;
using ContosoPizza.RepositoryManager;

namespace ContosoPizza.Features.Pizzas
{
    public interface IPizzaRepository:IRepository<Pizza>
    {
        Task<Pizza> FindByIdAsync(int id);
    }
}
