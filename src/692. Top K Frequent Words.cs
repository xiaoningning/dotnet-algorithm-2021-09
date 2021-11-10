public class Solution {
    // priority queue T: O(nlogk)
    public IList<string> TopKFrequent1(string[] words, int k) {
        var freq = new Dictionary<string, int>();
        foreach (var w in words) {
            if (!freq.ContainsKey(w)) freq[w] = 0;
            freq[w]++;
        }
        var pq = new List<(string, int)>();
        foreach (var kv in freq) { // should code binary insert
            pq.Add((kv.Key, kv.Value));
            pq.Sort((x,y) => x.Item2 == y.Item2 ? x.Item1.CompareTo(y.Item1) : y.Item2 - x.Item2);
            if (pq.Count > k) pq.RemoveAt(pq.Count - 1);
        }
        var ans = new List<string>();
        for (int i = 0; i < k; i++) ans.Add(pq[i].Item1);
        return ans;
    }
    // bucket sort 
    // T: O(n)
    public IList<string> TopKFrequent(string[] words, int k) {
        var freq = new Dictionary<string, int>();
        foreach (var w in words) {
            if (!freq.ContainsKey(w)) freq[w] = 0;
            freq[w]++;
        }
        var bucket = new Dictionary<int, List<string>>();
        foreach (var kv in freq) {
            if (!bucket.ContainsKey(kv.Value)) bucket[kv.Value] = new List<string>();
            bucket[kv.Value].Add(kv.Key);
        }
        int mx = freq.Values.ToList().Max();
        var ans = new List<string>();
        for (int i = mx; i >= 1; i--) {
            if (!bucket.ContainsKey(i)) continue;
            foreach (var x in bucket[i].OrderBy(x => x)) { 
                ans.Add(x);
                if (ans.Count == k) return ans;
            }
        }
        return ans;
    }
}
