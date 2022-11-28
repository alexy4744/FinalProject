namespace FinalProject.Entities;

using ValueObjects;

public class Recipe
{
    public DateTime CreatedOnUtc { get; }

    public string Description { get; set; }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public int Id { get; }

    public ICollection<Ingredient> Ingredients { get; set; }

    public string Name { get; set; }

    public string[] Steps { get; set; }

    // ReSharper disable once UnusedMember.Global
    public Recipe(string name, string description, ICollection<Ingredient> ingredients, string[] steps)
    {
        CreatedOnUtc = DateTime.UtcNow;
        Description = description;
        Ingredients = ingredients;
        Name = name;
        Steps = steps;
    }

    // ReSharper disable once UnusedMember.Local
#pragma warning disable CS8618
    private Recipe()
#pragma warning restore CS8618
    {
        // Required for EF Core fluent configuration
    }
}
