public class Solution {
    // monotonic queue
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        var ans = new List<int>();
        var q = new List<int>();
        for (int i = 0; i < n; i++) {
            while (q.Any() && nums[q.Last()] <= nums[i]) q.RemoveAt(q.Count - 1);
            q.Add(i);
            if (i - (k - 1) >= 0) ans.Add(nums[q.First()]);
            if (i - (k - 1) >= q.First()) q.RemoveAt(0);
        }
        return ans.ToArray();
    }
}
