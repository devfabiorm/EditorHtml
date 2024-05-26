using System;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public class Viewer
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.Write("Insira o caminho do arquivo que deseja visualizar: ");
            var path = Console.ReadLine();
            Console.WriteLine("--------------------");
            Replace(ReadFile(path));
            Console.WriteLine("--------------------");
            Console.ReadKey(true);
            Menu.Show();
        }

        public static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            words[i].LastIndexOf('<') - 1 -
                            words[i].IndexOf('>')
                        )
                    );
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                }
                Console.Write(' ');
            }
        }

        public static string ReadFile(string path)
        {
            string content;

            using var file = new StreamReader(path);
            content = file.ReadToEnd();

            return content;
        }
    }
}