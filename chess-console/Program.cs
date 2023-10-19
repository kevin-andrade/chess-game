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
                Board board = new(8, 8);

                // Added parts
                board.AddPart(new Tower(Color.Black, board), new Position(0, 0));
                board.AddPart(new Tower(Color.Black, board), new Position(1, 3));
                board.AddPart(new King(Color.Black, board), new Position(2, 4));
                board.AddPart(new Tower(Color.White, board), new Position(3, 5));

                // Console screen
                Screen.PrintTable(board);
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