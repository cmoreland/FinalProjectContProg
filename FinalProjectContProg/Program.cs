using Microsoft.EntityFrameworkCore;
using FinalProjectContProg.Data;
using FinalProjectContProg.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext with SQLite connection string.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add NSwag OpenAPI/Swagger services
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "FinalProjectContProg API";
        document.Info.Description = "An API for managing team members, projects, skills, and tasks.";
        document.Info.Contact = new NSwag.OpenApiContact();
        document.Info.License = new NSwag.OpenApiLicense()
        {
            Name = "Use under MIT",
            Url = "https://opensource.org/licenses/MIT"
        };
    };
    
    // Add JWT bearer token authentication
    config.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.ApiKey,
        Name = "Authorization",
        In = OpenApiSecurityApiKeyLocation.Header,
        Description = "Type into the textbox: Bearer {your JWT token}."
    });

    config.OperationProcessors.Add(
        new AspNetCoreOperationSecurityScopeProcessor("JWT"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(); // Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
    app.UseSwaggerUi(); // Serves the Swagger UI 3 web ui to view the OpenAPI/Swagger documents by default on `/swagger`
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Seed the database with initial data.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Apply migrations if any exist (recommended over EnsureCreated).
    context.Database.Migrate();
    
    // Seed data into the database.
    TeamMemberSeed.Seed(context);
    ProjectSeed.Seed(context);
    SkillSeed.Seed(context);
    TaskSeed.Seed(context);
    ColorsSeed.Seed(context);
    FoodSeed.Seed(context);
}

app.Run();