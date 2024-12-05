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
                var teamMembers = context.TeamMembers.ToList();

                var skills = teamMembers.SelectMany(member => new[]
                {
                    new Skill { Name = "C#", TeamMemberId = member.Id },
                    new Skill { Name = "SQL", TeamMemberId = member.Id },
                    new Skill { Name = "JavaScript", TeamMemberId = member.Id }
                });

                context.Skills.AddRange(skills);
                context.SaveChanges();
            }
        }
    }
}
