namespace tic_tac_toe;

public class TicTacToe
{
    string[] BoardContent { get; set; }
    bool ShouldGameContinueRunning { get; set; } = true;

    TurnManager turnManager = new TurnManager();
    string[] emptyStrings = new string[9] { "", "", "", "", "", "", "", "", "" };

    public TicTacToe()
    {
        BoardContent = emptyStrings;
        turnManager = new TurnManager();
    }

    public void Init()
    {
        Clear();
        DisplayGameIntro();

        while (ShouldGameContinueRunning)
        {
            DisplayFormattedBoard(BoardContent);
            turnManager.DisplayCurrentTurn();


            char userOption = Helper.AskForCharNumber("Select a cell position: ");
            Console.WriteLine();

            bool shouldToggleTurn = IsValidPosition(userOption);
            VerifyGame(BoardContent);

            if (shouldToggleTurn) turnManager.ToggleTurn();

        }

    }

    void DisplayGameIntro()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe Game!");
        Console.WriteLine("Use the keyboard numbers to select the cell position like this:");

        string[] numberStrings1to9 = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        DisplayFormattedBoard(numberStrings1to9);
        Console.WriteLine();
    }

    void DisplayFormattedBoard(string[] items)
    {
        string[] positions = new string[9];

        for (int i = 0; i < 9; i++)
        {
            positions[i] = Helper.ItemOrWhiteSpace(items[i]);
        }

        Console.WriteLine($" {positions[0]} | {positions[1]} | {positions[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {positions[3]} | {positions[4]} | {positions[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {positions[6]} | {positions[7]} | {positions[8]} ");
    }


    bool IsValidPosition(char position)
    {
        int index = int.Parse(position.ToString()) - 1;
        bool IsAlreadyOccuped = !String.IsNullOrEmpty(BoardContent[index]);

        if (index < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0 Não é uma opção.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        if (IsAlreadyOccuped)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This cell is already ocupped. Try again.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        else
        {
            BoardContent[index] = turnManager.CurrentTurn.ToString();
            return true;
        }

    }
    void VerifyGame(string[] BoardContent)
    {
        if (
        // row
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 0, 1, 2 }) ||
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 3, 4, 5 }) ||
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 6, 7, 8 }) ||
        // column
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 0, 3, 6 }) ||
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 1, 4, 7 }) ||
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 2, 5, 8 }) ||
        // diagonal
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 0, 4, 8 }) ||
        Helper.IsEqualAtIndexes(BoardContent, new int[] { 6, 4, 2 })
        )
        {
            Clear();
            ShouldGameContinueRunning = false;
            DisplayResults(BoardContent);
            DisplayFormattedBoard(BoardContent);
        }
    }

    void DisplayResults(string[] BoardContent)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{turnManager.CurrentTurn} Venceu!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    void Clear() => Console.Clear();
}

public class TurnManager
{
    public Player CurrentTurn { get; private set; }

    public TurnManager()
    {
        CurrentTurn = Player.X;
    }

    public void ToggleTurn() =>
        CurrentTurn = (CurrentTurn == Player.X) ? Player.O : Player.X;

    public void DisplayCurrentTurn()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{CurrentTurn} Player's Turn");
        Console.ForegroundColor = ConsoleColor.White;
    }

}

public enum Player
{
    X, O
}




/*
TicTacToe
{
- char[9] BoardContent = new char[9] {} 
- TurnManager turnManager;

+ Init()
+ DisplayGameIntro()
+ FormatBoard(char[] BoardContent)

+ VerifyUserInput(char input)
+ AddBoardContent(int position)
+ VerifyGame()
+ turnManager.ToggleTurn()
}

TurnManager
{
- string XPlayerName;
- string OPlayerName;
- Player CurrentTurn = Player.X;

+ ToggleTurn()
}

enum Player {
    X, O
}
*/
