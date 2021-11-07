public class Solution {
    // T: O(n), S: O(n)
    public int FindShortestSubArray(int[] nums) {
        var pos = new Dictionary<int,List<int>>();
        for (int i = 0; i < nums.Length; i++) {
            if (!pos.ContainsKey(nums[i])) pos[nums[i]] = new List<int>();
            pos[nums[i]].Add(i);
        }
        int ans = nums.Length, mx = 0;
        foreach (var kv in pos) mx = Math.Max(mx, kv.Value.Count);
        foreach (var kv in pos) 
            if (mx == kv.Value.Count)
                ans = Math.Min(ans, kv.Value.Last() - kv.Value.First() + 1);
        return ans;
    }
}
