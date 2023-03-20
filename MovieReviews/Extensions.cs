namespace MovieReviews;

public static class ProgramExtensions
{
    public static async Task SeedData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var movieDbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
            var seedService = scope.ServiceProvider.GetRequiredService<ISeedService>();
            await seedService.Seed(movieDbContext);
        }
    }
}
