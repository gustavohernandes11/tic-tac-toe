namespace tic_tac_toe
{
    public class TicTacToe
    {
        string[] BoardContent { get; set; }
        TurnManager turnManager = new TurnManager();
        bool ShouldGameContinueRunning { get; set; } = true;

        public TicTacToe()
        {
            BoardContent = new string[9];
            turnManager = new TurnManager();
        }

        public void Init()
        {
            DisplayGameIntro();

            while (ShouldGameContinueRunning)
            {
                DisplayFormattedBoard(BoardContent);
                turnManager.DisplayCurrentTurn();

                char userOption = Helper.AskForCharNumber("Select a cell position: ");
                bool shouldToggleTurn = IsValidPosition(userOption);

                if (shouldToggleTurn) turnManager.ToggleTurn();

                VerifyGame(BoardContent);
                Clear();
            }
            DisplayResults(BoardContent);
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
            Console.WriteLine($" {ItemOrWhiteSpace(items[0])} | {ItemOrWhiteSpace(items[1])} | {ItemOrWhiteSpace(items[2])} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {ItemOrWhiteSpace(items[3])} | {ItemOrWhiteSpace(items[4])} | {ItemOrWhiteSpace(items[5])} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {ItemOrWhiteSpace(items[6])} | {ItemOrWhiteSpace(items[7])} | {ItemOrWhiteSpace(items[8])} ");

        }
        string ItemOrWhiteSpace(string item) =>
            String.IsNullOrEmpty(item) ? " " : item;

        bool IsValidPosition(char position)
        {
            int index = int.Parse(position.ToString()) - 1;
            bool IsAlreadyOccuped = !String.IsNullOrEmpty(BoardContent[index]);

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
        void VerifyGame(string[] BoardContent) => throw new NotImplementedException();
        void DisplayResults(string[] BoardContent) => throw new NotImplementedException();
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
