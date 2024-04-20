using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();

// Add Module Services
builder.Services.AddReviewServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();
