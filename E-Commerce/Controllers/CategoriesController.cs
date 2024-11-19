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

            // Create
        [HttpPost]
        public IActionResult AddCategory(CategoryDTO categoryDto)
        {
            try
            {
                var categoryRes = _repo.Add(categoryDto);

                if (categoryRes == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created();
        }

        // Read
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _repo.GetAll();

                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _repo.GetById(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryDTO categoryDto)
        {
            try
            {
                var categoryRes = _repo.Update(id, categoryDto);

                if (categoryRes == null)
                {
                    return NotFound();
                }

                return Ok(categoryRes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var categoryRes = _repo.Delete(id);

                if (categoryRes == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}



