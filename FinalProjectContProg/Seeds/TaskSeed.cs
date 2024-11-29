using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class TaskSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Tasks.Any())
            {
                var project = context.Projects.FirstOrDefault(); // Get the first project

                var task = new FinalProjectContProg.Models.Task
                {
                    Title = "Develop Login Page",
                    Status = "Pending",
                    ProjectId = project?.Id ?? 1  // Default to the first project if none exist
                };

                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }
    }
}
