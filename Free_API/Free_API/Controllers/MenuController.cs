using Microsoft.AspNetCore.Mvc;
using System;
using Free_API.Models.DAO;

namespace Free_API.Controllers
{
    [ApiController]
    [Route("menu")]
    public class MenuController : ControllerBase
    {
        private List<Category> categories = new List<Category>()
        {
           new Category()
           {
               Id = 1,
               Name = "Salads",
               dishes = new List<Dish>()
               {
                   new Dish()
                   {
                       Id = 1,
                       price = 35,
                       Name = "Caesar Salad",
                       description = "A salad prepared with romaine lettuce, cheese, Caesar sauce and croutons.",
                       allergens = new List<Allergen>()
                       {
                           new Allergen()
                           {
                               Id = 1,
                               Name = "Gluten"
                           }
                       }
                   }
               }
           },

           new Category()
           {
               Id = 2,
               Name = "Starters",
               dishes = new List<Dish>()
               {
                   new Dish()
                   {
                       Id = 1,
                       price = 25,
                       Name = "French Fries with bacon and cheddar cheese",
                       description = "Delicious wavy french fries.",
                       allergens = { }
                   }
               }
           },
        };
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> Post([FromBody] Category category) 
        {
            categories.Add(category);
            return Ok(categories);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> Put([FromBody] Category category)
        {
            Category saved = categories.Find(id => id.Id == category.Id);
            if (saved == null)
            {
                return BadRequest("Category not found.");
            }

            if (category.Name != null)
            {
                saved.Name = category.Name;
            }
            if (category.dishes != null)
            {
                saved.dishes = category.dishes;
            }

            return Ok(saved);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> Delete(int id)
        {
            var category_saved = categories.Find(c => c.Id == id);
            if (category_saved == null)
            {
                return BadRequest("Category not found.");
            }

            categories.Remove(category_saved);

            return Ok(categories);
        }
    }
}
