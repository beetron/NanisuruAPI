using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanisuruAPI.Collections;
using NanisuruAPI.Repository;

namespace NanisuruAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly IItemsRepository _iitemsRepository;
        public ItemsController(IItemsRepository iitemsRepository)
        {
            _iitemsRepository = iitemsRepository;
        }

        // Get Items collection
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _iitemsRepository.GetAllAsync();
            return Ok(items);
        }

        // Get by collection Id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var items = await _iitemsRepository.GetByIdAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        // Add new item
        [HttpPost]
        public async Task<IActionResult> Post(Items newItems)
        {
            await _iitemsRepository.CreateNewItemsAsync(newItems);
            return CreatedAtAction(nameof(Get), new{ id = newItems.Id}, newItems);
        }

        // Update an item
        [HttpPut]
        public async Task<IActionResult> Put(Items updateItems)
        {
            var items = await _iitemsRepository.GetByIdAsync(updateItems.Id);
            if (items == null)
            {
                return NotFound();
            }

            await _iitemsRepository.UpdateItemsAsync(updateItems);
            return NoContent();
        }

        // Delete an item
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var items = await _iitemsRepository.GetByIdAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            await _iitemsRepository.DeleteItemsAsync(id);
            return NoContent();
        }
    }
}
