using System;
using System.Text;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("--------------------");

            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.WriteLine("--------------------");
            Console.WriteLine("Deseja salvar o aquivo? [S]im ou [N]ão");

            var option = Console.ReadLine();
            var choice = ConvertChoice(option);

            if (choice)
            {
                Console.WriteLine("Forneça o caminho para salvar o arquivo");
                HandleOptionSelected(Console.ReadLine(), file.ToString());
            }

            Menu.Show();
        }

        public static void HandleOptionSelected(string path, string content)
        {
            using var file = new StreamWriter(path);
            file.Write(content);
        }

        public static bool ConvertChoice(string option)
        {
            return option.StartsWith("s", StringComparison.OrdinalIgnoreCase);
        }
    }
}