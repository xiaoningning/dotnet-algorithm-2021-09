public class Solution {
    public int[] SortedSquares(int[] nums) {
        int n = nums.Length, l = 0, r = n - 1, i = n - 1;
        int[] ans = new int[n];
        while (i >= 0) { // better than check l <= r
            int mx = Math.Abs(nums[r]) > Math.Abs(nums[l]) ? nums[r--] : nums[l++];
            ans[i--] = mx * mx;
        }
        return ans;
    }
}
