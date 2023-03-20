namespace MovieReviews;

public record Review (int Id, int MovieId, int UserId, double Rating, string Text, DateTime Published);

public class ReviewType : ObjectType<Review>
{
    protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Type<IntType>();

        descriptor
            .Field(f => f.MovieId)
            .Type<IntType>();

        descriptor
            .Field(f => f.UserId)
            .Type<IntType>();

        descriptor
           .Field(f => f.Rating)
           .Type<FloatType>();

        descriptor
            .Field(f => f.Text)
            .Type<StringType>();

        descriptor
            .Field(f => f.Published)
            .Type<DateTimeType>();
    }
}

public interface IReviewService
{
    Task<Review[]> GetByMovieIds(IReadOnlyList<int> movieIds);
}

public class ReviewService : IReviewService
{
    public async Task<Review[]> GetByMovieIds(IReadOnlyList<int> movieIds)
    {
        // simulate an API
        await Task.Delay(2000);
        return new[]
        {
            new Review(1, 1, 1, 4.5, "Great movie!", DateTime.UtcNow.AddDays(-5)),
            new Review(2, 1, 2, 3, "Not the best one.", DateTime.UtcNow.AddDays(-15)),
            new Review(3, 2, 1, 2, "It didn't surprise me at all.", DateTime.UtcNow.AddDays(-25)),
            new Review(4, 2, 1, 1.5, "Not great.", DateTime.UtcNow.AddDays(-12)),
            new Review(5, 2, 3, 4, "I loved it.", DateTime.UtcNow.AddDays(-7)),
            new Review(6, 3, 1, 4.5, "Awesome movie!", DateTime.UtcNow.AddDays(-13)),
            new Review(7, 3, 2, 5, "I love this movie! One of the greatest!", DateTime.UtcNow.AddDays(-3)),
            new Review(8, 3, 3, 4, "Very good one.", DateTime.UtcNow.AddDays(-2)),
            new Review(9, 3, 4, 3, "Not great, not terrible.", DateTime.UtcNow.AddDays(-1)),
            new Review(10, 4, 1, 2, "Ehm, I didn't like it.", DateTime.UtcNow.AddDays(-8)),
            new Review(11, 4, 2, 3.5, "Not something special.", DateTime.UtcNow.AddDays(-27))
        }
        .Where(x => movieIds.Contains(x.MovieId))
        .ToArray();
    }
}
