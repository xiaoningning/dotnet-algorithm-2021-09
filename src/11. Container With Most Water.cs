public class Solution {
    // search max area
    public int MaxArea(int[] height) {
        int l = 0, r = height.Length - 1, ans = 0;
        while (l < r) {
            ans = Math.Max(ans, (r - l) * Math.Min(height[l], height[r]));
            if (height[l] < height[r]) l++;
            else r--;
        }
        return ans;
    }
}
