// See https://aka.ms/new-console-template for more information
using iText.Html2pdf;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;



Console.WriteLine("Hello, World!");
HtmlConverter.ConvertToPdf(@"<h1>Test</h1><p>Hello World</p>", new FileStream(@"D:\SudhirSharma\LearningFolder\iText7\ConsoleApp1\Textfile.pdf",
                     FileMode.Create, FileAccess.Write, FileShare.None));


PdfWriter writer = new PdfWriter(@"D:\SudhirSharma\LearningFolder\iText7\ConsoleApp1\demo.pdf");
PdfDocument pdf = new PdfDocument(writer);
Document document = new Document(pdf);


Paragraph header = new Paragraph("HEADER")
   .SetTextAlignment(TextAlignment.CENTER)
   .SetFontSize(20);
document.Add(header);
Paragraph subheader = new Paragraph("SUB HEADER")
   .SetTextAlignment(TextAlignment.CENTER)
   .SetFontSize(15);
document.Add(subheader);
// Line separator
LineSeparator ls = new LineSeparator(new SolidLine());
document.Add(ls);

// Add image
Image img = new Image(ImageDataFactory
   .Create(@"D:\SudhirSharma\LearningFolder\iText7\ConsoleApp1\aws-certified-logo_color-horz_360x60.png"))
   .SetTextAlignment(TextAlignment.CENTER);
document.Add(img);

// Table
Table table = new Table(2, false);
Cell cell11 = new Cell(1, 1)
   .SetBackgroundColor(ColorConstants.GRAY)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("State"));
Cell cell12 = new Cell(1, 1)
   .SetBackgroundColor(ColorConstants.GRAY)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("Capital"));

Cell cell21 = new Cell(1, 1)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("New York"));
Cell cell22 = new Cell(1, 1)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("Albany"));

Cell cell31 = new Cell(1, 1)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("New Jersey"));
Cell cell32 = new Cell(1, 1)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("Trenton"));

Cell cell41 = new Cell(1, 1)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("California"));
Cell cell42 = new Cell(1, 1)
   .SetTextAlignment(TextAlignment.CENTER)
   .Add(new Paragraph("Sacramento"));

table.AddCell(cell11);
table.AddCell(cell12);
table.AddCell(cell21);
table.AddCell(cell22);
table.AddCell(cell31);
table.AddCell(cell32);
table.AddCell(cell41);
table.AddCell(cell42);
document.Add(table);


// Hyper link
Link link = new Link("click here",
   PdfAction.CreateURI("https://www.google.com"));
Paragraph hyperLink = new Paragraph("Please ")
   .Add(link.SetBold().SetUnderline()
   .SetItalic().SetFontColor(ColorConstants.BLUE))
   .Add(" to go www.google.com.");

//document.Add(newline);
document.Add(hyperLink);
// Page numbers
int n = pdf.GetNumberOfPages();
for (int i = 1; i <= n; i++)
{
    document.ShowTextAligned(new Paragraph(String
       .Format("page" + i + " of " + n)),
        559, 806, i, TextAlignment.RIGHT,
        VerticalAlignment.TOP, 0);
}
// Close document
document.Close();