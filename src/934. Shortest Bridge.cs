public class Solution {
    // DFS + BFS => just one queue
    public int ShortestBridge2(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var dirs = new int[4,2]{{1,0},{-1,0},{0,1},{0,-1}};
        var q = new Queue<(int,int)>();
        Action<int,int> DFS = null;
        DFS = (sx,sy) => {
            if (sx < 0 || sx >= m || sy < 0 || sy >= n || grid[sx][sy] != 1) return;
            grid[sx][sy] = 2;
            q.Enqueue((sx,sy));
            for (int d = 0; d < 4; d++) DFS(sx + dirs[d,0], sy + dirs[d,1]);
        };
        bool found = false;
        for (int i = 0; i < m && !found; i++)
            for (int j = 0; j < n && !found; j++)
                if (grid[i][j] == 1) { DFS(i,j); found = true; }
        
        int cnt = 0;
        while (q.Any()) {
            int size = q.Count();
            while (--size >= 0) {
                var t = q.Dequeue();
                int x = t.Item1, y = t.Item2;
                for (int d = 0; d < 4; d++) {
                    int nx = x + dirs[d,0], ny = y + dirs[d,1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[nx][ny] == 2) continue;
                    if (grid[nx][ny] == 1) return cnt;
                    grid[nx][ny] = 2;
                    q.Enqueue((nx,ny));
                }
            }
            cnt++;
        }
        return -1;
    }
    // BFS => two queues
    public int ShortestBridge(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var dirs = new int[4,2]{{1,0},{-1,0},{0,1},{0,-1}};
        var q = new Queue<(int,int)>();
        var q2 = new Queue<(int,int)>();
        bool found = false;
        for (int i = 0; i < m && !found; i++)
            for (int j = 0; j < n && !found; j++)
                if (grid[i][j] == 1) { 
                    q.Enqueue((i,j));
                    q2.Enqueue((i,j));
                    grid[i][j] = 2; 
                    found = true; 
                }
        while (q.Any()) {
            var t = q.Dequeue();
            int x = t.Item1, y = t.Item2;
            for (int d = 0; d < 4; d++) {
                int nx = x + dirs[d,0], ny = y + dirs[d,1];
                if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[nx][ny] != 1) continue;
                grid[nx][ny] = 2;
                q.Enqueue((nx,ny));
                q2.Enqueue((nx,ny));
            }
        }
        int cnt = 0;
        while (q2.Any()) {
            int size = q2.Count();
            while (--size >= 0) {
                var t2 = q2.Dequeue();
                int x2 = t2.Item1, y2 = t2.Item2;
                for (int d = 0; d < 4; d++) {
                    int nx2 = x2 + dirs[d,0], ny2 = y2 + dirs[d,1];
                    if (nx2 < 0 || nx2 >= m || ny2 < 0 || ny2 >= n || grid[nx2][ny2] == 2) continue;
                    if (grid[nx2][ny2] == 1) return cnt;
                    grid[nx2][ny2] = 2;
                    q2.Enqueue((nx2,ny2));
                }
            }
            cnt++;
        }
        return -1;
    }
}
