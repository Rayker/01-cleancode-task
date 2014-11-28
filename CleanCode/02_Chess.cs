namespace CleanCode
{
    public class Chess
    {
        private readonly Board board;

        public Chess(Board board)
        {
            this.board = board;
        }

        public string GetWhiteStatus()
        {
            bool checkNow = CheckForWhite();
            foreach (Loc from in board.Figures(Cell.White))
            {
                foreach (Loc to in board.Get(from).Figure.Moves(from, board))
                {
                    Cell oldFigure = board.PerformMove(from, to);
                    if (!CheckForWhite())
                        return checkNow ? "check" : "ok";
                    board.PerformUndoMove(from, to, oldFigure);
                }
            }
            return checkNow ? "mate" : "stalemate";
        }

        private bool CheckForWhite()
        {
            foreach (Loc from in board.Figures(Cell.Black))
            {
                foreach (Loc to in board.Get(from).Figure.Moves(from, board))
                {
                    if (board.Get(to).IsWhiteKing)
                        return true;
                }
            }
            return false;
        }
    }
}