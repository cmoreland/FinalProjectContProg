using Microsoft.EntityFrameworkCore;
using FinalProjectContProg.Data;
using FinalProjectContProg.Seeds;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "FinalProjectContProg API";
    config.Description = "An API for managing team members, projects, skills, and tasks.";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    TeamMemberSeed.Seed(context);
    ProjectSeed.Seed(context);
    SkillSeed.Seed(context);
    TaskSeed.Seed(context);
    ColorsSeed.Seed(context);
    FoodSeed.Seed(context);
}

app.Run();
