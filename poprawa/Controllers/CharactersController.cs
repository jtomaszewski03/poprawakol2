using Microsoft.AspNetCore.Mvc;
using poprawa.Exceptions;
using poprawa.Services;

namespace poprawa.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        try
        {
            var character = await _dbService.GetCharacterWithDetailsAsync(id);
            return Ok(character);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int id, [FromBody] List<int> itemsIds)
    {
        if (!itemsIds.Any()) return BadRequest("No items selected");
        try
        {
            await _dbService.AddItemsToBackpackAsync(id, itemsIds);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

    }
}