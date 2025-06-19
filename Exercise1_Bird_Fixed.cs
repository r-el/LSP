using System;

namespace LSP_Exercises.Fixed
{
    // Exercise 1: Bird That Shouldn't Fly - FIXED VERSION
    
    // Base class for all birds
    public abstract class BirdBase
    {
        public virtual void Eat()
        {
            Console.WriteLine("Bird is eating");
        }
        
        public virtual void MakeSound()
        {
            Console.WriteLine("Bird makes a sound");
        }
    }
    
    // Interface for birds that can fly
    public interface ICanFly
    {
        void Fly();
    }
    
    // Sparrow can fly
    public class SparrowFixed : BirdBase, ICanFly
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow is flying gracefully!");
        }
        
        public override void MakeSound()
        {
            Console.WriteLine("Sparrow chirps: Tweet tweet!");
        }
    }
    
    // Eagle can fly
    public class Eagle : BirdBase, ICanFly
    {
        public void Fly()
        {
            Console.WriteLine("Eagle soars majestically!");
        }
        
        public override void MakeSound()
        {
            Console.WriteLine("Eagle screeches: Screech!");
        }
    }
    
    // Penguin cannot fly - no ICanFly interface
    public class PenguinFixed : BirdBase
    {
        public void Swim()
        {
            Console.WriteLine("Penguin swims gracefully!");
        }
        
        public override void MakeSound()
        {
            Console.WriteLine("Penguin says: Honk honk!");
        }
    }
    
    // Client code that works with flying birds
    public static class FixedBirdClient
    {
        // This method only accepts birds that can fly
        public static void MakeBirdFly(ICanFly flyingBird)
        {
            flyingBird.Fly(); // Safe - all ICanFly implementers can fly
        }
        
        // This method works with all birds
        public static void MakeBirdEat(BirdBase bird)
        {
            bird.Eat(); // Safe - all birds can eat
        }
        
        // This method works with all birds
        public static void MakeBirdMakeSound(BirdBase bird)
        {
            bird.MakeSound(); // Safe - all birds can make sounds
        }
    }
}
