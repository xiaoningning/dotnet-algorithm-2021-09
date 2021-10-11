public class Solution {
    // DFS + bit mask. BFS => NOT find all paths
    public int UniquePathsIII(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, state = 0, ans = 0;
        int sx = -1, sy = -1;
        int[,] dirs = new int[,]{{0,1}, {0,-1}, {1,0}, {-1,0}};
        var q = new Queue<(int,int,int)>();
        for (int i = 0; i< m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) { sx = i; sy = j; }
                if (grid[i][j] == 2 || grid[i][j] == 0) state |= 1 << (i * n + j);
            }
        }
        Action<int,int,int> DFS = null;
        DFS = (i,j,s) => {
            if (grid[i][j] == 2) { ans += Convert.ToInt32(s == state); return; }
            for (int d = 0; d < 4; d++) {
                int nxi = i + dirs[d,0], nxj = j + dirs[d,1];
                if (nxi < 0 || nxi >= m || nxj < 0 || nxj >= n || grid[nxi][nxj] == -1) continue;
                if ((s & (1 << nxi * n + nxj)) > 0) continue;
                DFS(nxi, nxj, s | (1 << nxi * n + nxj));
            }
        };
        DFS(sx, sy, 0);
        return ans;
    }
}
