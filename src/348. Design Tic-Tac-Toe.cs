public class TicTacToe {
    int[] rows;
    int[] cols;
    int diagonal = 0;
    int antiDiagonal = 0;
    int size = 0;
    public TicTacToe(int n) {
        rows = new int[n];
        cols = new int[n];
        size = n;
    }
    // 0 is no winner
    public int Move(int row, int col, int player) {
        int toAdd = player == 1 ? 1 : -1;
        rows[row] += toAdd;
        cols[col] += toAdd;
        if (row == col) diagonal += toAdd;
        if (col == (cols.Length - row - 1)) antiDiagonal += toAdd;

        if (Math.Abs(diagonal) == size
           || Math.Abs(antiDiagonal) == size
           || Math.Abs(rows[row]) == size
           || Math.Abs(cols[col]) == size) return player;
        
        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */
