public class Solution {
    // DFS bit mask. BFS => NOT find all paths
    // DFS := track count then it could not do memo since it does not have path (state)
    // T: (4^(m*n)) S: O(m*n)
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
                if ((s & (1 << nxi * n + nxj)) > 0) continue; // state to track visited on the path
                DFS(nxi, nxj, s | (1 << nxi * n + nxj));
            }
        };
        DFS(sx, sy, 0);
        return ans;
    }
    // DFS + memo bit mask. BFS => NOT find all paths
    // memo tracking back takes much LONGER time!!! => no memo is BETTER
    // T: (m*n*2^(m*n)) S: O(m*n*2^(m*n))
    public int UniquePathsIII2(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, state = 0;
        int sx = -1, sy = -1;
        int[,] dirs = new int[,]{{0,1}, {0,-1}, {1,0}, {-1,0}};
        var q = new Queue<(int,int,int)>();
        for (int i = 0; i< m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) { sx = i; sy = j; }
                if (grid[i][j] == 2 || grid[i][j] == 0) state |= 1 << (i * n + j);
            }
        }
        int[,,] memo = new int[m,n, 1 << m*n];
        for (int i = 0; i< m; i++) 
            for (int j = 0; j < n; j++)
                for (int s = 0; s < 1 << m*n; s++) memo[i,j,s] = -1;
        Func<int,int,int, int> DFS = null;
        DFS = (i,j,s) => {
            if (memo[i,j,s] != -1) return memo[i,j,s];
            if (grid[i][j] == 2) return Convert.ToInt32(s == state);
            int cnt = 0;
            for (int d = 0; d < 4; d++) {
                int nxi = i + dirs[d,0], nxj = j + dirs[d,1];
                if (nxi < 0 || nxi >= m || nxj < 0 || nxj >= n || grid[nxi][nxj] == -1) continue;
                if ((s & (1 << nxi * n + nxj)) > 0) continue;
                cnt += DFS(nxi, nxj, s | (1 << nxi * n + nxj));
            }
            return memo[i,j,s] = cnt;
        };
        return DFS(sx, sy, 0);
    }
}
