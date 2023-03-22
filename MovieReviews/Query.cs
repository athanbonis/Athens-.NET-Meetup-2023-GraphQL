using Microsoft.EntityFrameworkCore;

namespace MovieReviews;

public class Query
{
    public Task<Movie[]> GetMovies([Service] MovieDbContext db)
    {
        return db.Movies.ToArrayAsync();
    }
}

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(f => f.GetMovies(default))
            .Type<ListType<MovieType>>();
    }
}