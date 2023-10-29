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

                while (!match.Finished) {
                    try {
                    Console.Clear();
                    Screen.PrintTable(match.Board);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Round: " + match.Round);
                    Console.WriteLine("Waiting for player move: " + match.CurrentPlayer);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    match.ValidateOriginPosition(origin);

                    bool[,] PiecePossibleMovement = match.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintTable(match.Board, PiecePossibleMovement);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();
                    match.ValidateDestinyPosition(origin, destiny);

                    match.MakePlay(origin, destiny);
                    }
                    catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.Write("Press Enter to continue");
                        Console.ReadLine();
                    }
                }
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