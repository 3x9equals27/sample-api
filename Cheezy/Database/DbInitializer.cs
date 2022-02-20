using Cheezy.Database.Models;
using Cheezy.Enums;

namespace Cheezy.Database
{
    public static class DbInitializer
    {
        public static void Initialize(CheezyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cheese.Any())
            {
                return;   // DB has been seeded
            }

            var cheese = new Cheese[]
            {
                new Cheese{Taste=Taste.spicy,Name="Pepper Jack"},
                new Cheese{Taste=Taste.spicy,Name="Jalapeno Muenster"},
                new Cheese{Taste=Taste.spicy,Name="Jalapeno Pepper Jack"},
                new Cheese{Taste=Taste.spicy,Name="Habanero Cheddar Cheese"},
                new Cheese{Taste=Taste.spicy,Name="Ghost Pepper Jack Cheese"},
                new Cheese{Taste=Taste.spicy,Name="Spicy Sriracha Cheddar"},
                new Cheese{Taste=Taste.spicy,Name="Chipotle Jack Cheese"},
                new Cheese{Taste=Taste.spicy,Name="Jalapeno Cheddar Cheese"},
                new Cheese{Taste=Taste.spicy,Name="Horseradish Cheddar Cheese"},
                new Cheese{Taste=Taste.spicy,Name="Hot Buffalo Wing Cheddar Cheese"},
                new Cheese{Taste=Taste.spicy,Name="Chipotle Gouda"},

                new Cheese{Taste=Taste.sweet,Name="Gouda"},
                new Cheese{Taste=Taste.sweet,Name="Ricotta"},

                new Cheese{Taste=Taste.salty,Name="Roquefort"},
                new Cheese{Taste=Taste.salty,Name="Halloumi"},

                new Cheese{Taste=Taste.umami,Name="Le Gruyere"},
            };
            foreach (Cheese c in cheese)
            {
                context.Cheese.Add(c);
            }
            context.SaveChanges();
        }
    }
}