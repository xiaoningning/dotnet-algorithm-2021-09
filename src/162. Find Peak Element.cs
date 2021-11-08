public class Solution {
    // T: O(n)
    public int FindPeakElement1(int[] nums) {
        int n = nums.Length;
        if (n == 1) return 0;
        var nx = new int[n+2];
        Array.Copy(nums, 0, nx, 1, n);
        nx[0] = Int32.MinValue;
        nx[n+1] = Int32.MinValue;
        for (int i = 1; i < nx.Length - 1; ++i) if (nx[i] > nx[i - 1] && nx[i] > nx[i + 1]) return i - 1;
        return -1;
    }
    // T: O(logn)
    public int FindPeakElement(int[] nums) {
        int l = 0, r = nums.Length - 1;
        // must be have one peak element to use binary search
        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] < nums[m + 1]) l = m + 1;
            else r = m;
        }
        return r;
    }
}
