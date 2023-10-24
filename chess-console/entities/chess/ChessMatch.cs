using chess_console;
using board;

namespace chess {
    class ChessMatch {
        public Board Board { get; set; }
        private int Round;
        private Color CurrentPlayer;

        public ChessMatch(){
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            InsertParts();
        }

        public void PerformMovement(Position origin, Position Destiny) {
            Piece p = Board.RemovePart(origin);
            p.IncreaseQtyMovement();
            Piece capturePiece = Board.RemovePart(Destiny);
            Board.AddPart(p, Destiny);
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