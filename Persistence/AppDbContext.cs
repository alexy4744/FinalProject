namespace FinalProject.Persistence;

using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class AppDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(recipe =>
        {
            recipe.Property(r => r.CreatedOnUtc);

            recipe.Property(r => r.Description);

            recipe.HasKey(r => r.Id);

            recipe.OwnsMany(r => r.Ingredients, ingredient =>
            {
                ingredient.Property(i => i.Description);

                ingredient.Property(i => i.Name);

                ingredient.Property(i => i.Quantity);
            });

            recipe.Property(r => r.Name);
            recipe.HasIndex(r => r.Name).IsUnique();

            recipe.Property(r => r.Steps).HasConversion(
                steps => JsonSerializer.Serialize(steps, new JsonSerializerOptions()),
                steps => JsonSerializer.Deserialize<string[]>(steps, new JsonSerializerOptions()) ?? Array.Empty<string>(),
                new ValueComparer<string[]>(
                    (a, b) => a!.SequenceEqual(b!),
                    a => a.Aggregate(0, (x, y) => HashCode.Combine(x, y.GetHashCode())),
                    a => a.ToArray()
                )
            );
        });
    }
}
