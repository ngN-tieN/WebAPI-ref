using ContosoPizza.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models
{
    public class Pizza:Metadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public string? Image { get; set; }

        public string UserId {  get; set; }
        public User User { get; set; }
    }
}
