using E_Commerce.DTOs;
using E_Commerce.Repository.UserRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UsersController(IUserRepo repo)
        {
            _repo = repo;
        }

        // Create
        [HttpPost("Add")]
        public IActionResult AddUser(UserToAddOnlyDTO userDto)
        {
            try
            {
                var userRes = _repo.Add(userDto);

                if (userRes == null)
                {
                    return NotFound();
                }

                return CreatedAtAction(nameof(GetUserById), new { id = userRes });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Create
        [HttpPost]
        public IActionResult AddUserWithRelatedData(UserToAddRelatedDTO userDto)
        {
            try
            {
                var userRes = _repo.AddWithRelatedData(userDto);

                if (userRes == null)
                {
                    return NotFound();
                }
            return Created(nameof(GetUserById),new {Id = userRes});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // Read
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repo.GetAll();

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _repo.GetById(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserToAddRelatedDTO userDto)
        {
            try
            {
                var IsExisted = _repo.Update(id, userDto);

                if (IsExisted == false)
                {
                    return NotFound();
                }

                return Accepted(IsExisted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
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
