using System;
using System.Text;

namespace newConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myText = "Hello World";
            var convertedText = myText.ConvertToBase64();
            Console.WriteLine("Original Text: " + myText);
            Console.WriteLine("Base64 Encoded Text: " + convertedText);
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit the program!");
            Console.ReadLine();
        }
    }

    public static class ExtensionMethodClass
    {
        public static string ConvertToBase64(this string text)
        {
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(text);
            string base64EncodedText = Convert.ToBase64String(bytesToEncode);
            return base64EncodedText;
        }
    }
}
