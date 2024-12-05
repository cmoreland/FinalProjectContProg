using FinalProjectContProg.Models;
using FinalProjectContProg.Data;

namespace FinalProjectContProg.Seeds
{
    public static class TaskSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Tasks.Any())
            {
                var project = context.Projects.FirstOrDefault();

                var tasks = new[]
                {
                    new FinalProjectContProg.Models.Task { Title = "Develop Login Page", Status = "Pending", ProjectId = project?.Id ?? 1 },
                    new FinalProjectContProg.Models.Task { Title = "Design Database Schema", Status = "In Progress", ProjectId = project?.Id ?? 1 },
                    new FinalProjectContProg.Models.Task { Title = "Implement API Endpoints", Status = "Completed", ProjectId = project?.Id ?? 1 }
                };

                context.Tasks.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}
