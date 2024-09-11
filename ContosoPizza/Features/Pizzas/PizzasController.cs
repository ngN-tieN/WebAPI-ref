
using ContosoPizza.Features.Pizzas.RequestParam;
using ContosoPizza.Models;
using ContosoPizza.Shared.Extensions;
using ContosoPizza.Shared.Extensions.PagingExtensions;
using ContosoPizza.Shared.Utils;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils;

namespace ContosoPizza.Features.Pizzas
{
    [Authorize]
    [Route("api/pizza")]
    [ApiController]

    public class PizzasController : ControllerBase
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PizzasController(IPizzaRepository pizzaRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _pizzaRepository = pizzaRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }



        // GET: api/Pizzas
        [HttpGet]
        public async Task<IActionResult> GetPizzas([FromQuery] PizzaGetRequest request)
        {
            IPaging<Pizza> result = await _pizzaRepository.GetAll()
                                                          .Where(x => x.UserId == _httpContextAccessor.HttpContext.GetUserCredential().Id)  
                                                          .PagingAsync(pageNumber: request.PageNumber,
                                                                       pageSize: request.PageSize);
            return Ok(result);
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizza(int id)
        {
            try
            {

                var result = await _pizzaRepository.FindByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPizza([FromBody] PizzaUpdateRequest request, int id)
        {
            try
            {
                var pizza = await _pizzaRepository.FindByIdAsync(id);

                request.Adapt(pizza);
                _pizzaRepository.Update(pizza);
                await _pizzaRepository.SaveChangeAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST: api/Pizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPizza([ModelBinder(BinderType=typeof(JsonModelBinder))]PizzaCreateRequest request, [FromForm] IFormFile image)
        {
            try
            {

                string imageName = StaticFileServices.RandomizeFileName(Path.GetExtension(image.FileName));
                var pizza = request.Adapt<Pizza>();
                if (await _fileService.SaveFile(image,
                                                GetEnvVar.GetEnvString("IMAGE_PATH"),
                                                imageName))
                {
                    pizza.Image = imageName;
                }
                pizza.SetCreatedEntityMetadata(_httpContextAccessor);
                pizza.UserId = pizza.CreatedBy;
                _pizzaRepository.Add(pizza);
                await _pizzaRepository.SaveChangeAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            try
            {

                var pizza = await _pizzaRepository.FindByIdAsync(id);
                _pizzaRepository.Delete(pizza);
                await _pizzaRepository.SaveChangeAsync();

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
    }
}
