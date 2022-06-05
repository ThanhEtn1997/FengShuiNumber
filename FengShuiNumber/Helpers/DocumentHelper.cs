using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FengShuiNumber.Helpers
{
    public class DocumentHelper
    {
        public static Document CreateDocx(string path, string fileName)
        {
            Document document = new Document();

            //Save doc file.
            document.SaveToFile(Path.Combine(path, fileName), FileFormat.Docx);

            return new Document(Path.Combine(path, fileName));
        }
    }
}
