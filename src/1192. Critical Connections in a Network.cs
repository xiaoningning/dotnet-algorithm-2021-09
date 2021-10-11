public class Solution {
    // the order (rank/depth) of tree implementation
    // if cycle, the node should have the same order as the root of subtree
    // this is a simple version of Tarjan Algorithm: stong connected components (SCC) graph
    // Tarjan Algorithm := 2021-07 implementation
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        var ans = new List<IList<int>>();
        var g = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var c in connections) {
            g[c[0]].Add(c[1]);
            g[c[1]].Add(c[0]);
        }
        int[] rank = new int[n];
        Array.Fill(rank, Int32.MaxValue);
        Func<int,int,int,int> DFS = null;
        DFS = (x, timer, prev) => {
            if (rank[x] != Int32.MaxValue) return rank[x];
            rank[x] = timer;
            foreach (int nx in g[x]) {
                if (nx == prev) continue; // avoid to cycle back
                if (rank[nx] == Int32.MaxValue) DFS(nx, timer + 1, x);
                rank[x] = Math.Min(rank[x], rank[nx]);
                if (rank[nx] > timer) ans.Add(new List<int>() {x, nx});
            }
            return rank[x];
        };
        DFS(0, 1, -1);
        return ans;
    }
}
