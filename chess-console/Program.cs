using board;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                // Chessboard creation
                ChessMatch match = new();

                Screen.PrintTable(match.Board);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("An error has occurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}