using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class ProjectSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Projects.Any())
            {
                var teamMember = context.TeamMembers.FirstOrDefault(); // Assuming at least one team member exists

                var project = new Project
                {
                    Name = "Project Alpha",
                    Description = "A project focused on developing a web application.",
                    TeamMemberId = teamMember?.Id ?? 1  // Default to 1 if no team members are found
                };

                context.Projects.Add(project);
                context.SaveChanges();
            }
        }
    }
}
