public class Solution {
    // Similar to LC. 64 LC. 931
    // dp[i][j] = max(dp[i - 1][k] + point[i][j] - abs(j - k)) for each 0 <= k < points[i - 1].szie()
    // T: O(m * n * n)
    // dp[i][j] = max(dp[i - 1][k] + k) + points[i][j] - j for all 0 <= k <= j
    // dp[i][j] = max(dp[i - 1][k] - k) + points[i][j] + j for all j <= k <= points[i].size() - 1
    // T: O(m * n)
    public long MaxPoints(int[][] points) {
        int m = points.Length, n = points[0].Length;
        var prev = new long[n]; // long since it can be big over int32
        for (int j = 0; j < n; j++) prev[j] = points[0][j];
        for (int i = 1; i < m; i++) {
            long[] cur = new long[n], left = new long[n], right = new long[n];
            left[0] = prev[0];
            for (int j = 1; j < n; j++) left[j] = Math.Max(left[j - 1] - 1, prev[j]);
            right[n-1] = prev[n - 1];
            for (int j = n - 2; j >= 0; j--) right[j] = Math.Max(right[j + 1] - 1, prev[j]);
            for (int j = 0; j < n; j++) cur[j] = points[i][j] + Math.Max(left[j], right[j]);
            prev = cur;
        }
        return prev.Max();
    }
    // TLE
    public long MaxPoints2(int[][] points) {
        int m = points.Length, n = points[0].Length;
        var dp = new long[m, n];
        for (int j = 0; j < n; j++) dp[0,j] = points[0][j];
        for (int i = 1; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    dp[i,j] = Math.Max(dp[i,j], dp[i - 1, k] - Math.Abs(k - j) + points[i][j]);
        
        long ans = -1;
        for (int j = 0; j < n; j++) ans = Math.Max(ans, dp[m - 1, j]);
        return ans;
    }
}
