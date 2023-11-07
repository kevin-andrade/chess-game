using board;

namespace chess_console {
    class Pawn : Piece{
        public Pawn(Color color, Board board) : base(color, board) {
        }

        private bool HasAnEnemy(Position pos) {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool FreePosition(Position pos) {
            return Board.Piece(pos) == null;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new(0,0);

            if (Color == Color.White) {
                //Up
                pos.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && FreePosition(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && FreePosition(pos) && QtyMovements == 0) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HasAnEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HasAnEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else {
                //Down
                pos.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && FreePosition(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && FreePosition(pos) && QtyMovements == 0) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HasAnEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HasAnEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }

        public override string ToString() {
            return "P";
        }
    }
}