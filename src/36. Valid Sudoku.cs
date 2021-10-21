public class Solution {
    public bool IsValidSudoku(char[][] board) {
        for (int i = 0; i < 9; i++) {
            var row = new HashSet<char>();
            var col = new HashSet<char>();
            for (int j = 0; j < 9; j++) {
                if (board[i][j] != '.' && !row.Add(board[i][j])) return false;
                // col := reverse i and j
                if (board[j][i] != '.' && !col.Add(board[j][i])) return false;
            }
        }
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++) {
                var cell = new HashSet<char>();
                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        if (board[x * 3 + i][y * 3 + j] != '.' && !cell.Add(board[x * 3 + i][y * 3 + j])) return false;
                    }
                }
            }
        return true;
    }
}
