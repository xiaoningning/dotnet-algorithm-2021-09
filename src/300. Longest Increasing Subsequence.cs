public class Solution {
    // DP + Binary Search / Patience Sort
    // T: O(nlogn)
    public int LengthOfLIS(int[] nums) {
        // dp[i] the smallest num of tailing LIS
        var dp = new List<int>();
        foreach (var n in nums) {
            int l = 0, r = dp.Count;
            while (l < r) {
                int m = l + (r - l) / 2;
                if (dp[m] < n) l = m + 1;
                else r = m;
            }
            if (dp.Count == r) dp.Add(n);
            else dp[r] = n; // update, not insert
        }
        return dp.Count;
    }
}
