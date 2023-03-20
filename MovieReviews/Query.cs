namespace MovieReviews;

public class Query
{
    public Movie[] GetMovies()
    {
        return new[]
        {
            new Movie(1, "Movie 1", "Movie 1 description.", "Director 1", DateTime.UtcNow.AddMonths(-5)),
            new Movie(2, "Movie 2", "Movie 2 description.", "Director 1", DateTime.UtcNow.AddMonths(-10)),
            new Movie(3, "Movie 3", "Movie 3 description.", "Director 2", DateTime.UtcNow.AddMonths(-15)),
            new Movie(4, "Movie 4", "Movie 4 description.", "Director 2", DateTime.UtcNow.AddMonths(-11)),
            new Movie(5, "Movie 5", "Movie 5 description.", "Director 3", DateTime.UtcNow.AddMonths(-16)),
        };
    }
}
