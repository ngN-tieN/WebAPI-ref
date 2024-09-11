using Microsoft.AspNetCore.Identity;

namespace ContosoPizza.Models
{
    public class User : IdentityUser
    {
        public ICollection<Pizza> Pizzas { get; set; }
    }
}
