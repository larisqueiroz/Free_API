using AutoMapper;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using Free_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Free_API.Controllers
{
    [ApiController]
    [Route("allergens")]
    public class AllergenController : ControllerBase
    {

        /*private List<Allergen> allergens = new List<Allergen>()
        {
            new Allergen()
            {
                Id = 1,
                dishes = new List<Dish>(){
                    new Dish()
                    {
                        Id=1,
                        Name = "Croissant",
                        description = "delicious",
                        price = 5
                    } },
                Name = "Gluten"
            },
            new Allergen()
            {
                Id = 2,
                dishes = new List<Dish>(){
                    new Dish()
                    {
                        Id=2,
                        Name = "Milk Shake",
                        description = "wow",
                        price = 7
                    } },
                Name = "Lactose"
            }
        };*/
        public readonly IMapper _mapper;
        public readonly IAllergenService _allergenService;

        public AllergenController(IMapper mapper, IAllergenService allergenService)
        {
            _mapper = mapper;
            _allergenService = allergenService;
        }
    
        [HttpGet]
        public ActionResult<List<Allergen>> GetAll()
        {
            return Ok(_allergenService.getAllAllergens());
        }

        [HttpGet("{id}")]
        public ActionResult<Allergen> GetbyId([FromRoute] int id)
        {
            var allergen = _allergenService.getAllergenById(id);
            if (allergen == null)
            {
                return BadRequest("Allergen not found.");

            }
            return Ok(allergen);
        }

        [HttpPost]
        public ActionResult<Allergen> Post([FromBody] AllergenDto allergen)
        {
            var savedAllergen = _allergenService.SaveAllergen(allergen);
            return Ok(savedAllergen);
        }

        [HttpPut]
        public ActionResult<Allergen> Put(AllergenDto allergen, [FromQuery] int id)
        {
            return Ok(_allergenService.UpdateAllergen(allergen, id));
        }

        [HttpDelete("{id}")]
        public ActionResult<Allergen> Delete([FromRoute] int id)
        {
            var deleted = _allergenService.DeleteAllergen(id);

            return Ok(deleted);
        }
    }
}
