using System;

namespace LSP_Exercises
{
    // Exercise 1: Bird That Shouldn't Fly - Initial LSP Violation
    
    // Base class Bird with Fly method
    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Bird is flying!");
        }
    }
    
    // Regular flying bird
    public class Sparrow : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying gracefully!");
        }
    }
    
    // Penguin that can't fly - LSP VIOLATION!
    public class Penguin : Bird
    {
        public override void Fly()
        {
            throw new NotSupportedException("Penguins cannot fly!");
        }
    }
    
    // Client code that expects all birds to fly
    public static class BirdClient
    {
        public static void MakeBirdFly(Bird bird)
        {
            bird.Fly(); // This will break with Penguin!
        }
    }
}
