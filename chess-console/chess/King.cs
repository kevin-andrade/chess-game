using board;
using chess_console;

namespace chess {
    class King : Piece {
        private ChessMatch Game;
        public King(Color color, Board board, ChessMatch game) : base(color, board) {
            Game = game;
        }

        private bool CanMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        private bool TestRookForCastling(Position pos) {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.QtyMovements == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0,0);

            //Clockwise Direction
            //North
            pos.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //NorthEast
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //East
            pos.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //SouthEast
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //South
            pos.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //SouthWest
            pos.SetValues(Position.Line + 1, Position.Column -1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //West
            pos.SetValues(Position.Line, Position.Column -1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //NorthWest
            pos.SetValues(Position.Line - 1, Position.Column -1);
            if (Board.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //Special castling move
            if (QtyMovements == 0 && !Game.Check) {
                // #Castle kingside
                Position posTower1 = new(Position.Line, Position.Column + 3);
                if (TestRookForCastling(posTower1)) {
                    Position p1 = new(Position.Line, Position.Column + 1);
                    Position p2 = new(Position.Line, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null) {
                        mat[Position.Line, Position.Column +2] = true;
                    }
                }
                // #Castle Queenside
                Position posTower2 = new(Position.Line, Position.Column - 4);
                if (TestRookForCastling(posTower2)) {
                    Position p1 = new(Position.Line, Position.Column - 1);
                    Position p2 = new(Position.Line, Position.Column - 2);
                    Position p3 = new(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null) {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString() {
            return "K";
        }
    }
}