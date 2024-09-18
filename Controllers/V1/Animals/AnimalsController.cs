using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Farm.Data;
using API_Farm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Farm.Controllers.V1.Animals;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ApplicationDbContext Context;

    public AnimalsController(ApplicationDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieves all animal types",
        Description = "Gets a list of all animal types in the database."
    )]
    [SwaggerResponse(200, "Returns a list of animal types.", typeof(IEnumerable<Animal>))]
    [SwaggerResponse(204, "There are no registered animal types.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<IActionResult> GetAll()
    {
        var Animals = await Context.Animals.ToListAsync();

        if (Animals.Any() == false)
        {
            return NoContent();
        }
        return Ok(Animals);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var Animal = await Context.Animals.FindAsync(id);
        if (Animal == null)
        {
            return NoContent();
        }
        return Ok(Animal);
    }


    [HttpGet("search/{keyword}")]
    public async Task<IActionResult> SearchByKeyword([FromRoute] string keyword)
    {
        var Animals = await Context.Animals.Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword)).ToListAsync();
        if (Animals.Any() == false)
        {
            return NoContent();
        }
        return Ok(Animals);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Animal updatedAnimal)
    {
        var Animal = checkExistence(id);
        if (Animal == false)
        {
            return NoContent();
        }
        updatedAnimal.Id = id;
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }

        Context.Entry(updatedAnimal).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return Ok("updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var Animal = checkExistence(id);
        if (Animal == false)
        {
            return NoContent();
        }
        Context.Animals.Remove(await Context.Animals.FindAsync(id));
        await Context.SaveChangesAsync();
        return Ok("deleted");
    }
    private bool checkExistence(int id)
    {
        return Context.Animals.Any(p => p.Id == id);
    }
    
    [HttpPost]
    public async Task<IActionResult> create(Animal nuevoAnimal)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        Context.Animals.Add(nuevoAnimal);
        await Context.SaveChangesAsync();
        return Ok("Se creo el tipo de animal");
    }
}
