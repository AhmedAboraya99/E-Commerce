﻿using E_Commerce.DTOs;
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
        [HttpPost("Add")]
        public IActionResult AddCategory(CategoryToAddOnlyDTO categoryDto)
        {
            try
            {
                var categoryRes = _repo.Add(categoryDto);

                if (categoryRes == null)
                {
                    return NotFound();
                }
                return Created(nameof(GetCategoryById), new { id = categoryRes });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        [HttpPost("AddWithRelatedData")]
        public IActionResult AddCategoryData(CategoryToAddRelatedDTO categoryDto)
        {
            try
            {
                var categoryRes = _repo.AddWithRelatedData(categoryDto);

                if (categoryRes == null)
                {
                    return NotFound();
                }
                return Created(nameof(GetCategoryById), new { id = categoryRes });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
        public IActionResult UpdateCategory(int id, CategoryToAddOnlyDTO categoryDto)
        {
            try
            {
                var IsUpdated = _repo.Update(id, categoryDto);

                if (IsUpdated == false)
                {
                    return NotFound();
                }

                return Accepted(IsUpdated);
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
                var IsDeleted = _repo.Delete(id);

                if (IsDeleted == false)
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



