using AnimeCrud.Data;
using AnimeCrud.DTOs;
using AnimeCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeCrud.Controllers;

[Route("api/v1")]
[ApiController]
public class AnimeController : ControllerBase
{
    private AnimeContext _context;
    public AnimeController() => _context = new AnimeContext();

    [HttpGet]
    public async Task<IActionResult> GetAnimes()
    {
        List<Anime> animes = await _context.Animes.ToListAsync();

        return Ok(animes);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAnime([FromBody] AnimeDTO model)
    {
        try
        {
            Anime anime = new()
            {
                Title = model.Title,
                Year = model.Year
            };

            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();

            return Created("", new { message = "Successfully created" });
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
        catch
        {
            return StatusCode(500, new { Message = "Server Error" });
        }
    }

}