using System;

namespace LSP_Exercises.Fixed
{
    // Exercise 2: Square vs Rectangle - FIXED VERSION
    // Solution: Make Square and Rectangle separate classes with a common interface
    
    // Common interface for shapes that have an area
    public interface IShape
    {
        int Area();
        string GetShapeInfo();
    }
    
    // Rectangle class - can have different width and height
    public class RectangleFixed : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        
        public RectangleFixed(int width, int height)
        {
            Width = width;
            Height = height;
        }
        
        public int Area()
        {
            return Width * Height;
        }
        
        public string GetShapeInfo()
        {
            return $"Rectangle(Width={Width}, Height={Height}, Area={Area()})";
        }
        
        public override string ToString()
        {
            return GetShapeInfo();
        }
    }
    
    // Square class - completely separate from Rectangle
    public class SquareFixed : IShape
    {
        public int Side { get; set; }
        
        public SquareFixed(int side)
        {
            Side = side;
        }
        
        public int Area()
        {
            return Side * Side;
        }
        
        public string GetShapeInfo()
        {
            return $"Square(Side={Side}, Area={Area()})";
        }
        
        public override string ToString()
        {
            return GetShapeInfo();
        }
    }
    
    // Client code that works with shapes appropriately
    public static class FixedShapeClient
    {
        // This method works with any shape that can calculate area
        public static void PrintShapeArea(IShape shape)
        {
            Console.WriteLine($"Shape: {shape.GetShapeInfo()}");
        }
        
        // This method specifically works with rectangles (that have width/height)
        public static void TestRectangleDimensions(RectangleFixed rectangle)
        {
            Console.WriteLine($"Testing rectangle: {rectangle}");
            
            // Set width and height independently - this is specific to rectangles
            rectangle.Width = 5;
            rectangle.Height = 10;
            
            Console.WriteLine($"After setting Width=5, Height=10: {rectangle}");
            
            int expectedArea = 5 * 10;
            int actualArea = rectangle.Area();
            
            Console.WriteLine($"Expected Area: {expectedArea}");
            Console.WriteLine($"Actual Area: {actualArea}");
            
            if (expectedArea == actualArea)
            {
                Console.WriteLine("✅ Test PASSED - Rectangle behavior is correct");
            }
            else
            {
                Console.WriteLine("❌ Test FAILED");
            }
            
            Console.WriteLine();
        }
        
        // This method specifically works with squares (that have a side)
        public static void TestSquareDimensions(SquareFixed square)
        {
            Console.WriteLine($"Testing square: {square}");
            
            // Set side - this is specific to squares
            square.Side = 7;
            
            Console.WriteLine($"After setting Side=7: {square}");
            
            int expectedArea = 7 * 7;
            int actualArea = square.Area();
            
            Console.WriteLine($"Expected Area: {expectedArea}");
            Console.WriteLine($"Actual Area: {actualArea}");
            
            if (expectedArea == actualArea)
            {
                Console.WriteLine("✅ Test PASSED - Square behavior is correct");
            }
            else
            {
                Console.WriteLine("❌ Test FAILED");
            }
            
            Console.WriteLine();
        }
        
        public static void DemonstrateFixedSolution()
        {
            Console.WriteLine("=== FIXED: Rectangle and Square as separate classes ===");
            Console.WriteLine();
            
            // Create shapes
            var rectangle = new RectangleFixed(3, 4);
            var square = new SquareFixed(5);
            
            Console.WriteLine("Both shapes can calculate area (common interface):");
            PrintShapeArea(rectangle);
            PrintShapeArea(square);
            Console.WriteLine();
            
            Console.WriteLine("Rectangle-specific operations:");
            TestRectangleDimensions(rectangle);
            
            Console.WriteLine("Square-specific operations:");
            TestSquareDimensions(square);
            
            Console.WriteLine("✅ LSP is respected: Each class has its own appropriate behavior");
            Console.WriteLine("✅ No unexpected behavior when working with specific shape types");
        }
    }
}
