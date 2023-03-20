using Microsoft.EntityFrameworkCore;

namespace MovieReviews;

public class Query
{
    public Task<Movie[]> GetMovies([Service] MovieDbContext db)
    {
        return db.Movies.ToArrayAsync();
    }
}
