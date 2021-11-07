public class Solution {
    // similar to LC. 692
    // bucket sort 
    // T: O(n)
    public int[] TopKFrequent1(int[] nums, int k) {
        var cnt = new Dictionary<int,int>();
        int mx = 0;
        foreach (var n in nums) {
            if (!cnt.ContainsKey(n)) cnt[n] = 0;
            cnt[n]++; mx = Math.Max(mx, cnt[n]);
        }
        var bucket = new Dictionary<int, List<int>>();
        foreach (var kv in cnt) {
            if (!bucket.ContainsKey(kv.Value)) bucket[kv.Value] = new List<int>();
            bucket[kv.Value].Add(kv.Key);
        }
        var ans = new List<int>();
        for (int i = mx; i >= 1; i--) {
            if (!bucket.ContainsKey(i)) continue;
            foreach (var x in bucket[i]) { 
                ans.Add(x);
                if (ans.Count == k) return ans.ToArray();
            }
        }
        return ans.ToArray();
    }
    // sort by freq or priority queue of freq
    // T: O(nlogn)
    public int[] TopKFrequent(int[] nums, int k) {
        var cnt = new Dictionary<int,int>();
        foreach (var n in nums) {
            if (!cnt.ContainsKey(n)) cnt[n] = 0;
            cnt[n]++;
        }
        var q = new List<(int,int)>(); // priority queue
        foreach (var kv in cnt) q.Add((kv.Key, kv.Value));
        q.Sort((x,y) => y.Item2 - x.Item2);
        var ans = new List<int>();
        for (int i = 0; i < k; i++) ans.Add(q[i].Item1);
        return ans.ToArray();
    }
}
