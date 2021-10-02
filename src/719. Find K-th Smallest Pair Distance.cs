public class Solution {
    // binary search T: O(nlogn)
    public int SmallestDistancePair(int[] nums, int k) {
        int l = 0, r = nums.Max() - nums.Min() + 1, n = nums.Length;
        Array.Sort(nums); // without sort, it needs to count all.
        while (l < r) {
            int m = l + (r - l) / 2;
            int cnt = 0;
            for (int i = 0; i < n; i++) {
                for (int j = i + 1; j < n && nums[j] - nums[i] <= m; j++) cnt++;
            }
            if (cnt < k) l = m + 1;
            else r = m;
        }
        return l;
    }
}
