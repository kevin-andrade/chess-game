using chess_console;
using board;

namespace chess {
    class Queen : Piece {
        public Queen(Color color, Board board) : base(color, board) {
        }

        private bool CanMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves() {

            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new(0,0);

            //forward or backward, right or left, or diagonally, as many spaces as you want, but you cannot skip any other piece.
            //Clockwise direction

            //North
            pos.SetValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column);
            }

            //NorthEast
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column + 1);
            }

            //East
            pos.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line, pos.Column + 1);
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

            //South
            pos.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column);
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

            //West
            pos.SetValues(Position.Line, Position.Column -1);
            while (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.SetValues(pos.Line, pos.Column - 1);
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
            return "Q";
        }
    }
}