using Free_API.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Free_API.Controllers
{
    [ApiController]
    [Route("allergens")]
    public class AllergenController : ControllerBase
    {

        private List<Allergen> allergens = new List<Allergen>()
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
        };
        [HttpGet]
        public ActionResult<List<Allergen>> GetAll()
        {
            return allergens.ToList();
        }

        [HttpPost]
        public ActionResult<Allergen> Post([FromBody] Allergen allergen)
        {
            allergens.Add(allergen);
            return Ok(allergens.ToList());
        }
    }
}
