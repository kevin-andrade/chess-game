using chess_console;
using board;

namespace chess {
    class ChessMatch {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch(){
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            InsertParts();
        }

        public void PerformMovement(Position origin, Position destiny) {
            Piece p = Board.RemovePart(origin);
            p.IncreaseQtyMovement();
            Piece capturePiece = Board.RemovePart(destiny);
            Board.AddPart(p, destiny);
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

        private void InsertParts() {
            Board.AddPart(new Tower(Color.White, Board), new ChessPosition('c', 1).ToPosition());
            Board.AddPart(new Tower(Color.White, Board), new ChessPosition('c', 2).ToPosition());
            Board.AddPart(new Tower(Color.White, Board), new ChessPosition('d', 2).ToPosition());
            Board.AddPart(new Tower(Color.White, Board), new ChessPosition('e', 2).ToPosition());
            Board.AddPart(new Tower(Color.White, Board), new ChessPosition('e', 1).ToPosition());
            Board.AddPart(new King(Color.White, Board), new ChessPosition('d', 1).ToPosition());

            Board.AddPart(new Tower(Color.Black, Board), new ChessPosition('c', 7).ToPosition());
            Board.AddPart(new Tower(Color.Black, Board), new ChessPosition('c', 8).ToPosition());
            Board.AddPart(new Tower(Color.Black, Board), new ChessPosition('d', 7).ToPosition());
            Board.AddPart(new Tower(Color.Black, Board), new ChessPosition('e', 7).ToPosition());
            Board.AddPart(new Tower(Color.Black, Board), new ChessPosition('e', 8).ToPosition());
            Board.AddPart(new King(Color.Black, Board), new ChessPosition('d', 8).ToPosition());
        }
    }
}