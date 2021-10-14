public class Solution {
    // DFS
    public int MinTransfers(int[][] transactions) {
        var d = new Dictionary<int,int>();
        foreach (var t in transactions) {
            if (!d.ContainsKey(t[0])) d[t[0]] = 0;
            if (!d.ContainsKey(t[1])) d[t[1]] = 0;
            d[t[0]] -= t[2];
            d[t[1]] += t[2];
        }
        var users = new List<int>();
        foreach (var kv in d) if (kv.Value != 0) users.Add(kv.Key);
        int ans = Int32.MaxValue, n = users.Count;
        Action<int, int> DFS = null;
        DFS = (start, cnt) => {
            while (start < n && d[users[start]] == 0) start++;
            if (start == n) {
                ans = Math.Min(ans, cnt);
                return;
            }
            for (int i = start + 1; i < n; i++) {
                if (d[users[i]] * d[users[start]] < 0) {
                    d[users[i]] += d[users[start]];
                    DFS(start + 1, cnt + 1);
                    d[users[i]] -= d[users[start]];
                }
            }
        };
        DFS(0,0);
        return ans;
    }
}
