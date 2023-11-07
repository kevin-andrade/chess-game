using board;
using chess;

namespace chess_console {
    class Screen {

        public static void PrintMatch(ChessMatch match) {
            PrintTable(match.Board);
            Console.WriteLine();
            Console.WriteLine();
            PrintCapturedParts(match);
            Console.WriteLine();
            Console.WriteLine("Round: " + match.Round);
            if (!match.Finished) {
                Console.WriteLine("Waiting for player move: " + match.CurrentPlayer);
                if (match.Check) {
                    Console.WriteLine("You are in CHECK!");
                }
                Console.WriteLine();
            }
            else {
                Console.WriteLine();
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
        }

        public static void PrintCapturedParts(ChessMatch match) {
            Console.WriteLine("Captured parts:");
            Console.Write("White: ");
            PrintSetOfParts(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSetOfParts(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSetOfParts(HashSet<Piece> set) {
            Console.Write('[');
            foreach (Piece x in set) {
                Console.Write(x + ", ");
            }
            Console.Write(']');
        }

        public static void PrintTable(Board board) {
            for (int i=0; i<board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.Columns; j++) {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }

        public static void PrintTable(Board board, bool[,] matPiecePossibleMovement) {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkCyan;

            for (int i=0; i<board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.Columns; j++) {
                    if (matPiecePossibleMovement[i, j]) {
                        Console.BackgroundColor = changedBackground;
                    }
                    else {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition() {
            string s = Console.ReadLine();

            if (string.IsNullOrEmpty(s) || s.Length > 2 || !char.IsLetter(s[0]) || !char.IsDigit(s[1])) {
                throw new BoardException("The input is invalid, try for example column and row");
            }

            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece) {
            if (piece == null) {
                Console.Write("- ");
            }
            else {
                if (piece.Color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(' ');
            }
        }
    }
}