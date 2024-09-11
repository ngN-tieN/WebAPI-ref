using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models.Request
{
    public class RegisterFormRequest
    {
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string Password { get; set; }    
    }
}
