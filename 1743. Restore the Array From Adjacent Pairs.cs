public class Solution {
    public int[] RestoreArray(int[][] adjacentPairs) {
        int n = adjacentPairs.Length + 1;
        var g = new Dictionary<int, List<int>>();
        foreach (var a in adjacentPairs) {
            if (!g.ContainsKey(a[0])) g[a[0]] = new List<int>();
            if (!g.ContainsKey(a[1])) g[a[1]] = new List<int>();
            g[a[0]].Add(a[1]);
            g[a[1]].Add(a[0]);
        }
        var ans = new int[n];
        foreach (var kv in g) {
            if (kv.Value.Count == 1) {
                ans[0] = kv.Key;
                ans[1] = kv.Value[0];
                break;
            }
        }
        for (int i = 2; i < n; i++) {
            var v = g[ans[i-1]];
            ans[i] = v[0] == ans[i-2] ? v[1] : v[0];
        }
        return ans;
    }
}
