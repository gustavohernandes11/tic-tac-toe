public class Helper
{
    public static char AskForCharNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            ConsoleKeyInfo input = Console.ReadKey();
            char inputChar = input.KeyChar;

            if (Char.IsNumber(inputChar)) return inputChar;
            else Console.WriteLine("Only numbers are allowed");

            Console.WriteLine();
        }
    }

    public static string ItemOrWhiteSpace(string item) =>
        String.IsNullOrEmpty(item) ? " " : item;


    public static bool IsEqualAtIndexes<T>(T[] array, int[] indexes)
    {
        if (indexes.Max<int>() + 1 > array.Length || indexes.Min<int>() < 0)
            throw new Exception("Invalid index in indexes array.");

        if (indexes.Length == 0)
            throw new Exception("Indefined indexes.");

        if (array.Length == 0)
            return true;

        T firstArrayItem = array[indexes[0]];

        foreach (var index in indexes)
        {
            if (array[index] is string && String.IsNullOrWhiteSpace(array[index]?.ToString()))
                return false;

            if (!firstArrayItem!.Equals(array[index]))
                return false;
        }
        return true;
    }
}
