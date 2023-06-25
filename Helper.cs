public class Helper
{
    public static char AskForCharNumber(string text)
    {
        while (true)
        {
            Console.WriteLine(text);
            ConsoleKeyInfo input = Console.ReadKey();
            char inputChar = input.KeyChar;

            if (Char.IsNumber(inputChar)) return inputChar;
            else Console.WriteLine("Only numbers are allowed");

            Console.WriteLine();

        }
    }
}
