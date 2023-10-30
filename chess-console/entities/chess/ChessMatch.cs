using chess_console;
using board;

namespace chess {
    class ChessMatch {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedParts;

        public ChessMatch(){
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedParts = new HashSet<Piece>();
            InsertParts();
        }

        public void PerformMovement(Position origin, Position destiny) {
            Piece p = Board.RemovePart(origin);
            p.IncreaseQtyMovement();
            Piece capturedPart = Board.RemovePart(destiny);
            Board.AddPart(p, destiny);
            if (capturedPart != null) {
                CapturedParts.Add(capturedPart);
            }
        }

        public HashSet<Piece> CapturedPieces(Color color) {
            HashSet<Piece> aux = new();
            foreach (Piece x in CapturedParts) {
                if (x.Color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color) {
            HashSet<Piece> aux = new();
            foreach (Piece x in Pieces) {
                if (x.Color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void MakePlay(Position origin, Position destiny) {
            PerformMovement(origin, destiny);
            Round++;
            ChangePlayer();
        }

        public void ValidateOriginPosition (Position pos) {
            if (Board.Piece(pos) == null) {
                throw new BoardException("There is no piece in the chosen position!");
            }
            if (CurrentPlayer != Board.Piece(pos).Color) {
                throw new BoardException("The chosen piece belongs to the opponent, select yours!");
            }
            if (!Board.Piece(pos).TruePossibleMovements()) {
                throw new BoardException("There are no movements possible for the original piece");
            }
        }

        public void ValidateDestinyPosition (Position origin, Position destiny) {
            if (!Board.Piece(origin).CanMoveTo(destiny)) {
                throw new BoardException("invalid destination position!");
            }
        }

        private void ChangePlayer() {
            if (CurrentPlayer == Color.White) {
                CurrentPlayer = Color.Black;
            }
            else {
                CurrentPlayer = Color.White;
            }
        }

        public void InsertNewPart(char column, int line, Piece piece) {
            Board.AddPart(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void InsertParts() {
            InsertNewPart('c', 1, new Tower(Color.White, Board));
            InsertNewPart('c', 2, new Tower(Color.White, Board));
            InsertNewPart('d', 2, new Tower(Color.White, Board));
            InsertNewPart('e', 2, new Tower(Color.White, Board));
            InsertNewPart('e', 1, new Tower(Color.White, Board));
            InsertNewPart('d', 1, new King(Color.White, Board));

            InsertNewPart('c', 7, new Tower(Color.Black, Board));
            InsertNewPart('c', 8, new Tower(Color.Black, Board));
            InsertNewPart('d', 7, new Tower(Color.Black, Board));
            InsertNewPart('e', 7, new Tower(Color.Black, Board));
            InsertNewPart('e', 8, new Tower(Color.Black, Board));
            InsertNewPart('d', 8, new King(Color.Black, Board));
        }
    }
}