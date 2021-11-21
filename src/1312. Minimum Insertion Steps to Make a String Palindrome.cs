public class Solution {
    // LC. 1143, LC. 516
    // Find the the longest common sequence between s1 and s2,
    // where s1 = s and s2 = reversed(s)
    public int MinInsertions(string s) {
        int n = s.Length;
        var dp = new int[n + 1,n + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++)
                dp[i + 1,j + 1] = s[i] == s[n - 1 - j] ? 1 + dp[i,j] : Math.Max(dp[i+1,j], dp[i, j+1]);
        }
        return n - dp[n,n];
    }
}
