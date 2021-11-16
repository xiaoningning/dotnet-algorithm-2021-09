public class Solution {
    // DP similar to LC. 1062 LC. 516 LC. 1092
    public int LongestCommonSubsequence(string text1, string text2) {
        int m = text1.Length, n = text2.Length;
        var dp = new int[m+1, n+1];
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (text1[i-1] == text2[j-1]) dp[i,j] = 1 + dp[i-1,j-1];
                else dp[i,j] = Math.Max(dp[i,j-1], dp[i-1, j]);
            }
        }
        return dp[m,n];
    }
}
