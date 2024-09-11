using ContosoPizza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ContosoPizza.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class LogOutController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> LogOut(SignInManager<User> signInManager, [FromBody] object empty)
        {
            if (empty != null)
            {
                await signInManager.SignOutAsync();
                return Ok();
            }
            return Unauthorized();
        }
    }
}
