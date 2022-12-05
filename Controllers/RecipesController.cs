namespace FinalProject.Controllers;

using System.Net;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RecipesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Response<Recipe>>> CreateRecipe(Recipe recipe)
    {
        if (await _context.Recipes.AnyAsync(r => r.Name == recipe.Name))
        {
            return Conflict(new Response
            {
                StatusCode = HttpStatusCode.Conflict,
                StatusDescription = $"Recipe '{recipe.Name}' already exists."
            });
        }

        _context.Recipes.Add(recipe);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRecipe), new {id = recipe.Id}, new Response<Recipe>
        {
            Result = recipe,
            StatusCode = HttpStatusCode.Created,
            StatusDescription = $"Recipe '{recipe.Name}' was created successfully."
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Response>> DeleteRecipe(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe is null)
        {
            return NotFound(new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                StatusDescription = $"Recipe '{id}' does not exist."
            });
        }

        _context.Recipes.Remove(recipe);

        await _context.SaveChangesAsync();

        return Ok(new Response
        {
            StatusCode = HttpStatusCode.NoContent,
            StatusDescription = $"Recipe '{id}' was successfully deleted."
        });
    }

    [HttpGet]
    public async Task<ActionResult<Response<IEnumerable<Recipe>>>> GetAllRecipes()
    {
        var recipes = await _context.Recipes.ToListAsync();

        return Ok(new Response<IEnumerable<Recipe>>
        {
            Result = recipes,
            StatusCode = HttpStatusCode.OK,
            StatusDescription = "Recipes were successfully retrieved."
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Response<Recipe>>> GetRecipe(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe is null)
        {
            return NotFound(new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                StatusDescription = $"Recipe '{id}' does not exist."
            });
        }

        return Ok(new Response<Recipe>
        {
            Result = recipe,
            StatusCode = HttpStatusCode.OK,
            StatusDescription = $"Recipe '{id}' was successfully retrieved."
        });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<Recipe>>> UpdateRecipe(int id, Recipe dto)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        
        if (recipe is null)
        {
            return NotFound(new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                StatusDescription = $"Recipe '{id}' does not exist."
            });
        }
        
        if (await _context.Recipes.AnyAsync(r => r.Name == dto.Name))
        {
            return Conflict(new Response
            {
                StatusCode = HttpStatusCode.Conflict,
                StatusDescription = $"Recipe '{recipe.Name}' already exists."
            });
        }

        recipe.Description = dto.Description;
        recipe.Ingredients = dto.Ingredients;
        recipe.Name = dto.Name;
        recipe.Steps = dto.Steps;

        await _context.SaveChangesAsync();

        return Ok(new Response<Recipe>
        {
            Result = recipe,
            StatusCode = HttpStatusCode.OK,
            StatusDescription = $"Recipe '{recipe.Id}' was successfully updated."
        });
    }
}
