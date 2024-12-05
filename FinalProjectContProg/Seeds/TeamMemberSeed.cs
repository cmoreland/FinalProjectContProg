using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class TeamMemberSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.TeamMembers.Any())
            {
                var teamMembers = new[]
                {
                    new TeamMember
                    {
                        FullName = "Brian Faught",
                        BirthDate = new DateTime(1997, 4, 1),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Sophomore"
                    },
                    new TeamMember
                    {
                        FullName = "Cameron Moreland",
                        BirthDate = new DateTime(2005, 2, 1),
                        CollegeProgram = "Cybersecurity",
                        YearInProgram = "Sophomore"
                    },
                    new TeamMember
                    {
                        FullName = "Alexia Tincher",
                        BirthDate = new DateTime(2003, 1, 1),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Sophomore"
                    }
                };

                context.TeamMembers.AddRange(teamMembers);
                context.SaveChanges();
            }
        }
    }
}
