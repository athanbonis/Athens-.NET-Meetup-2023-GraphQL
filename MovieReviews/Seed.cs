namespace MovieReviews;

public interface ISeedService
{
    Task Seed(MovieDbContext movieDbContext);
}

public class SeedService : ISeedService
{
    public async Task Seed(MovieDbContext movieDbContext)
    {
        await movieDbContext.Movies.AddRangeAsync(new[]
        {
            new Movie(1, "Movie 1", "Movie 1 description.", "Director 1", DateTime.UtcNow.AddMonths(-5)),
            new Movie(2, "Movie 2", "Movie 2 description.", "Director 1", DateTime.UtcNow.AddMonths(-10)),
            new Movie(3, "Movie 3", "Movie 3 description.", "Director 2", DateTime.UtcNow.AddMonths(-15)),
            new Movie(4, "Movie 4", "Movie 4 description.", "Director 2", DateTime.UtcNow.AddMonths(-11)),
            new Movie(5, "Movie 5", "Movie 5 description.", "Director 3", DateTime.UtcNow.AddMonths(-16)),
        });

        await movieDbContext.SaveChangesAsync();
    }
}
