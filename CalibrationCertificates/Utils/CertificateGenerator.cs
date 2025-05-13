using System;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static System.Net.Mime.MediaTypeNames;

namespace CalibrationCertificates.Utils
{
    public static class CertificateDocxGenerator
    {
        public static void GenerateCertificateDocx(Dictionary<string, string> replacements, string outputPath)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "Шаблон.docx");

            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Файл шаблона не найден: " + templatePath);

            File.Copy(templatePath, outputPath, true);

            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {
                var body = doc.MainDocumentPart.Document.Body;

                foreach (var text in body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>())

                {
                    foreach (var pair in replacements)
                    {
                        if (text.Text.Contains(pair.Key))
                        {
                            text.Text = text.Text.Replace(pair.Key, pair.Value);
                        }
                    }
                }

                doc.MainDocumentPart.Document.Save();
            }
        }
    }
}
