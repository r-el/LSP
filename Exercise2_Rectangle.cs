using System;

namespace LSP_Exercises
{
    // Exercise 2: Square vs Rectangle - LSP Violation
    
    // Rectangle class with Width and Height
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        
        public virtual int Area()
        {
            return Width * Height;
        }
        
        public override string ToString()
        {
            return $"Rectangle(Width={Width}, Height={Height}, Area={Area()})";
        }
    }
    
    // Square inherits Rectangle - LSP VIOLATION!
    // A square must maintain width = height, but this breaks Rectangle's contract
    public class Square : Rectangle
    {
        public Square(int side) : base(side, side)
        {
        }
        
        // Override Width to maintain square property
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value; // Force height to match width
            }
        }
        
        // Override Height to maintain square property
        public override int Height
        {
            get => base.Height;
            set
            {
                base.Width = value;  // Force width to match height
                base.Height = value;
            }
        }
        
        public override string ToString()
        {
            return $"Square(Side={Width}, Area={Area()})";
        }
    }
    
    // Client code that works with rectangles
    public static class RectangleClient
    {
        public static void TestArea(Rectangle shape)
        {
            Console.WriteLine($"Testing shape: {shape}");
            
            // Set width and height independently
            shape.Width = 5;
            shape.Height = 10;
            
            Console.WriteLine($"After setting Width=5, Height=10: {shape}");
            
            // Client expects: if I set width to 5 and height to 10, area should be 50
            int expectedArea = 5 * 10;
            int actualArea = shape.Area();
            
            Console.WriteLine($"Expected Area: {expectedArea}");
            Console.WriteLine($"Actual Area: {actualArea}");
            
            if (expectedArea == actualArea)
            {
                Console.WriteLine("✅ Test PASSED - Area calculation is correct");
            }
            else
            {
                Console.WriteLine("❌ Test FAILED - Area calculation is unexpected!");
                Console.WriteLine("This is an LSP violation!");
            }
            
            Console.WriteLine();
        }
        
        public static void DemonstrateProblem()
        {
            Console.WriteLine("=== Rectangle vs Square LSP Problem ===");
            Console.WriteLine();
            
            Console.WriteLine("Testing with Rectangle:");
            var rectangle = new Rectangle(3, 4);
            TestArea(rectangle);
            
            Console.WriteLine("Testing with Square (substituted for Rectangle):");
            var square = new Square(3);
            TestArea(square); // This will break the expected behavior!
        }
    }
}
