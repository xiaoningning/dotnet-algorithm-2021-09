public class Solution {
    // BFS
    public char[][] UpdateBoard(char[][] board, int[] click) {
        if (board.Length == 0 || board[0].Length == 0) return board;
        int m = board.Length, n = board[0].Length, r = click[0], c = click[1];
        // 8 directions !!!
        int[,] dirs = new int[,]{{1,0},{-1,0},{0,1},{0,-1}, {1,1}, {-1,-1}, {1,-1}, {-1,1}};
        var q = new Queue<(int,int)>();
        q.Enqueue((r,c));
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                int i = t.Item1, j = t.Item2, cnt = 0;
                if (board[i][j] != 'E') continue; // visited or 'M'
                // find mine first
                for (int d = 0; d < 8; d++) {
                    int x = i + dirs[d,0], y = j + dirs[d,1];
                    if (x >= 0 && x < m && y >= 0 && y < n && board[x][y] == 'M') cnt++;
                }
                if (cnt > 0) { board[i][j] = (char)(cnt + '0'); continue; }
                // update E and add to q for next level
                board[i][j] = 'B';
                for (int d = 0; d < 8; d++) {
                    int x = i + dirs[d,0], y = j + dirs[d,1];
                    if (x >= 0 && x < m && y >= 0 && y < n && board[x][y] == 'E') q.Enqueue((x,y));
                }
            }
        }
        if (board[r][c] == 'M') board[r][c] = 'X';
        return board;
    }
}
