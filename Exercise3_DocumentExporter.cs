using System;

namespace LSP_Exercises
{
    // Exercise 3: Can't Export to PDF - LSP Violation
    
    // Base class for document exporters
    public abstract class DocumentExporter
    {
        public abstract void ExportToPDF();
    }
    
    // Standard exporter that can export to PDF
    public class StandardExporter : DocumentExporter
    {
        public override void ExportToPDF()
        {
            Console.WriteLine("✅ Exporting document to PDF format...");
            Console.WriteLine("PDF export completed successfully!");
        }
    }
    
    // Online exporter that cannot export to PDF - LSP VIOLATION!
    public class OnlineExporter : DocumentExporter
    {
        public override void ExportToPDF()
        {
            throw new NotSupportedException("Online exporters cannot export to PDF format!");
        }
        
        // This exporter can only export to HTML
        public void ExportToHTML()
        {
            Console.WriteLine("✅ Exporting document to HTML format...");
            Console.WriteLine("HTML export completed successfully!");
        }
    }
    
    // Client code that expects all exporters to support PDF
    public static class DocumentClient
    {
        public static void ProcessDocument(DocumentExporter exporter)
        {
            Console.WriteLine("Processing document with exporter...");
            exporter.ExportToPDF(); // This will break with OnlineExporter!
        }
        
        public static void DemonstrateProblem()
        {
            Console.WriteLine("=== Document Export LSP Problem ===");
            Console.WriteLine();
            
            // This works fine
            var standardExporter = new StandardExporter();
            Console.WriteLine("Testing with StandardExporter:");
            try
            {
                ProcessDocument(standardExporter);
                Console.WriteLine("✅ Standard exporter worked as expected");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            
            Console.WriteLine();
            
            // This will throw an exception - LSP violation!
            var onlineExporter = new OnlineExporter();
            Console.WriteLine("Testing with OnlineExporter:");
            try
            {
                ProcessDocument(onlineExporter);
                Console.WriteLine("✅ Online exporter worked as expected");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.WriteLine("This is an LSP violation - substituting OnlineExporter for DocumentExporter breaks the code!");
                Console.WriteLine();
                Console.WriteLine("💡 OnlineExporter can only export to HTML:");
                onlineExporter.ExportToHTML();
            }
            
            Console.WriteLine();
        }
    }
}
