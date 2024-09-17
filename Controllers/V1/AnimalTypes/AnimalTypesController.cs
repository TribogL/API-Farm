using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Farm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Farm.Controllers.V1.AnimalTypes;
[ApiController]
[Route("api/V1/[controller]")]
public class AnimalTypesController : ControllerBase
{
    private readonly ApplicationDbContext Context;

    public AnimalTypesController(ApplicationDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var animalTypes = await Context.AnimalTypes.ToListAsync();

        if (animalTypes.Any() == false)
        {
            return NoContent();
        }
        return Ok(animalTypes);
    }

}

