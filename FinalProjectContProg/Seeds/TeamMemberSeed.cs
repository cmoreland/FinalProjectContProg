using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class TeamMemberSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.TeamMembers.Any())
            {
                var teamMember = new TeamMember
                {
                    FullName = "Alice Smith",
                    BirthDate = new DateTime(2000, 5, 15),
                    CollegeProgram = "Computer Science",
                    YearInProgram = "Sophomore"
                };

                context.TeamMembers.Add(teamMember);
                context.SaveChanges();
            }
        }
    }
}
