using chess_console;
using board;

namespace chess {
    class Bishop : Piece {
        public Bishop(Color color, Board board) : base(color, board) {
        }

        private bool CanMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves() {

            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new(0,0);

            //Moves only on the diagonals of the board.
            //Clockwise direction

            //NorthEast
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column + 1);
            }

            //SouthEast
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column + 1);
            }

            //SouthWest
            pos.SetValues(Position.Line + 1, Position.Column -1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column - 1);
            }

            //Northwest
            pos.SetValues(Position.Line - 1, Position.Column -1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column -1);
            }
            return mat;
        }

        public override string ToString() {
            return "B";
        }
    }
}