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
        public bool Check { get; private set; }

        public ChessMatch(){
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            CapturedParts = new HashSet<Piece>();
            InsertParts();
        }

        public Piece PerformMovement(Position origin, Position destiny) {
            Piece p = Board.RemovePart(origin);
            p.IncreaseQtyMovement();
            Piece capturedPart = Board.RemovePart(destiny);
            Board.AddPart(p, destiny);
            if (capturedPart != null) {
                CapturedParts.Add(capturedPart);
            }
            return capturedPart;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPart) {
            Piece p = Board.RemovePart(destiny);
            p.DecreaseQtyMovement();
            if (capturedPart != null) {
                Board.AddPart(capturedPart, destiny);
                CapturedParts.Remove(capturedPart);
            }
            Board.AddPart(p, origin);
        }

        public void MakePlay(Position origin, Position destiny) {
            Piece capturedPart = PerformMovement(origin, destiny);

            if (IsInCheck(CurrentPlayer)) {
                UndoMovement(origin, destiny, capturedPart);
                throw new BoardException("you can't put yourself in check!");
            }

            if (IsInCheck(Adversary(CurrentPlayer))) {
                Check = true;
            }
            else {
                Check = false;
            }

            if (CheckmateTest(Adversary(CurrentPlayer))) {
                Finished = true;
            }
            else {
                Round++;
                ChangePlayer();
            }
        }

        private Color Adversary(Color color) {
            if (color == Color.White) {
                color = Color.Black;
            }
            else {
                color = Color.White;
            }
            return color;
        }

        //Get king piece that color
        private Piece King(Color color) {
            foreach (Piece x in PiecesInPlay(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null;
        }

        //Checks if the king of that color is in check
        public bool IsInCheck(Color color) {
            Piece king = King(color);
            if (king == null) { throw new BoardException("There is no color " + color + " king on the board!"); }

            foreach (Piece x in PiecesInPlay(Adversary(color))) {
                bool[,] mat = x.PossibleMoves();
                if (mat[king.Position.Line, king.Position.Column]) {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color) {
            if (!IsInCheck(color)) {
                return false;
            }

            foreach (Piece x in PiecesInPlay(color)) {
                bool[,] mat = x.PossibleMoves();
                for (int i=0; i<Board.Lines; i++) {
                    for (int j=0; j<Board.Columns; j++) {
                        if (mat[i,j]) {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPart = PerformMovement(origin, destiny);
                            bool isInCheck = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPart);
                            if (!isInCheck) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            InsertNewPart('a', 1, new Tower(Color.White, Board));
            InsertNewPart('b', 1, new Knight(Color.White, Board));
            InsertNewPart('c', 1, new Bishop(Color.White, Board));
            InsertNewPart('d', 1, new Queen(Color.White, Board));
            InsertNewPart('e', 1, new King(Color.White, Board));
            InsertNewPart('f', 1, new Bishop(Color.White, Board));
            InsertNewPart('g', 1, new Knight(Color.White, Board));
            InsertNewPart('h', 1, new Tower(Color.White, Board));
            InsertNewPart('a', 2, new Pawn(Color.White, Board));
            InsertNewPart('b', 2, new Pawn(Color.White, Board));
            InsertNewPart('c', 2, new Pawn(Color.White, Board));
            InsertNewPart('d', 2, new Pawn(Color.White, Board));
            InsertNewPart('e', 2, new Pawn(Color.White, Board));
            InsertNewPart('f', 2, new Pawn(Color.White, Board));
            InsertNewPart('g', 2, new Pawn(Color.White, Board));
            InsertNewPart('h', 2, new Pawn(Color.White, Board));

            InsertNewPart('a', 8, new Tower(Color.White, Board));
            InsertNewPart('b', 8, new Knight(Color.White, Board));
            InsertNewPart('c', 8, new Bishop(Color.White, Board));
            InsertNewPart('d', 8, new Queen(Color.White, Board));
            InsertNewPart('e', 8, new King(Color.White, Board));
            InsertNewPart('f', 8, new Bishop(Color.White, Board));
            InsertNewPart('g', 8, new Knight(Color.White, Board));
            InsertNewPart('h', 8, new Tower(Color.White, Board));
            InsertNewPart('a', 7, new Pawn(Color.White, Board));
            InsertNewPart('b', 7, new Pawn(Color.White, Board));
            InsertNewPart('c', 7, new Pawn(Color.White, Board));
            InsertNewPart('d', 7, new Pawn(Color.White, Board));
            InsertNewPart('e', 7, new Pawn(Color.White, Board));
            InsertNewPart('f', 7, new Pawn(Color.White, Board));
            InsertNewPart('g', 7, new Pawn(Color.White, Board));
            InsertNewPart('h', 7, new Pawn(Color.White, Board));
        }
    }
}