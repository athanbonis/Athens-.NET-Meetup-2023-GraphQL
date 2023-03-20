using Microsoft.EntityFrameworkCore;

namespace MovieReviews;

public record Movie(int Id, string Title, string Description, string Director, DateTime Published);

public class MovieType : ObjectType<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Type<IntType>();

        descriptor
            .Field(f => f.Title)
            .Type<StringType>();

        descriptor
            .Field(f => f.Description)
            .Type<StringType>();

        descriptor
            .Field(f => f.Director)
            .Type<StringType>();

        descriptor
            .Field(f => f.Published)
            .Type<DateTimeType>();
    }
}

public class MovieTypeExtension : ObjectTypeExtension<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        descriptor
            .Field("reviews")
            .Type<ListType<ReviewType>>()
            .Resolve(async (context) =>
            {
                var movie = context.Parent<Movie>();
                var dataLoader = context.DataLoader<ReviewsByMovieIdsBatchDataLoader>();
                return await dataLoader.LoadAsync(movie.Id);
            });
    }
}

public class MovieDbContext : DbContext
{
    protected override void OnConfiguring
   (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MovieDb");
    }

    public DbSet<Movie> Movies { get; set; }
}
