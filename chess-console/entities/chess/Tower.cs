using board;
using chess_console;

namespace chess {
    class Tower : Piece {
        public Tower(Color color, Board board) : base(color, board) {
        }

        public override string ToString() {
            return "[T]";
        }
    }
}