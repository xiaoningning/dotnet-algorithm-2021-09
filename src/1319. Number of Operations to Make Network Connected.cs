public class Solution {
    // union find T: O(V+E)
    public int MakeConnected1(int n, int[][] connections) {
        if (connections.Length < n - 1) return -1;
        int[] root = new int[n];
        for (int i = 0; i < n; i++) root[i] = i;
        Func<int,int> UnionFind = null;
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        foreach (var c in connections) root[UnionFind(c[1])] = root[UnionFind(c[0])];
        int cnt = 0, total = connections.Length;
        for (int i = 0; i < n; i++) if (root[i] == i) cnt++;
        return cnt - 1; 
    }
    // DFS 
    public int MakeConnected(int n, int[][] connections) {
        if (connections.Length < n - 1) return -1;
        var g = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var c in connections) { 
            g[c[0]].Add(c[1]); 
            g[c[1]].Add(c[0]); 
        }
        var visited = new int[n];
        Action<int> DFS = null;
        DFS = (x) => { 
            foreach (int nx in g[x]) if (visited[nx]++ == 0) DFS(nx);
        };
        int cnt = 0;
        for (int i = 0; i < n; i++) {
            if (visited[i]++ == 0) {
                DFS(i);
                cnt++;
            }
        }
        return cnt - 1;
    }
}
