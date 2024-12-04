using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds{
    public static class FoodSeed{
        public static void Seed(AppDbContext context){
            if (!context.Food.Any()){
                var food = new Food{
                    Name= "Jenna",
                    Breakfast ="Toast",
                    Lunch="Sandwich",
                    Snack="Apple",
                    Dinner="Steak"

                };

                context.Food.Add(food);
                context.SaveChanges();
            }
        }
    }
}