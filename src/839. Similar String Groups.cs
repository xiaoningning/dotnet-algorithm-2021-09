public class Solution {
    // Disjoint Set : Union Find rank + path compression
    // rank + path compression => Union Find T: O(logE)
    // T: O(E^2 * logE)
    public int NumSimilarGroups1(string[] strs) {
        strs = new HashSet<string>(strs).ToArray();
        int n = strs.Length, ans = 0;
        int[] root = new int[n];
        for (int i = 0; i < n; i++) root[i] = i;
        Func<int,int> UnionFind = null;
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++) {
                if (!isSimilar(strs[i], strs[j])) continue;
                root[UnionFind(j)] = UnionFind(i);
            }
        for (int i = 0; i < n; i++) if (root[i] == i) ans++;
        return ans;
    }
    Func<string,string,bool> isSimilar = (x,y) => {
        if (x == y) return true;
        if (x.Length != y.Length) return false;
        int cnt = 0;
        for (int i = 0; i < x.Length; i++) if (x[i] != y[i]) cnt++;
        return cnt == 2 && new string (x.OrderBy(c => c).ToArray()) == new string (y.OrderBy(c => c).ToArray());
    };
    // DFS
    public int NumSimilarGroups(string[] strs) {
        strs = new HashSet<string>(strs).ToArray();
        int n = strs.Length, ans = 0;
        int[] visited = new int[n];
        Action<int> DFS = null;
        DFS = (x) => {
            if (visited[x] == 1) return;
            visited[x] = 1;
            for (int j = 0; j < n; j++) {
                if (visited[j] == 1 || !isSimilar(strs[x], strs[j])) continue;
                DFS(j);
            }
        };
        for (int i = 0; i < n; i++) {
            if (visited[i] == 1) continue;
            DFS(i);
            ans++;
        }
        return ans;
    }
}
