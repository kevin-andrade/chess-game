using board;
using chess;

namespace chess_console {
    class Screen {
        public static void PrintTable(Board board) {
            for (int i=0; i<board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.Columns; j++) {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
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
            Console.Write("  A B C D E F G H");
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