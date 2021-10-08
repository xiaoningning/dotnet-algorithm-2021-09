public class Solution {
    public bool IsBipartite(int[][] graph) {
        int n = graph.Length;
        var g = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) g[i] = new List<int>(graph[i]);
        int[] color = new int[n];
        Func<int,int,bool> DFS = null;
        DFS = (x, clr) => {
            color[x] = clr;
            foreach (int nx in g[x]) {
                if (color[nx] == clr) return false;
                if (color[nx] == 0 && !DFS(nx, -1 * clr)) return false;
            }
            return true;
        };
        for (int i = 0; i < n; i++) {
            if (color[i] == 0 && !DFS(i, 1)) return false;
        }
        return true;
    }
}
