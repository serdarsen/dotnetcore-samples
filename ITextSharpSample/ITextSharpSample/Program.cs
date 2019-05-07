using System;
using System.Text;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ITextSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://africau.edu/images/default/sample.pdf";
            var text = ExtractTextFromPdf(url);

            Console.WriteLine(text);
        }

        public static string ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return text.ToString();
            }
        }
    }
}
