public class Solution {
    // Priority Queue
    // T: O(k*logk +  (n – k + 1)*logk)
    public double[] MedianSlidingWindow(int[] nums, int k) {
        var ans = new List<double>();
        var w = new List<int>(); // as priority queue
        for (int i = 0; i < k; i++) BinarySearchInsert(w, nums[i]);
        ans.Add(w[(k - 1) / 2] * 0.5 + w[k / 2] * 0.5);
        for (int i = k; i < nums.Length; i++) {
            w.Remove(nums[i - k]);
            BinarySearchInsert(w, nums[i]);
            ans.Add(w[(k - 1) / 2] * 0.5 + w[k / 2] * 0.5); // avoid int overflow
        }
        return ans.ToArray();
    }
    // Similar to LC. 295
    // two queues to balance small and large nums
    public double[] MedianSlidingWindow1(int[] nums, int k) {
        var ans = new List<double>();
        List<int> mn = new List<int>(), mx = new List<int>();
        for (int i = 0; i < nums.Length; i++) {
            if (i >= k) {
                if (mn.Contains(nums[i - k])) mn.Remove(nums[i - k]);
                else if (mx.Contains(nums[i - k])) mx.Remove(nums[i - k]);
            }
            if (mn.Count <= mx.Count) {
                if (!mx.Any() || nums[i] <= mx.First()) BinarySearchInsert(mn, nums[i]);
                else {
                    BinarySearchInsert(mn, mx.First());
                    mx.RemoveAt(0);
                    BinarySearchInsert(mx, nums[i]);
                }
            }
            else {
                if (nums[i] >= mn.Last()) BinarySearchInsert(mx, nums[i]);
                else {
                    BinarySearchInsert(mx, mn.Last());
                    mn.RemoveAt(mn.Count - 1);
                    BinarySearchInsert(mn, nums[i]);
                }
            }
            if (i + 1 >= k) {
                if (k % 2 != 0) ans.Add((double)mn.Last());
                else ans.Add(mn.Last() * 0.5 + mx.First() * 0.5); // avoid int overflow
            }
        }
        return ans.ToArray();
    }
    // O(logn) => priority queue insert
    void BinarySearchInsert(List<int> q, int v) {
        int l = 0, r = q.Count;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (q[m] <= v) l = m + 1;
            else r = m;
        }
        q.Insert(l, v);
    }
}
