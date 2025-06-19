using System;
using LSP_Exercises.Fixed;

namespace LSP_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LSP Exercises Demo ===");
            Console.WriteLine();
            
            TestExercise1();
            
            Console.WriteLine("=".PadRight(50, '='));
            Console.WriteLine();
            
            TestExercise1Fixed();
        }
        
        static void TestExercise1()
        {
            Console.WriteLine("Exercise 1: Bird That Shouldn't Fly");
            Console.WriteLine("Testing LSP violation...");
            Console.WriteLine();
            
            // This works fine
            Bird sparrow = new Sparrow();
            Console.WriteLine("Testing with Sparrow:");
            BirdClient.MakeBirdFly(sparrow);
            
            Console.WriteLine();
            
            // This will throw an exception - LSP violation!
            Bird penguin = new Penguin();
            Console.WriteLine("Testing with Penguin:");
            try
            {
                BirdClient.MakeBirdFly(penguin);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine("This is an LSP violation - substituting Penguin for Bird breaks the code!");
            }
            
            Console.WriteLine();
        }
        
        static void TestExercise1Fixed()
        {
            Console.WriteLine("Exercise 1: FIXED VERSION - Proper LSP compliance");
            Console.WriteLine("Using ICanFly interface for flying behavior");
            Console.WriteLine();
            
            // Create different bird types
            var sparrow = new SparrowFixed();
            var eagle = new Eagle();
            var penguin = new PenguinFixed();
            
            // All birds can eat and make sounds (LSP compliant)
            Console.WriteLine("All birds can eat:");
            FixedBirdClient.MakeBirdEat(sparrow);
            FixedBirdClient.MakeBirdEat(eagle);
            FixedBirdClient.MakeBirdEat(penguin);
            
            Console.WriteLine();
            Console.WriteLine("All birds can make sounds:");
            FixedBirdClient.MakeBirdMakeSound(sparrow);
            FixedBirdClient.MakeBirdMakeSound(eagle);
            FixedBirdClient.MakeBirdMakeSound(penguin);
            
            Console.WriteLine();
            Console.WriteLine("Only flying birds can fly (ICanFly interface):");
            FixedBirdClient.MakeBirdFly(sparrow);
            FixedBirdClient.MakeBirdFly(eagle);
            // FixedBirdClient.MakeBirdFly(penguin); // This won't compile - penguin doesn't implement ICanFly
            
            Console.WriteLine();
            Console.WriteLine("Penguin has its own special ability:");
            penguin.Swim();
            
            Console.WriteLine();
            Console.WriteLine("✅ LSP is now respected! Birds can be substituted without breaking functionality.");
        }
    }
}
