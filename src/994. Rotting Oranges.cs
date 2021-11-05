public class Solution {
    // BFS
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, freshCnt = 0;
        var dirs = new int[,]{{1,0},{-1,0},{0,1},{0,-1}};
        var q = new Queue<(int,int)>();
        for (int i = 0; i < m; i++) for (int j= 0; j < n; j++) { 
            if (grid[i][j] == 2) q.Enqueue((i,j));
            if (grid[i][j] == 1) freshCnt++;
        }
        int ans = 0;
        while (q.Any() && freshCnt > 0) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                int x = t.Item1, y = t.Item2;
                for (int d = 0; d < 4; d++) {
                    int nx = x + dirs[d,0], ny = y + dirs[d,1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[nx][ny] != 1) continue;
                    grid[nx][ny] = 2;
                    q.Enqueue((nx,ny));
                    freshCnt--;
                }
            }
            ans++;
        }
        return freshCnt != 0 ? -1 : ans;
    }
}
