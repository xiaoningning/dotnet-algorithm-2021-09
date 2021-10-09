public class Solution {
    // Bellman-Ford v1
    // DP := dp[t] = Math.Min(dp[t], w + dp[s]) T: O(V*E)
    public int FindCheapestPrice1(int n, int[][] flights, int src, int dst, int k) {
        int kMx = Int32.MaxValue / 2;
        // dp cost from src to i at UP to k stops 
        // at most k stops, dst + k => k + 1
        int[,] dp = new int[k + 2, n];
        for (int i = 0; i <= k + 1; i++) for (int j = 0; j < n; j++) dp[i,j] = kMx;
        dp[0, src] = 0; // only src price = 0
        for (int i = 1; i <= k + 1; i++) {
            dp[i, src] = 0; // src, price = 0
            foreach (var f in flights) 
                dp[i, f[1]] = Math.Min(dp[i, f[1]], f[2] + dp[i-1,f[0]]);
        }
        return dp[k + 1, dst] >= kMx ? -1 : dp[k + 1, dst];
    }
    // Bellman-Ford v2 save space
    // DP := dp[t] = Math.Min(dp[t], w + dp[s]) T: O(V*E)
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int kMx = Int32.MaxValue / 2;
        int[] cost = new int[n]; // dp to track min of cost to dest i
        Array.Fill(cost, kMx);
        cost[src] = 0; 
        for (int i = 1; i <= k + 1; i++) { // at most k stops, dst + k => k + 1
            int[] t = (int[])cost.Clone();
            foreach (var f in flights) t[f[1]] = Math.Min(t[f[1]], f[2] + cost[f[0]]);
            cost = t;
        }
        return cost[dst] >= kMx ? -1 : cost[dst];
    }
    // BFS T: O(n^ (k+1)) => TLE 
    public int FindCheapestPrice2(int n, int[][] flights, int src, int dst, int k) {
        var g = new Dictionary<int, List<(int,int)>>();
        for (int i = 0; i < n; i++) g[i] = new List<(int,int)>();
        foreach (var f in flights) g[f[0]].Add((f[1],f[2]));
        var q = new Queue<(int,int)>();
        q.Enqueue((src, 0));
        int ans = Int32.MaxValue;
        while (q.Any() && k + 1 >= 0) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                if (t.Item1 == dst) ans = Math.Min(ans, t.Item2);
                foreach (var nx in g[t.Item1]) {
                    if (nx.Item2 + t.Item2 > ans) continue; // prunning !!!
                    q.Enqueue((nx.Item1, nx.Item2 + t.Item2));
                }
            }
            k--;
        }
        return ans == Int32.MaxValue ? -1 : ans;
    }
}
