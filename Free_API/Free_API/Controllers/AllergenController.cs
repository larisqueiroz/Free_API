using AutoMapper;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using Free_API.Models.DTO.Pagination;
using Free_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Free_API.Controllers
{
    [ApiController]
    [Route("allergens")]
    public class AllergenController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IAllergenService _allergenService;

        public AllergenController(IMapper mapper, IAllergenService allergenService)
        {
            _mapper = mapper;
            _allergenService = allergenService;
        }
    
        [HttpGet]
        public ActionResult<List<AllergenDto>> GetAll([FromQuery] int page, bool order, string? keyword)
        {
            var paged = new PagedResult<AllergenDto>();
            paged.PagedSearch(page, _allergenService.getAllAllergens(), keyword,2f, order);
            return Ok(paged);
        }
        
        [HttpGet("{id}")]
        public ActionResult<AllergenDto> GetbyId([FromRoute] int id)
        {
            var allergen = _allergenService.getAllergenById(id);
            if (allergen == null)
            {
                return BadRequest("Allergen not found.");

            }
            return Ok(allergen);
        }

        [Authorize(Policy = "Operators")]
        [HttpPost]
        public ActionResult<AllergenDto> Post([FromBody] AllergenDto allergen)
        {
            var savedAllergen = _allergenService.SaveAllergen(allergen);
            return Ok(savedAllergen);
        }

        [Authorize(Policy = "Operators")]
        [HttpPut]
        public ActionResult<AllergenDto> Put(AllergenDto allergen, [FromQuery] int id)
        {
            return Ok(_allergenService.UpdateAllergen(allergen, id));
        }

        [Authorize(Policy = "Operators")]
        [HttpDelete("{id}")]
        public ActionResult<AllergenDto> Delete([FromRoute] int id)
        {
            var deleted = _allergenService.DeleteAllergen(id);

            return Ok(deleted);
        }
    }
}
