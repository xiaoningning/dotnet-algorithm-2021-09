public class Solution {
    // DP v1
    // T: O(m*n) S: O(m*n)
    public int MinPathSum2(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i <= m; i++) for (int j = 0; j <= n; j++) dp[i,j] = Int32.MaxValue;
        dp[1,1] = grid[0][0];
        for (int i = 1; i <= m; i++) 
            for (int j = 1; j <= n; j++)
                dp[i,j] = grid[i-1][j-1] + (i == 1 && j == 1 ? 0 : Math.Min(dp[i-1,j], dp[i, j-1]));
        return dp[m,n];
    }
    // DP v2 similar to LC. 931
    // T: O(m*n) S: O(1)
    public int MinPathSum3(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++) 
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) continue;
                if (i == 0) grid[i][j] += grid[i][j-1];
                else if (j == 0) grid[i][j] += grid[i-1][j];
                else grid[i][j] += Math.Min(grid[i][j-1], grid[i-1][j]);
            }
        return grid[m-1][n-1];
    }
    // recursion + memo
    public int MinPathSum5(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[,] memo = new int[m, n]; // grid is all positive val
        Func<int,int, int> DFS = null;
        DFS = (i, j) => {
            if (i < 0 || j < 0) return Int32.MaxValue;
            if (i == 0 && j == 0) return memo[i,j] = grid[i][j];
            if (memo[i, j] != 0) return memo[i,j];
            return memo[i, j] = grid[i][j] + Math.Min(DFS(i - 1,j), DFS(i, j - 1));
        };
        return DFS(m - 1, n - 1);
    }
    // even with dist still => TLE
    // DFS is easy to get the full path
    public int MinPathSum4(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var dist = new int[m,n];
        for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) dist[i,j] = Int32.MaxValue;
        dist[0,0] = 0;
        var dirs = new int[,]{{1,0},{0,1}};
        int mn = Int32.MaxValue;
        var ans = new List<(int,int)>();
        Action<int,int,int,List<(int,int)>> DFS = null;
        DFS = (i, j, w, cur) =>{
            if (i == m - 1 && j == n - 1) {
                if (w < mn) { 
                    mn = w; 
                    ans = new List<(int,int)>(cur);
                }
                return;
            }
            for (int d = 0; d < 2; d++) {
                int ni = i + dirs[d,0], nj = j + dirs[d, 1];
                if (ni >= m || nj >= n || dist[ni,nj] < w + grid[ni][nj]) continue;
                dist[ni,nj] = w + grid[ni][nj]; // pruning !!!
                cur.Add((ni,nj)); 
                DFS(ni, nj, dist[ni,nj], cur);
                cur.RemoveAt(cur.Count - 1); // back track the path
            }
        };
        DFS(0,0,grid[0][0], new List<(int, int)>() { (0, 0) });
        return mn;
    }
    // DP with path => PASSed !!!
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i <= m; i++) for (int j = 0; j <= n; j++) dp[i,j] = Int32.MaxValue;
        dp[1,1] = grid[0][0];
        for (int i = 1; i <= m; i++) 
            for (int j = 1; j <= n; j++)
                dp[i,j] = grid[i-1][j-1] + (i == 1 && j == 1 ? 0 : Math.Min(dp[i-1,j], dp[i, j-1]));
        
        // track path based on DP min value
        var ans = new List<(int, int)>();
        int x = m, y = n;
        while (x > 0 && y > 0)
        {
            ans.Insert(0, (x - 1, y - 1));
            if (dp[x - 1, y] < dp[x, y - 1]) x--;
            else y--;
        }
        Console.WriteLine(string.Join(",", ans));
        return dp[m,n];
    }
}
