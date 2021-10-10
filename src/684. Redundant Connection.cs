public class Solution {
    // union find T: O(VlogE)
    public int[] FindRedundantConnection1(int[][] edges) {
        int n = edges.Length;
        int[] root = new int[n + 1];
        for (int i = 1; i <= n; i++) root[i] = i;
        Func<int,int> UnionFind = null;
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        int[] ans = new int[2];
        foreach (var e in edges) {
            int p0 = UnionFind(e[0]);
            int p1 = UnionFind(e[1]);
            if (p0 != p1) root[p1] = p0; // first time scane graph to union find
            else ans = e; // if already union in one root, then it is redundant
        }
        return ans;
    }
    // DFS T: O(E*V)
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        var g = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++) g[i] = new List<int>();
        int[] visited = new int[n + 1];
        Func<int, int, bool> DFS = null;
        DFS = (start, end) => {
            if (start == end) return false;
            visited[start] = 1;
            foreach (int nx in g[start])  {
                if (visited[nx] == 1) continue;
                if (!DFS(nx, end)) return false;
            }
            return true;
        };
        int[] ans = new int[2];
        foreach (var e in edges) {
            visited = new int[n + 1]; // new visited for each start point
            if (!DFS(e[0], e[1])) ans = e;
            g[e[0]].Add(e[1]);
            g[e[1]].Add(e[0]);
        }
        return ans;
    }
}
