using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanisuruAPI.Collections;
using NanisuruAPI.Repository;

namespace NanisuruAPI.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly IItemsRepository _iitemsRepository;
        public ItemsController(IItemsRepository iitemsRepository)
        {
            _iitemsRepository = iitemsRepository;
        }

        // OPTIONS response
        // [HttpOptions]
        // public IActionResult Options()
        // {
        //     Response.Headers.Add("Access-Control-Allow-Credentials", "true");
        //     Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:7095");
        //     Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS");
        //     Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-Requested-With, Accept, Authorization, Origin");
        //     return Ok(HttpStatusCode.OK);
        // }

        // Get Items collection
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _iitemsRepository.GetAllAsync();
            return Ok(items);
        }


        // OPTIONS method handler for localhost CORs testing
        [HttpOptions("Incomplete")]
        public IActionResult IncompleteOptions()
        {
            return NoContent();
        }

        // Get Incomplete items
        [HttpGet("Incomplete")]
        public async Task<IActionResult> Incomplete()
        {
            var items = await _iitemsRepository.GetIncompleteItems();
            return Ok(items);
        }

        // OPTIONS method handler for localhost CORs testing
        [HttpOptions("Complete")]
        public IActionResult CompletedOptions()
        {
            return NoContent();
        }

        // Get Complete items
        [HttpGet("Complete")]
        public async Task<IActionResult> Completed()
        {
            var items = await _iitemsRepository.GetCompletedItems();
            return Ok(items);
        }

        // Get by collection Id
        [HttpGet("{id:length(24)}")]
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

        // OPTIONS method handler for localhost CORs testing
        [HttpOptions("{id:length(24)}")]
        [Route("{id}")]
        public IActionResult DeleteOptions()
        {
            return NoContent();
        }
        // Delete an item
        [HttpDelete("{id:length(24)}")]
        [Route("{id}")]
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
