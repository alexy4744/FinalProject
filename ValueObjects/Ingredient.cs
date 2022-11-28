namespace FinalProject.ValueObjects;

// ReSharper disable once ClassNeverInstantiated.Global
public class Ingredient
{
    public string Description { get; }

    public string Name { get; }

    public uint Quantity { get; }

    // ReSharper disable once UnusedMember.Global
    public Ingredient(string name, string description, uint quantity)
    {
        Description = description;
        Name = name;
        Quantity = quantity;
    }

    // ReSharper disable once UnusedMember.Local
#pragma warning disable CS8618
    private Ingredient()
#pragma warning restore CS8618
    {
        // Required for EF Core fluent configuration
    }
}
