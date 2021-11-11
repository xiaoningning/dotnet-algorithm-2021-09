public class Solution {
    // Dijkstra + priority queue :=> TLE due to sort
    // T: O(ElogV) S: O(E+V)
    public double MaxProbability1(int n, int[][] edges, double[] succProb, int start, int end) {
        var g = new Dictionary<int, List<(int, double)>>();
        for (int i = 0; i < n; i++) g[i] = new List<(int, double)>();
        for (int i = 0; i < edges.Length; i++) {
            g[edges[i][0]].Add((edges[i][1], succProb[i]));
            g[edges[i][1]].Add((edges[i][0], succProb[i]));
        }
        var seen = new bool[n];
        var dist = new double[n];
        Array.Fill(dist, 0.0);
        var q = new List<(int, double)>(); // priority queue save some time
        q.Add((start, 1.0));
        while (q.Any()) {
            var t = q[0]; q.RemoveAt(0);
            int u = t.Item1;
            double d = t.Item2;
            if (u == end) return d;
            foreach (var v in g[u]) {
                if (v.Item2 * d < dist[v.Item1]) continue;
                dist[v.Item1] = v.Item2 * d;
                q.Add((v.Item1, v.Item2 * d));
                q.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            }
        }
        return 0;
    }
    // Bellman Ford Algorithm: BFS with Queue
    public double MaxProbability2(int n, int[][] edges, double[] succProb, int start, int end) {
        var g = new Dictionary<int, List<(int, double)>>();
        for (int i = 0; i < n; i++) g[i] = new List<(int, double)>();
        for (int i = 0; i < edges.Length; i++) {
            g[edges[i][0]].Add((edges[i][1], succProb[i]));
            g[edges[i][1]].Add((edges[i][0], succProb[i]));
        }
        var seen = new bool[n];
        var dist = new double[n];
        Array.Fill(dist, 0.0);
        var q = new List<(int, double)>(); // priority queue save some time
        q.Add((start, 1.0));
        while (q.Any()) {
            var t = q[0]; q.RemoveAt(0);
            int u = t.Item1;
            double d = t.Item2;
            foreach (var v in g[u]) {
                if ( v.Item2 * d < dist[v.Item1]) continue; // will reach the min and then stop
                dist[v.Item1] = v.Item2 * d;
                q.Add((v.Item1, v.Item2 * d));
            }
        }
        return dist[end];
    }
    // Floyd–Warshall Algorithm for Every Pair of Nodes => TLE
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        var prob = new double[n,n];
        for (int i = 0; i < succProb.Length; i++) {
            int u = edges[i][0];
            int v = edges[i][1];
            prob[u, v] = prob[v,u] = succProb[i];
        }
        for (int k = 0; k < n; k++){
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) prob[i,j] = Math.Max(prob[i,j], prob[i,k] * prob[k,j]);
            }
        }
        return prob[start,end];
    }
}
