using System;

namespace LSP_Exercises.Fixed
{
    // Exercise 3: Document Export - FIXED VERSION
    // Solution: Separate interfaces for different export capabilities
    
    // Base interface for all document exporters
    public interface IDocumentExporter
    {
        string ExporterType { get; }
        void ProcessDocument();
    }
    
    // Interface for exporters that can export to PDF
    public interface IPdfExportable
    {
        void ExportToPDF();
    }
    
    // Interface for exporters that can export to HTML
    public interface IHtmlExportable
    {
        void ExportToHTML();
    }
    
    // Interface for exporters that can export to Word
    public interface IWordExportable
    {
        void ExportToWord();
    }
    
    // Standard exporter supports multiple formats
    public class StandardExporterFixed : IDocumentExporter, IPdfExportable, IHtmlExportable, IWordExportable
    {
        public string ExporterType => "Standard Multi-Format Exporter";
        
        public void ProcessDocument()
        {
            Console.WriteLine("📄 Processing document with Standard Exporter...");
        }
        
        public void ExportToPDF()
        {
            Console.WriteLine("✅ Exporting document to PDF format...");
            Console.WriteLine("PDF export completed successfully!");
        }
        
        public void ExportToHTML()
        {
            Console.WriteLine("✅ Exporting document to HTML format...");
            Console.WriteLine("HTML export completed successfully!");
        }
        
        public void ExportToWord()
        {
            Console.WriteLine("✅ Exporting document to Word format...");
            Console.WriteLine("Word export completed successfully!");
        }
    }
    
    // Online exporter only supports HTML and Word
    public class OnlineExporterFixed : IDocumentExporter, IHtmlExportable, IWordExportable
    {
        public string ExporterType => "Online Cloud Exporter";
        
        public void ProcessDocument()
        {
            Console.WriteLine("☁️ Processing document with Online Cloud Exporter...");
        }
        
        public void ExportToHTML()
        {
            Console.WriteLine("✅ Exporting document to HTML format via cloud...");
            Console.WriteLine("HTML export completed successfully!");
        }
        
        public void ExportToWord()
        {
            Console.WriteLine("✅ Exporting document to Word format via cloud...");
            Console.WriteLine("Word export completed successfully!");
        }
    }
    
    // PDF-only exporter (specialized for high-quality PDF output)
    public class PdfOnlyExporter : IDocumentExporter, IPdfExportable
    {
        public string ExporterType => "High-Quality PDF Exporter";
        
        public void ProcessDocument()
        {
            Console.WriteLine("🎯 Processing document with specialized PDF Exporter...");
        }
        
        public void ExportToPDF()
        {
            Console.WriteLine("✅ Exporting document to HIGH-QUALITY PDF format...");
            Console.WriteLine("Premium PDF export completed successfully!");
        }
    }
    
    // Client code that works with appropriate interfaces
    public static class FixedDocumentClient
    {
        // Works with any document exporter
        public static void ProcessAnyDocument(IDocumentExporter exporter)
        {
            Console.WriteLine($"Using: {exporter.ExporterType}");
            exporter.ProcessDocument();
        }
        
        // Only works with PDF-capable exporters
        public static void ExportToPdfSafely(IPdfExportable pdfExporter)
        {
            pdfExporter.ExportToPDF();
        }
        
        // Only works with HTML-capable exporters
        public static void ExportToHtmlSafely(IHtmlExportable htmlExporter)
        {
            htmlExporter.ExportToHTML();
        }
        
        // Only works with Word-capable exporters
        public static void ExportToWordSafely(IWordExportable wordExporter)
        {
            wordExporter.ExportToWord();
        }
        
        // Demonstrate the fixed solution
        public static void DemonstrateFixedSolution()
        {
            Console.WriteLine("=== FIXED: Interface Segregation for Export Capabilities ===");
            Console.WriteLine();
            
            // Create exporters
            var standardExporter = new StandardExporterFixed();
            var onlineExporter = new OnlineExporterFixed();
            var pdfExporter = new PdfOnlyExporter();
            
            var allExporters = new IDocumentExporter[] { standardExporter, onlineExporter, pdfExporter };
            
            Console.WriteLine("All exporters can process documents:");
            foreach (var exporter in allExporters)
            {
                ProcessAnyDocument(exporter);
            }
            Console.WriteLine();
            
            Console.WriteLine("PDF Export (only PDF-capable exporters):");
            // These calls are compile-time safe - only PDF-capable exporters accepted
            ExportToPdfSafely(standardExporter);
            ExportToPdfSafely(pdfExporter);
            // ExportToPdfSafely(onlineExporter); // Compile error - onlineExporter doesn't implement IPdfExportable
            Console.WriteLine();
            
            Console.WriteLine("HTML Export (only HTML-capable exporters):");
            ExportToHtmlSafely(standardExporter);
            ExportToHtmlSafely(onlineExporter);
            // ExportToHtmlSafely(pdfExporter); // Compile error - pdfExporter doesn't implement IHtmlExportable
            Console.WriteLine();
            
            Console.WriteLine("Word Export (only Word-capable exporters):");
            ExportToWordSafely(standardExporter);
            ExportToWordSafely(onlineExporter);
            // ExportToWordSafely(pdfExporter); // Compile error - pdfExporter doesn't implement IWordExportable
            Console.WriteLine();
            
            Console.WriteLine("✅ LSP is respected: Each exporter implements only what it can actually do");
            Console.WriteLine("✅ Interface Segregation: Clients depend only on interfaces they need");
            Console.WriteLine("✅ Compile-time safety: Cannot call unsupported operations");
        }
    }
}
