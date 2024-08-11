using Homework02.Models;

namespace Homework02.Data
{
    public class StaticDb
    {
        public List<Beverage> Beverages = new List<Beverage>
        {
            new Beverage { Brand = "Coca-Cola", Type = "Soda" },
            new Beverage { Brand = "Pepsi", Type = "Soda" },
            new Beverage { Brand = "Lipton", Type = "Tea" },
            new Beverage { Brand = "Nescafe", Type = "Coffee" }
        };
    }
}
