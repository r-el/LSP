using System;

namespace LSP_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LSP Exercises Demo ===");
            Console.WriteLine();
            
            TestExercise1();
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
    }
}
