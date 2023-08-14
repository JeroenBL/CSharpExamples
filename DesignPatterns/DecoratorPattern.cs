// DecoratorPattern.

namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilterCoffee plainCoffee = new FilterCoffee();
            plainCoffee.GetDescription();
            plainCoffee.Costs();
            MilkDecorator milk = new MilkDecorator(plainCoffee);
            milk.GetDescription();
            milk.Costs();
            var totalPrice = plainCoffee.Price + milk.Price;
            Console.WriteLine($"Total price is: {totalPrice.ToString("0.00")}");

            Console.ReadLine();
        }
    }

    public abstract class Coffee 
    {
        public string Description { get; set; } = "";

        public void GetDescription()
        {
            Console.WriteLine(Description);
        }

        public abstract void Costs();
    }

    public abstract class CoffeeDecorator : Coffee
    {
        public abstract void GetDescription();
    }

    public class FilterCoffee : Coffee
    {
        public double Price;

        public FilterCoffee()
        {
            Description = "Ordering filterCoffee";
        }

        public override void Costs()
        {
            Price = 2.40;
            Console.WriteLine($"Price: {Price.ToString("0.00")}");
        }
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public Coffee Coffee;
        public double Price;

        public MilkDecorator(Coffee coffee)
        {
            Coffee = coffee;
        }

        public override void GetDescription()
        {
            Console.WriteLine("Adding foamed milk");
        }

        public override void Costs()
        {
            Price = 0.40;
            Console.WriteLine($"Price: {Price.ToString("0.00")}");
        }
    }
}

// Outputs:
// Ordering filterCoffee
// Price: 2.40
// Adding foamed milk
// Price: 0.40
// Total price is: 2.80
