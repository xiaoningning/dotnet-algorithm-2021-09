public class Solution {
    public int NumTrees(int n) {
        int[] dp = new int[n+1];
        dp[0] = dp[1] = 1; // null or one node
        for (int i = 2; i <= n; i++) {
            for (int j = 0; j < i; j++)
                // root: 1 node; left: j nodes; right: i – j – 1 nodes
                dp[i] += dp[j] * dp[i- j - 1];
        }
        return dp[n];
    }
}
