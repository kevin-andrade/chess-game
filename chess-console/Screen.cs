using board;

namespace chess_console {
    class Screen {
        public static void PrintTable(Board board) {
            for (int i=0; i<board.Lines; i++) {
                for (int j=0; j<board.Columns; j++) {
                    if (board.Piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}