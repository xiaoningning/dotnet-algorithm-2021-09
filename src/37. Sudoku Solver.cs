public class Solution {
    // DFS
    public void SolveSudoku(char[][] board) {
        Func<int,int,char,bool> isValid = (i,j,c) => {
            for (int k = 0; k < 9; k++) if (board[i][k] == c || board[k][j] == c) return false;
            int row = (i / 3) * 3, col = (j / 3) * 3;
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    if (board[row + x][col + y] == c) return false;
            return true;
        };
        Func<int,int,bool> DFS = null;
        DFS = (i,j) => {
            if (i == 9) return true; // reach the end
            if (j == 9) return DFS(i+1, 0); // next i
            if (board[i][j] != '.') return DFS(i, j + 1); // next j in the same row
            for (char c = '1'; c <= '9'; c++) {
                if (!isValid(i,j,c)) continue;
                board[i][j] = c;
                if (DFS(i, j + 1)) return true; // next j in the same row
                board[i][j] = '.';
            }
            return false; // 1...9 false, it should be as '.'
        };
        DFS(0,0);
    }
}
