public class Solution {
    // BFS
    public void WallsAndGates(int[][] rooms) {
        int m = rooms.Length, n = rooms[0].Length;
        var dirs = new int[,] {{1,0},{-1,0},{0,1},{0,-1}};
        var q = new Queue<int[]>();
        for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) if (rooms[i][j] == 0) q.Enqueue(new int[]{i,j});
        while (q.Any()) {
            var t = q.Dequeue();
            var val = rooms[t[0]][t[1]];
            for (int d = 0; d < 4; d++) {
                int x = t[0] + dirs[d,0], y = t[1] + dirs[d,1];
                if (x < 0 || x >= m || y < 0 || y >= n || rooms[x][y] < val + 1) continue;
                rooms[x][y] = val + 1;
                q.Enqueue(new int[]{x,y});
            }
        }
    }
    // DFS TLE
    public void WallsAndGates1(int[][] rooms) {
        int m = rooms.Length, n = rooms[0].Length;
        Action<int,int,int> DFS = null;
        DFS = (x,y,val) => {
            if (x < 0 || x >= m || y < 0 || y >= n || rooms[x][y] < val) return;
            rooms[x][y] = val;
            DFS(x + 1, y, val + 1);
            DFS(x - 1, y, val + 1);
            DFS(x, y + 1, val + 1);
            DFS(x, y - 1, val + 1);
        };
        for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) if (rooms[i][j] == 0) DFS(i, j, 0);
    }
}
