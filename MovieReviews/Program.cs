using MovieReviews;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISeedService, SeedService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddDbContext<MovieDbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<MovieTypeExtension>();

var app = builder.Build();

await app.SeedData();

app.MapGraphQL();
app.Run();