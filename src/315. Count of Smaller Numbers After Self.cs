public class Solution {
    // binary search
    // T: O(nlogn)
    public IList<int> CountSmaller(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n];
        // keep a sorted list
        var dp = new List<int>();
        for (int i = n - 1; i >= 0; i--) {
            int l = 0, r = dp.Count;
            while (l < r) {
                int m = l + (r - l) / 2;
                if (dp[m] < nums[i]) l = m + 1;
                else r = m;
            }
            dp.Insert(r, nums[i]);
            ans[i] = r;
        }
        return ans;
    }
}
