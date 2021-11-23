public class Solution {
    // DFS
    public int LongestIncreasingPath(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var dirs = new int[,]{{1,0},{-1,0},{0,1},{0,-1}};
        var dp = new int[m, n];
        Func<int,int,int> dfs = null;
        dfs = (i,j) => {
            if (dp[i,j] != 0) return dp[i,j];
            dp[i,j] = 1; // itself
            for (int d = 0; d < 4; d++) {
                int ni = i + dirs[d,0], nj = j + dirs[d,1];
                if (ni < 0 || ni >= m || nj < 0 || nj >= n || matrix[ni][nj] <= matrix[i][j]) continue;
                dp[i,j] = Math.Max(dp[i,j], 1 + dfs(ni,nj));
            }
            return dp[i,j];
        };
        int ans = 0;
        for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) ans = Math.Max(ans, dfs(i,j));
        return ans;
    }
}
