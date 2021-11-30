public class Solution {
    // DP T: O(m*n)
    // dp[i][j] = dp[i - 1][j] + dp[i][j - 1]
    public int UniquePaths(int m, int n) {
        var dp = new int[n];
        Array.Fill(dp, 1); // init each cell as 1 
        for (int i = 1; i < m; i++) for (int j = 1; j < n; j++) dp[j] += dp[j - 1];
        return dp[n-1];
    }
}
