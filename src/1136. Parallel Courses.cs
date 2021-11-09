public class Solution {
    // similar to LC. 210 LC. 207
    // DFS state: 0 unknown, 1 visted, 2 visiting
    public int MinimumSemesters1(int n, int[][] relations) {
        var depth = new int[n + 1];
        Array.Fill(depth, 1);
        int[] state = new int[n + 1];
        var g = new Dictionary<int,List<int>>();
        for (int i = 1; i <= n; i++) g[i] = new List<int>();
        foreach (var r in relations) g[r[1]].Add(r[0]);
        Func<int,bool> DFS = null;
        DFS = (x) => {
            if (state[x] == 2) return false;
            if (state[x] == 1) return true;
            state[x] = 2;
            foreach (int nx in g[x]) { 
                if (!DFS(nx)) return false;
                depth[x] = Math.Max(depth[x], depth[nx] + 1);
            }
            state[x] = 1;
            return true;
        };
        for (int i = 1; i <= n; i++) if (!DFS(i)) return -1; // cycled!!!
        return depth.Max();
    }
    // BFS in/out degree
    public int MinimumSemesters(int n, int[][] relations) {
        var ins = new int[n + 1];
        var g = new Dictionary<int,List<int>>();
        for (int i = 1; i <= n; i++) g[i] = new List<int>();
        foreach (var r in relations) { 
            g[r[1]].Add(r[0]);
            ins[r[0]]++;
        }
        var q = new Queue<(int,int)>();
        for (int i = 1; i <= n; i++) if (ins[i] == 0) q.Enqueue((i, 1));
        int mxDepth = 0;
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                mxDepth = t.Item2;
                foreach (var nx in g[t.Item1]) if (--ins[nx] == 0) q.Enqueue((nx, t.Item2 + 1));
            }
        }
        return ins.Sum() == 0 ? mxDepth : -1; // some not taken
    }
}
