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
                var teamMembers = context.TeamMembers.ToList();

                var projects = teamMembers.Select(member => new Project
                {
                    Name = $"{member.FullName}'s Project",
                    Description = "A personalized project for team member.",
                    TeamMemberId = member.Id
                });

                context.Projects.AddRange(projects);
                context.SaveChanges();
            }
        }
    }
}
