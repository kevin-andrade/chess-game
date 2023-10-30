using chess_console;

namespace board{

    abstract class Piece {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board) {
            Position = null;
            Color = color;
            Board = board;
            QtyMovements = 0;
        }

        public void IncreaseQtyMovement() {
            QtyMovements++;
        }

        public void DecreaseQtyMovement() {
            QtyMovements--;
        }

        // When the part is blocked
        public bool TruePossibleMovements() {
            bool[,] mat = PossibleMoves();
            for (int i=0; i<Board.Lines; i++) {
                for (int j=0; j<Board.Columns; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos) {
            return PossibleMoves()[pos.Line, pos.Column];
        }

        // Movement of parts
        public abstract bool[,] PossibleMoves();
    }
}