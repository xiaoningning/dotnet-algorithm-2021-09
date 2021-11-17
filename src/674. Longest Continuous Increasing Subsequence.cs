public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        int ans = 1, cnt = 1, n = nums.Length;
        for (int i = 1; i < n; i++) {
            if (nums[i-1] < nums[i]) ans = Math.Max(ans, ++cnt);
            else cnt = 1;
        }
        return ans;
    }
}
