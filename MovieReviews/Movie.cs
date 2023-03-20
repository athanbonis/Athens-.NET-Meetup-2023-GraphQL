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