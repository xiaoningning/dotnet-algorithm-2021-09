public class Solution {
    // binary search T: O(nlogn)
    public int SmallestDistancePair1(int[] nums, int k) {
        int l = 0, r = nums.Max() - nums.Min() + 1, n = nums.Length;
        Array.Sort(nums); // sorting for binary search
        while (l < r) {
            int m = l + (r - l) / 2;
            int cnt = 0;
            for (int i = 0; i < n; i++) { // sorted => no need Math.Abs
                for (int j = i + 1; j < n && nums[j] - nums[i] <= m; j++) cnt++;
            }
            if (cnt < k) l = m + 1;
            else r = m;
        }
        return l;
    }
    // bucket counting T: O(n^2)
    public int SmallestDistancePair(int[] nums, int k) {
        int n = nums.Length;
        int[] cnt = new int[1000001];
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++) cnt[Math.Abs(nums[i] - nums[j])]++;
        for (int i = 0; i <= 1000000; i++) {
            if (cnt[i] >= k) return i;
            k -= cnt[i];
        }
        return -1;
    }
}
