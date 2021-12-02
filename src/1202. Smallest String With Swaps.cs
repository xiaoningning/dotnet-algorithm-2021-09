public class Solution {
    // Union Find
    // without visited TLE => avoid duplicating check i, only check the # of group
    // T: O(nlogn + k * (V+E)) unionfind O(logn) n => the length of pairs
    public string SmallestStringWithSwaps1(string s, IList<IList<int>> pairs) {
        int n = s.Length;
        var roots = new int[n];
        for (int i = 0; i < n; i++) roots[i] = i;
        Func<int, int> unionFind = null;
        unionFind = (x) => x == roots[x] ? x : roots[x] = unionFind(roots[x]);
        foreach (var p in pairs) roots[unionFind(p[1])] = roots[unionFind(p[0])];
        var idx = new Dictionary<int, List<int>>();
        var str = new Dictionary<int, List<char>>();
        for (int i = 0; i < n; i++) {
            int ri = unionFind(i);
            if (!idx.ContainsKey(ri)) idx[ri] = new List<int>();
            if (!str.ContainsKey(ri)) str[ri] = new List<char>();
            idx[ri].Add(i); // idx is already sorted
            str[ri].Add(s[i]);
        }
        char[] ans = new char[n];
        int[] visited = new int[n]; 
        for (int i = 0; i < n; i++) {
            if (visited[i] == 1) continue; // avoid to duplicate checking i
            int ri = unionFind(i);
            str[ri].Sort();
            for (int k = 0; k < idx[ri].Count; k++) { 
                ans[idx[ri][k]] = str[ri][k];
                visited[idx[ri][k]] = 1;
            }
        }
        return new string(ans);
    }
    // DFS 
    // T: O(nlogn + k*(V+E))
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        int n = s.Length;
        var g = new Dictionary<int, List<int>>();
        var visited = new int[n];
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var p in pairs) {
            g[p[0]].Add(p[1]);
            g[p[1]].Add(p[0]);
        }
        Action<int,List<int>, List<char>> DFS = null;
        DFS = (i, idx, str) => {
            if (visited[i] == 1) return;
            visited[i] = 1;
            str.Add(s[i]);
            idx.Add(i);
            foreach (int j in g[i]) DFS(j, idx, str); 
        };
        char[] ans = new char[n];
        for (int i = 0; i < n; i++) {
            if (visited[i] == 1) continue;
            var idx = new List<int>();
            var str = new List<char>();
            DFS(i, idx, str);
            str.Sort(); idx.Sort();
            for (int k = 0; k < idx.Count; k++) ans[idx[k]] = str[k];
        }
        return new string(ans);
    }
}
