using chess_console;
using board;

namespace chess {
    class Knight : Piece {
        public Knight(Color color, Board board) : base(color, board) {
        }

        private bool CanMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new(0,0);

            //Clockwise direction
            pos.SetValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 2, Position.Column -1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString() {
            return "N";
        }
    }
}