using FinalProjectContProg.Models;
using FinalProjectContProg.Data;
using System.Linq;

namespace FinalProjectContProg.Seeds{
    public static class ColorsSeed{
        public static void Seed(AppDbContext context){
            if (!context.Colors.Any()){
                var color = new Color{
                    Name= "Jenna",
                    ColorOne= "Green",
                    ColorTwo="Purple",
                    ColorThree="Blue",
                    ColorFour="red"

                };

                context.Colors.Add(color);
                context.SaveChanges();
            }
        }
    }
}