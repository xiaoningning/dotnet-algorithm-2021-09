public class Solution {
    // TLE
    // T: O(ElogV) S: O(E+V)
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
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
            seen[u] = true;
            if (u == end) return d;
            foreach (var v in g[u]) {
                if ( seen[v.Item1] || v.Item2 * d < dist[v.Item1]) continue;
                dist[v.Item1] = v.Item2 * d;
                q.Add((v.Item1, v.Item2 * d));
                q.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            }
        }
        return dist[end];
    }
}
