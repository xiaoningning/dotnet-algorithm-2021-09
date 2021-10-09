public class Solution {
    // a single source multiple path with weight to destination graph problem
    // Bellman-Ford v2
    // distance s => t in G := dist[t] = Math.Min(dist[t], w + dist[s]);
    // BFS T: O(V+E)
    public int NetworkDelayTime1(int[][] times, int n, int k) {
        var g = new Dictionary<int, List<(int,int)>>();
        for (int i = 1; i <= n; i++) g[i] = new List<(int,int)>();
        foreach (var t in times) g[t[0]].Add((t[1], t[2]));
        var q = new Queue<int>();
        q.Enqueue(k);
        int[] dist = new int[n+1];
        Array.Fill(dist, Int32.MaxValue / 2); // avoid overflow
        dist[k] = 0; dist[0] = 0; // track distance since it can be updated from different paths
        while (q.Any()) {
            var t = q.Dequeue();
            foreach (var nx in g[t]) {
                // no need to track visited
                // since as long as dist min, then no more update
                if (dist[nx.Item1] > nx.Item2 + dist[t]) {
                    dist[nx.Item1] = nx.Item2 + dist[t];
                    q.Enqueue(nx.Item1);
                }
            }
        }
        return dist.Max() != Int32.MaxValue / 2 ? dist.Max() : -1;
    }
    // Bellman-Ford v1 
    // DP T: O(V * E) dist[t] = Math.Min(dist[t], w + dist[s]);
    public int NetworkDelayTime2(int[][] times, int n, int k) {
        int kMx = Int32.MaxValue / 2;
        int[] dist = new int[n + 1];
        Array.Fill(dist, kMx);
        dist[k] = 0; dist[0] = 0;
        // dist as DP to track min dist of k->i
        // n round update to minize dist[i]
        for (int i = 1; i <= n; i++) {
            foreach (var t in times)
                dist[t[1]] = Math.Min(dist[t[1]], t[2] + dist[t[0]]);
        }
        return dist.Max() >= kMx ? -1 : dist.Max();
    }
    // Floyd-Warshall v1 : dist[i, j] > dist[i, x] + dist[x, j]
    // T: O(v^3) calculate all dist of i, j
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int kMx = Int32.MaxValue / 2;
        int[,] dist = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++) for (int j = 1; j <= n; j++) dist[i,j] = kMx;
        for (int i = 1; i <= n; i++) dist[i, i] = 0;
        foreach (var t in times) dist[t[0], t[1]] = t[2];
        // dist[i, j] > dist[i, x] + dist[x, j] => loop x first !!!
        for (int x = 1; x <= n; x++)
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    dist[i,j] = Math.Min(dist[i, j], dist[i,x] + dist[x,j]);
        int ans = 0;
        for (int i = 1; i <= n; i++) {
            if (dist[k,i] >= kMx) return -1;
            ans = Math.Max(ans, dist[k,i]);
        }
        return ans;
    }
}
