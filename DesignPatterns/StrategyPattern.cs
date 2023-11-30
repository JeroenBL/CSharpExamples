// The 'problem'
// In this scenario we have defined the abstract base class 'Duck' with two methods. Fly and Quack. Both implement
// a 'default' fly and quack behavior. 
// We have created three more classes:
//           - WildDuck     : Implementing the default behaviors from the base class.
//           - MountainDuck : Implementing only the same quack behavior. The fly behavior differs.
//           - ParkDuck     : Implementing the same fly behavior is the MountainDuck but uses the Quack from the base duck class.
//           - RubberDuck   : Implementing different behaviors for both fly and quack.
// In case we need to create lots of different ducks, this 'design' isn't very helpful because; the fly 
// and quack behaviors must be overridden in a lot of cases and can be the same across ducks. So, we also end up with duplicate code.
// Ultimately this will be become problematic in the sense that, this code becomes will be harder to maintain and adding new features requires more time.
namespace StrategyPattern
{
    public abstract class Duck
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying normal");
        }

        public virtual void Quack()
        {
            Console.WriteLine("Quacking loud");
        }
    }

    public class WildDuck : Duck
    {
    }

    public class MountainDuck : Duck
    {
        // Different fly behavior. So we need to override that.
        public override void Fly()
        {
            Console.WriteLine("Flying high");
        }

        // Same quack behavior as Duck class.
        public override void Quack()
        {
            Console.WriteLine("Quacking loud");
        }
    }

    public class ParkDuck : Duck
    {
        // Same fly behavior is the MountainDuck.
        public override void Fly()
        {
            Console.WriteLine("Flying high");
        }
    }

    public class RubberDuck : Duck
    {
        // Different fly behavior (won't fly). So we need to override that.
        public override void Fly()
        {
            Console.WriteLine("I'm not flying");
        }

        // Different quack behavior (squeaks). So we need to override that.
        public override void Quack()
        {
            Console.WriteLine("Squeak");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var wildDuck = new WildDuck();
            wildDuck.Fly();
            wildDuck.Quack();

            var mountainDuck = new MountainDuck();
            mountainDuck.Fly();
            mountainDuck.Quack();

            var parkDuck = new ParkDuck();
            parkDuck.Fly();
            parkDuck.Quack();

            var rubberDuck = new RubberDuck();
            rubberDuck.Fly();
            rubberDuck.Quack();
        }
    }
}

// The solution: StrategyPattern.
// StrategyPattern
// Defines a family of algorithms encapsulating each one and making each interchangable.
// Changes behavior of a class without modifying or extending it.
// In this case, we have a base class 'BetterDuckClass' with two methods. Fly() and Quack(). 
// Because these are both interfaces and not concrete implementations, we can create different
// types of ducks(s) and inject specific fly and quack behaviors. 
namespace StategyPattern
{
    public class Program
    {
        // Create interface for fly().
        public interface IFlyable
        {
            void Fly();
        }

        // Create interface for quack().
        public interface IQuackable
        {
            void Quack();
        }

        // Create the concrete implementation of FylingNormal. Implementing the IFly interface
        public class FlyingNormal : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Flying normal");
            }
        }

        // Create the concrete implementation of FlyingHigh. Implementing the IFly interface
        public class FlyingHigh : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Flying high");
            }
        }

        // Create the concrete implementation of QuackingLoud. Implementing the IQuack interface
        public class QuackingLoud : IQuackable
        {
            public void Quack()
            {
                Console.WriteLine("Quacking loud");
            }
        }

        // Create the concrete implementation of Squeak. Implementing the IQuack interface
        public class Squeak : IQuackable
        {
            public void Quack()
            {
                Console.WriteLine("Squeak");
            }
        }

        // Duck class that injects above interfaces
        public class BetterDuckClass
        {
            IFlyable _fly;
            IQuackable _quack;

        public BetterDuckClass(IFlyable fly, IQuackable quack)
            {
                _fly = fly;
                _quack = quack;
            }

        public void Fly()
            {
                _fly.Fly();
            }

        public void Quack()
            {
                _quack.Quack();
            }
        }

        public static void Main(string[] args)
        {
            // Create fly behaviours
            IFlyable flyingNormal = new FlyingNormal();
            IFlyable flyingHigh = new FlyingHigh();

            // Create quack behaviours
            IQuackable quackingLoud = new QuackingLoud();
            IQuackable squeek = new Squeak();

            // Create wildDuck (flying normal, quacking loud)
            Console.WriteLine("WildDuck (flying normal, quacking loud");
            var betterWildDuck = new BetterDuckClass(flyingNormal, quackingLoud);
            betterWildDuck.Fly();
            betterWildDuck.Quack();
            Console.WriteLine("");

            // Create mountainDuck (flying high, quacking loud)
            Console.WriteLine("MountainDuck (flying high, quacking loud");
            var betterMountainDuck = new BetterDuckClass(flyingHigh, quackingLoud);
            betterMountainDuck.Fly();
            betterMountainDuck.Quack();
            Console.WriteLine("");

            // Create parkDuck (flying high, quacking loud)
            Console.WriteLine("ParkDuck (flying high, quacking loud");
            var betterParkDuck = new BetterDuckClass(flyingHigh, quackingLoud);
            betterParkDuck.Fly();
            betterParkDuck.Quack();
            Console.WriteLine("");

            // Create rubberDuck (won't fly, squeeks)
            Console.WriteLine("RubberDuck (won't fly, squeeks)");
            var betterRubberDuck = new BetterDuckClass(null, squeek);
            betterRubberDuck.Quack();
            Console.WriteLine("");
        }
    }
}

// Outputs:
// WildDuck (flying normal, quacking loud
// Flying normal
// Quacking loud
//
// MountainDuck (flying high, quacking loud
// Flying high
// Quacking loud
//
// RubberDuck (won't fly, squeeks)
// Squeak
