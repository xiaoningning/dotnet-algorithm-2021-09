public class Solution {
    // recursion + memo
    // T: O(n^2) S: O(n^2)
    public double ProbabilityOfHeads1(double[] prob, int target) {
        int n = prob.Length;
        double[,] memo = new double[n, target + 1];
        for (int i = 0; i < n; i ++) for (int j = 0; j <= target; j++) memo[i,j] = -1.0;
        Func<int, int, double> f = null;
        f = (i, t) => {
            // 0 <= target <= prob.length
            // i := 0-based, t := 1-based
            // target == 0 => not head
            if (t < 0 || t > i + 1) return 0.0;
            if (i < 0) return 1.0;
            if (memo[i, t] != -1) return memo[i,t];
            double p = prob[i];
            return memo[i,t] =  p * f(i - 1, t - 1) + (1 - p) * f(i - 1, t);
        };
        return f(n - 1, target);
    }
    public double ProbabilityOfHeads2(double[] prob, int target) {
        int n = prob.Length;
        // prob of i coin with j target
        double[] dp = new double[target+1];
        dp[0] = 1.0;
        for (int i = 0; i < n; i++) 
            // need prev i prob[i] at j - 1 coins => start with target to 0
            // 0 <= target <= prob.length
            for (int j = Math.Min(i + 1, target); j >= 0; j--)
                dp[j] = (1 - prob[i]) * dp[j] + (j > 0 ? dp[j-1] : 0) * prob[i]; 
        return dp[target];
    }
    public double ProbabilityOfHeads(double[] prob, int target) {
        int n = prob.Length;
        // prob of i coin with j head target
        double[,] dp = new double[n + 1, target + 1];
        dp[0, 0] = 1.0;
        // target == 0 := not head
        for (int i = 1; i <= n; i++) dp[i,0] = dp[i-1, 0] * (1 - prob[i - 1]);
        for (int i = 1; i <= n; i++) 
            for (int j = 1; j <= Math.Min(i, target); j++) // i moves to 1-based
                dp[i,j] = (1 - prob[i - 1]) * dp[i - 1, j] +  prob[i - 1] * dp[i - 1, j - 1]; 
        return dp[n, target];
    }
}
