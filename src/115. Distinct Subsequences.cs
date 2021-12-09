public class Solution {
    // DP T: O(n^2) S: O(n^2)
    public int NumDistinct1(string s, string t) {
        int m = s.Length, n = t.Length;
        // dp[i,j] # of seq of t[1, i] == s[1, j]
        var dp = new int[n + 1, m + 1];
        for (int j = 0; j < m; j++) dp[0, j] = 1; // t ="", "" is 1 of subseq
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                // if t[i] == s[j] => match t[i], s[j] or skip s[j]
                // if t[i] != s[j] => only skip s[j]
                dp[i,j] = dp[i, j - 1] + (t[i - 1] == s[j - 1] ? dp[i-1, j-1] : 0);
            }
        }
        return dp[n, m];
    }
    // DP T: O(n^2) S: O(n)
    public int NumDistinct(string s, string t) {
        int m = s.Length, n = t.Length;
        var dp = new int[m + 1];
        // dp[0] = 1; // t ="", "" is 1 of subseq
        Array.Fill(dp, 1);
        for (int i = 1; i <= n; i++) {
            var cur = new int[m + 1];
            for (int j = 1; j <= m; j++) {
                cur[j] = cur[j-1] + (t[i - 1] == s[j - 1] ? dp[j-1] : 0);
            }
            dp = cur;
        }
        return dp[m];
    }
}
