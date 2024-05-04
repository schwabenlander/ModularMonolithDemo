using FastEndpoints;
using OnlineCourseReviews.Reviews.Services;
using OnlineCourseReviews.Users;
using Serilog;

// Add logging
var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => 
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints();

// Add Module Services
builder.Services.AddUserModuleServices(builder.Configuration, logger);
builder.Services.AddReviewServices(builder.Configuration, logger);

var app = builder.Build();

app.UseFastEndpoints();

app.Run();

// Needed for tests
public partial class Program
{ }