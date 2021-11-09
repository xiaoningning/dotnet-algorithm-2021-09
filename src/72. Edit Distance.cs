public class Solution {
    // DP
    public int MinDistance(string word1, string word2) {
        int w1l = word1.Length, w2l = word2.Length;
        var dp = new int[w1l + 1, w2l + 1];
        for (int i = 0; i <= w1l; i++) dp[i, 0] = i;
        for (int j = 0; j <= w2l; j++) dp[0, j] = j;
        for (int i = 1; i <= w1l; i++) {
            for (int j = 1; j <= w2l; j++) {
                if (word1[i - 1] == word2[j - 1]) dp[i,j] = dp[i - 1, j - 1];
                else dp[i, j] = new int[]{dp[i - 1, j], dp[i, j - 1], dp[i - 1, j - 1]}.Min() + 1; // insert/delete/replace
            }
        }
        return dp[w1l, w2l];
    }
}
