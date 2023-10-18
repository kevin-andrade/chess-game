using board;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new(8, 8);

            Screen.PrintTable(board);
        }
    }
}