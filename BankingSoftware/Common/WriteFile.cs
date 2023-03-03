using System.IO;
using System.Text;

namespace BankingSoftware.Common;

// for writing to text files
public static class WriteFile
{
    public static void WriteLine(string lineText, string fileName)
    {
        using var fs = File.AppendText(fileName);
        fs.Write(lineText);
    }

    public static void WriteLines(string[] linesTexts, string fileName)
    {
        using var fs = File.OpenWrite(fileName);
        for (var i = 0; i < linesTexts.Length; i++)
        {
            var info = new UTF8Encoding(true).GetBytes(linesTexts[i] + "\n");
            fs.Write(info, 0, info.Length);
        }
    }
}