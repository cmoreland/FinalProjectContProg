using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds
{
    public static class FoodSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Food.Any())
            {
                var teamMembers = context.TeamMembers.ToList();

                var foods = teamMembers.Select(member => new Food
                {
                    Name = member.FullName,
                    Breakfast = "Pancakes",
                    Lunch = "Salad",
                    Snack = "Chips",
                    Dinner = "Pizza",
                    TeamMemberId = member.Id
                });

                context.Food.AddRange(foods);
                context.SaveChanges();
            }
        }
    }
}
