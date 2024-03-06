using BusinessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAPIController : Controller
    {
        private readonly IUserService _userService;
        private List<User> _users = SeedData.GetUser(10);

        public UserAPIController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.TGetList();
        }
        [HttpGet]
        [Route("List")]
        public List<User> Get()
        {
            return _users;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            try
            {
                _userService.TAdd(user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        // DELETE: api/UserAPI/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingUser = _userService.TGetById(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                _userService.TDelete(existingUser);

                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        // PUT: api/UserAPI/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                var existingUser = _userService.TGetById(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                // Update user properties
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.EMailAdress = user.EMailAdress;

                // Save changes
                _userService.TUpdate(existingUser);

                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
