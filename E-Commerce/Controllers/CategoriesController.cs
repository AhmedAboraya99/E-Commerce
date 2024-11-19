using E_Commerce.DTOs;
using E_Commerce.Repository.CategoryRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _repo;

        public CategoriesController(ICategoryRepo Repo)
        {
            _repo = Repo;

        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDTO categoryDto)
        {
            try
            {
                var CaegoryRes = _repo.Add(categoryDto);

                if (CaegoryRes == null)
                {
                    return NotFound();
                }
              
            }
            catch (Exception ex) {
   
                return BadRequest(ex.Message);
            }

            return Created();
            

        }
    }
}
