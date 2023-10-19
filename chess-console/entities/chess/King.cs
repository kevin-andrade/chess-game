using board;
using chess_console;

namespace chess {
    class King : Piece {
        public King(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "K";
        }
    }
}