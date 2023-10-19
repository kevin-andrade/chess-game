using board;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chessboard creation
            Board board = new(8, 8);

            // Added parts
            board.AddPart(new Tower(Color.Black, board), new Position(0, 0));
            board.AddPart(new Tower(Color.Black, board), new Position(1, 3));
            board.AddPart(new King(Color.Black, board), new Position(2, 4));

            // Console screen
            Screen.PrintTable(board);
        }
    }
}