using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class SkillSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Skills.Any())
            {
                var teamMember = context.TeamMembers.FirstOrDefault(); // Get the first team member

                var skill = new Skill
                {
                    Name = "C#",
                    TeamMemberId = teamMember?.Id ?? 1  // Default to first TeamMember if no team member found
                };

                context.Skills.Add(skill);
                context.SaveChanges();
            }
        }
    }
}
