using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveWhiteSpaceAndUpperCaseWords
{
    public static class AppService
    {
        public static void OneWordString()
        {
            string? text = string.Empty;
            Console.WriteLine("\nFor exit enter q");
            do
            {
                Console.WriteLine("\nEnter a string:");
                text = Console.ReadLine();
                text = RemoveWhiteSpaceAndUpperCaseFromText(text);
                TextCopy.ClipboardService.SetText(text);
            }
            while (text != "q");
        }

        public static void FromFile()
        {
            const Int32 BufferSize = 128;
            List<string> listOfWords = new();
            using (var fileStream = File.OpenRead("fileWithWords.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {

                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var text = RemoveWhiteSpaceAndUpperCaseFromText(line);
                    listOfWords.Add(text);
                }
            }

            using (StreamWriter writetext = new StreamWriter("fileWithFixedWords.txt"))
            {
                foreach (var item in listOfWords)
                {
                    writetext.WriteLine(item + ",");
                }
            }
        }

        private static string? RemoveWhiteSpaceAndUpperCaseFromText(string? text)
        {
            if (text is not null)
            {
                var normalizedString = text.Normalize(NormalizationForm.FormD);
                var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

                for (int i = 0; i < normalizedString.Length; i++)
                {
                    char c = normalizedString[i];
                    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }

                text = stringBuilder
                     .ToString()
                     .Normalize(NormalizationForm.FormC);

                var textArray = text.Split(' ');

                for (int i = 0; i < textArray.Length; i++)
                {
                    textArray[i] = textArray[i].Substring(0, 1).ToUpperInvariant() + textArray[i].Substring(1);
                }

                Array.ForEach(textArray, Console.Write);

                text = string.Join("", textArray);
            }

            return text;
        }
    }
}
