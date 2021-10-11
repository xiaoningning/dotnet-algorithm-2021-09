public class Solution {
    // a multiple sources shortest path problem
    // DP T:(n * n * 2^n) => need to calculate all dist[i,j]
    // Floyd-Warshall to calculate dist := dist[i, j] = dist[i, x] + dist[x, j]
    // Bellman-Ford to calculate min dist := dist[t] = Math.Min(dist[t], w + dist[s])
    public int ShortestPathLength1(int[][] graph) {
        int n = graph.Length, kMx = Int32.MaxValue / 2;
        int[,] dist = new int[n, n];
        for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) dist[i, j] = kMx;
        for (int i = 0; i < n; i++) foreach (var e in graph[i]) dist[i, e] = dist[e, i] = 1;
        for (int x = 0; x < n; x++) 
            for (int i = 0; i < n; i++) 
                for (int j = 0; j < n; j++)
                    dist[i, j] = Math.Min(dist[i, j], dist[i,x] + dist[x, j]);
        // state : start from any node to visit all nodes path
        // dp := track the min dist of from i to the state path
        int[,] dp = new int[n, 1 << n];
        for (int i = 0; i < n; i++) for (int s = 0; s < 1 << n; s++) dp[i, s] = kMx;
        for (int i = 0; i < n; i++) dp[i, 1 << i] = 0;
        for (int s = 0; s < 1 << n; s++) {
            for (int i = 0; i < n; i++) {
                if ((s & (1 << i)) == 0) continue; // no i in the path
                for (int j = 0; j < n; j ++) {
                    if ((s & 1 << j) != 0) continue; // visit j already
                    dp[j, s | 1 << j] = Math.Min(dp[j, s | 1 << j], dp[i, s] + dist[i,j]);
                }
            }
        }
        int ans = kMx;
        for (int i = 0; i < n; i++) ans = Math.Min(ans, dp[i, (1 << n) - 1]);
        return ans; // all nodes are connected => it guarantees to have a result.
    }
    // BFS + bit mask T: O(n*2^n) S: O(n*2^n) := check the shortest path from each node, faster than DP
    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length, step = 0;
        var q = new Queue<(int, int)>();
        // start from all nodes to all other nodes for the shortest path
        for (int i = 0; i < n; i++) q.Enqueue((i, 1 << i));
        var visited = new HashSet<(int,int)>(); // track the path and node
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                if (t.Item2 == (1 << n) - 1) return step; // 1st to reach all nodes is the min steps
                foreach (int nx in graph[t.Item1]) {
                    if (visited.Contains((nx, t.Item2 | 1 << nx))) continue;
                    visited.Add((nx, t.Item2 | 1 << nx));
                    q.Enqueue((nx, t.Item2 | 1 << nx));
                }
            }
            step++;
        }
        return step;// should not reach here since all nodes are connected => it guarantees to have a result.
    }
}
