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
            seen[u] = true;
            foreach (var v in g[u]) {
                if (seen[v.Item1] || v.Item2 * d < dist[v.Item1]) continue;
                dist[v.Item1] = v.Item2 * d;
                q.Add((v.Item1, v.Item2 * d));
                q.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            }
        }
        return 0;
    }
    // Bellman Ford Algorithm: BFS with Queue
    // queue is faster than list.removeAt(0) !!!
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
        var q = new Queue<(int, double)>(); // priority queue save some time
        q.Enqueue((start, 1.0));
        while (q.Any()) {
            var t = q.Dequeue();
            int u = t.Item1;
            double d = t.Item2;
            foreach (var v in g[u]) {
                if ( v.Item2 * d <= dist[v.Item1]) continue; // will reach the min and then stop
                dist[v.Item1] = v.Item2 * d;
                q.Enqueue((v.Item1, v.Item2 * d));
            }
        }
        return dist[end];
    }
    // Floyd???Warshall Algorithm for Every Pair of Nodes => TLE
    public double MaxProbability2(int n, int[][] edges, double[] succProb, int start, int end) {
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
    /**
    max(P1*P2*???*Pn) => max(log(P1*P2???*Pn)) => max(log(P1) + log(P2) + ??? + log(Pn) => min(-(log(P1) + log(P2) ??? + log(Pn)).
    convert this problem to the classic single source shortest path problem with Dijkstra???s algorithm.

    Time complexity: O(ElogV)
    Space complexity: O(E+V)
    TLE !!! without priority queue, list sort is slow
    */
    public double MaxProbability3(int n, int[][] edges, double[] succProb, int start, int end) {
        var g = new Dictionary<int, List<(int, double)>>();
        for (int i = 0; i < n; i++) g[i] = new List<(int, double)>();
        for (int i = 0; i < edges.Length; i++) {
            var w = -Math.Log(succProb[i]);
            g[edges[i][0]].Add((edges[i][1], w));
            g[edges[i][1]].Add((edges[i][0], w));
        }
        var seen = new bool[n];
        var dist = new double[n];
        Array.Fill(dist, Double.MaxValue / 2);
        dist[start] = 0.0;
        var q = new List<(int, double)>();
        q.Add((start, 0.0));
        while (q.Any()) {
            var t = q[0];
            q.RemoveAt(0);
            int u = t.Item1;
            double d = t.Item2;
            if (u == end) return Math.Exp(-dist[end]);
            seen[u] = true;
            foreach (var v in g[u]) {
                if ( seen[v.Item1] || v.Item2 + d > dist[v.Item1]) continue; // will reach the min and then stop
                dist[v.Item1] = v.Item2 + d;
                q.Add((v.Item1, dist[v.Item1]));
                q.Sort((x,y) => x.Item2.CompareTo(y.Item2));
            }
        }
        return Math.Exp(-dist[end]);
    }
}
