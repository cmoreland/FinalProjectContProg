using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class ColorsSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Colors.Any())
            {
                var teamMembers = context.TeamMembers.ToList();

                var colors = teamMembers.Select(member => new Color
                {
                    Name = member.FullName,
                    ColorOne = "Blue",
                    ColorTwo = "Green",
                    ColorThree = "Yellow",
                    ColorFour = "Purple",
                    TeamMemberId = member.Id
                });

                context.Colors.AddRange(colors);
                context.SaveChanges();
            }
        }
    }
}
