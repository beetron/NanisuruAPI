using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanisuruAPI.Collections;
using NanisuruAPI.Repository;

namespace NanisuruAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        readonly IUsersRepository _iUsersRepository;
        public UsersController(IUsersRepository iUsersRepository)
        {
            _iUsersRepository = iUsersRepository;
        }

        // Get Users collection
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _iUsersRepository.GetUsersAsync();
            return Ok(users);
        }

        // Add new User
        [HttpPost]
        public async Task<IActionResult> Post(Users newUsers)
        {
            await _iUsersRepository.AddUsersAsync(newUsers);
            return CreatedAtAction(nameof(Get), new { id = newUsers.Id }, newUsers);
        }

        // Delete an item
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var users = await _iUsersRepository.GetByIdAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            await _iUsersRepository.DeleteUsersAsync(id);
            return NoContent();
        }

    }
}
