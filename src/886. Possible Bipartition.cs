public class Solution {
    // DFS
    public bool PossibleBipartition1(int n, int[][] dislikes) {
        var g = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++) g[i] = new List<int>();
        foreach (var d in dislikes) {
            g[d[0]].Add(d[1]);
            g[d[1]].Add(d[0]);
        }
        int[] color = new int[n + 1]; // 1: red, -1: blue, 0: unknown
        Func<int,int,bool> DFS = null;
        DFS = (x, clr) => {
            if (color[x] != 0 && color[x] != clr) return false;
            color[x] = clr;
            foreach (int y in g[x]) { 
                if (color[y] == 0 && !DFS(y, -1 * clr)) return false;
                if (color[y] == color[x]) return false;
            }
            return true;
        };
        for (int i = 1; i <= n; i++) if (color[i] == 0 && !DFS(i, 1)) return false;
        return true;
    }
    // BFS
    public bool PossibleBipartition(int n, int[][] dislikes) {
        var g = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++) g[i] = new List<int>();
        foreach (var d in dislikes) {
            g[d[0]].Add(d[1]);
            g[d[1]].Add(d[0]);
        }
        int[] color = new int[n + 1]; // 1: red, -1: blue, 0: unknown
        for (int i = 1; i <= n; i++) {
            if (color[i] != 0) continue;
            color[i] = 1;
            var q = new Queue<int>();
            q.Enqueue(i);
            while (q.Any()) {
                var t = q.Dequeue();
                foreach (int nx in g[t]) {
                    if (color[nx] == color[t]) return false;
                    if (color[nx] != 0) continue; // color[] serve as visited in BFS
                    if (color[nx] == 0) color[nx] = -1 * color[t];
                    q.Enqueue(nx);
                }
            }
        }
        return true;
    }
}
