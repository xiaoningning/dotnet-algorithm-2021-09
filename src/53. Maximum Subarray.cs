public class Solution {
    // DP
    public int MaxSubArray1(int[] nums) {
        int n = nums.Length;
        var dp = new int[n];
        dp[0] = nums[0];
        for (int i = 1; i < n; i++) dp[i] = Math.Max(dp[i-1] + nums[i], nums[i]);
        return dp.Max();
    }
    // DP v2 save space
    public int MaxSubArray(int[] nums) {
        int ans = Int32.MinValue, mx = 0;
        foreach (var n in nums) {
            mx = Math.Max(mx + n, n);
            ans = Math.Max(ans, mx);
        } 
        return ans;
    }
}
