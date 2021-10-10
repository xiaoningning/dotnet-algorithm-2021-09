public class Solution {
    // Floyd-Warshall dist[i, j] = dist[i, x] + dist[x, j]
    // T: O(n^3)
    public int FindTheCity1(int n, int[][] edges, int distanceThreshold) {
        int kMx = Int32.MaxValue / 2;
        int[,] dist = new int[n, n];
        for (int i = 0; i < n ; i++) for (int j = 0; j < n; j++) dist[i, j] = kMx;
        for (int i = 0; i < n ; i++) dist[i,i] = 0;
        foreach (int[] e in edges) dist[e[0], e[1]] = dist[e[1], e[0]] = e[2]; 
        for (int x = 0; x < n ; x++) 
            for (int i = 0; i < n ; i++) 
                for (int j = 0; j < n; j++)
                    dist[i,j] = Math.Min(dist[i, j], dist[i,x] + dist[x,j]);
        var cnt = new int[n];
        for (int i = 0; i < n ; i++) for (int j = 0; j < n; j++) if (dist[i,j] <= distanceThreshold) cnt[i]++;
        int mn = cnt.Min();
        int ans = -1;
        for (int i = 0; i < n ; i++) if (cnt[i] == mn) ans = i;
        return ans;
    }
    // Bellman-Ford dist[t] = Math.Min(dist[t], w + dist[s]) T: O(V*E)
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int kMx = Int32.MaxValue / 2;
        var g = new Dictionary<int, List<(int,int)>>();
        for (int i = 0; i < n ; i++) g[i] = new List<(int,int)>();
        foreach (int[] e in edges) {
            g[e[0]].Add((e[1], e[2]));
            g[e[1]].Add((e[0], e[2]));
        }
        Func<int, List<int>> DFS = null;
        DFS = (x) => {
            int[] dist = new int[n];
            Array.Fill(dist, kMx);
            dist[x] = 0;
            var q = new Queue<int>();
            q.Enqueue(x);
            while (q.Any()) {
                var t = q.Dequeue();
                if (dist[t] > distanceThreshold) continue; // pruning
                foreach (var nx in g[t]) {
                    if (dist[t] + nx.Item2 > dist[nx.Item1]) continue;
                    dist[nx.Item1] = dist[t] + nx.Item2;
                    q.Enqueue(nx.Item1);
                }
            }
            var ans = new List<int>();
            for (int i = 0; i < n; i++) if (dist[i] <= distanceThreshold) ans.Add(i);
            return ans;
        };
        int mn = Int32.MaxValue, ans = -1;
        for (int i = 0; i < n; i++) {
            int cnt = DFS(i).Count;
            if (cnt <= mn) {
                mn = cnt;
                ans = i;
            }
        }
        return ans;
    }
}
