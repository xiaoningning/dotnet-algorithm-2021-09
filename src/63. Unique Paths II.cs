public class Solution {
    // DP
    public int UniquePathsWithObstacles1(int[][] obstacleGrid) {
        if (obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0) return 0;
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        long[,] dp = new long[m,n]; // in case int32 overflow
        dp[0,0] = 1 - obstacleGrid[0][0]; // 1 or 0 at start point
        for (int i = 1; i < m; i++) dp[i, 0] = obstacleGrid[i][0] == 0 ? dp[i-1, 0]: 0;
        for (int j = 1; j < n; j++) dp[0, j] = obstacleGrid[0][j] == 0 ? dp[0, j-1]: 0;
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                if (obstacleGrid[i][j] == 1) continue;
                dp[i, j] = dp[i-1, j] + dp[i, j-1]; // down + left
            }
        }
        return (int)dp[m-1, n-1];
    }
    // recursion + memo
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if (obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0) return 0;
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        int[,] memo = new int[m, n];
        for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) memo[i, j] = -1;
        Func<int, int, int> f = null;
        f = (i, j) => {
            if (i < 0 || j < 0) return 0; // out of range
            if (i == 0 && j == 0) return memo[0, 0] = 1 - obstacleGrid[0][0]; // 1 or 0 at start point
            if (memo[i, j] != -1) return memo[i, j];
            if (obstacleGrid[i][j] == 1) return memo[i, j] = 0; // blocked
            else return memo[i, j] = f(i-1, j) + f(i, j-1);
        };
        return f(m-1, n-1);
    }
}
