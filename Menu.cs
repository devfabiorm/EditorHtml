namespace EditorHtml;

static class Menu
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        DrawScreen();
        WriteOptions();

        var option = short.Parse(Console.ReadLine());

        HandleMenuOption(option);
    }

    public static void DrawScreen()
    {
        DrawLines('+', '-', '+', true);
        for (int lines = 0; lines <= 10; lines++)
        {
            DrawLines('|', ' ', '|', true);
        }
        DrawLines('+', '-', '+', false);
    }

    public static void DrawLines(char startChar, char separatorChar, char endChar, bool jumpLine)
    {
        Console.Write(startChar);
        for (int i = 0; i <= 30; i++)
            Console.Write(separatorChar);
        Console.Write(endChar);

        if (jumpLine)
            Console.Write("\n");
    }

    public static void WriteOptions()
    {
        WriteLine(3, 2, "Editor HTML");
        WriteLine(3, 3, "===================");
        WriteLine(3, 4, "Selecione uma opção abaixo");
        WriteLine(3, 6, "1 - Novo Arquivo");
        WriteLine(3, 7, "2 - Abrir");
        WriteLine(3, 9, "0 - Sair");
        WriteLine(3, 10, "Opção: ", false);

    }

    public static void WriteLine(int col, int line, string text, bool jumpLine = true)
    {
        Console.SetCursorPosition(col, line);

        if (jumpLine)
            Console.WriteLine(text);
        else
            Console.Write(text);
    }

    public static void HandleMenuOption(short option)
    {
        switch (option)
        {
            case 1: Editor.Show(); break;
            case 2: Viewer.Show(); break;
            case 0:
                {
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                }
            default: Show(); break;
        }
    }
}
