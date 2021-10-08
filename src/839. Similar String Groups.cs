public class Solution {
    // Disjoint Set : Union Find rank + path compression
    // rank + path compression => Union Find T: O(logE)
    // T: O(E^2 * logE)
    public int NumSimilarGroups(string[] strs) {
        strs = new HashSet<string>(strs).ToArray();
        int n = strs.Length, ans = 0;
        int[] root = new int[n];
        for (int i = 0; i < n; i++) root[i] = i;
        Func<int,int> UnionFind = null;
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                if (isSimilar(strs[i], strs[j])) root[UnionFind(j)] = UnionFind(i);
        
        for (int i = 0; i < n; i++) if (root[i] == i) ans++;
        return ans;
    }
    Func<string,string,bool> isSimilar = (x,y) => {
        if (x.Length != y.Length) return false;
        for (int i = 0, cnt = 0; i < x.Length; i++) if (x[i] != y[i]) if (++cnt > 2) return false;
        return true;
    };
    // DFS
    public int NumSimilarGroups2(string[] strs) {
        strs = new HashSet<string>(strs).ToArray();
        int n = strs.Length, ans = 0;
        int[] visited = new int[n];
        Action<int> DFS = null;
        DFS = (x) => {
            if (visited[x] == 1) return;
            visited[x] = 1;
            for (int j = 0; j < n; j++) {
                if (visited[j] == 1) continue;
                if (isSimilar(strs[x], strs[j])) DFS(j);
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
