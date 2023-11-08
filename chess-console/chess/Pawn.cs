using board;
using chess;

namespace chess_console {
    class Pawn : Piece{
        private ChessMatch Game;
        public Pawn(Color color, Board board,ChessMatch game) : base(color, board) {
            Game = game;
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

                // En Passant
                if (Position.Line == 3) {
                    Position left = new(Position.Line, Position.Column -1);
                    if (Board.ValidPosition(left) && HasAnEnemy(left) && Board.Piece(left) == Game.VulnerableToEnPassant) {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && HasAnEnemy(right) && Board.Piece(right) == Game.VulnerableToEnPassant) {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else {
                //Black parts
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

                // En Passant
                if (Position.Line == 4) {
                    Position left = new(Position.Line, Position.Column -1);
                    if (Board.ValidPosition(left) && HasAnEnemy(left) && Board.Piece(left) == Game.VulnerableToEnPassant) {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && HasAnEnemy(right) && Board.Piece(right) == Game.VulnerableToEnPassant) {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString() {
            return "P";
        }
    }
}