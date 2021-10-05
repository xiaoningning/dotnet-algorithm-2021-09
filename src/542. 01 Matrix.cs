public class Solution {
    // BFS
    public int[][] UpdateMatrix(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        var dirs = new int[4,2]{{1,0},{-1,0},{0,1},{0,-1}};
        var q = new Queue<(int, int)>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 0) q.Enqueue((i,j));
                else mat[i][j] = m * n;
            }
        }
        while (q.Any()) {
            var t = q.Dequeue();
            int x = t.Item1, y = t.Item2;
            for (int d = 0; d < 4; d++) {
                int nx = x + dirs[d,0], ny = y + dirs[d,1];
                if (nx < 0 || nx >= m || ny < 0 || ny >= n || mat[nx][ny] <= mat[x][y]) continue;
                mat[nx][ny] = mat[x][y] + 1;
                q.Enqueue((nx,ny));
            }
        }
        return mat;
    }
}
