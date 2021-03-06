public class Solution {
    // DFS T: O(E + Q*E) S: O(E)
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var g = new Dictionary<string, Dictionary<string, double>>();
        for (int i = 0; i < equations.Count; i++) {
            if (!g.ContainsKey(equations[i][0])) g[equations[i][0]] = new Dictionary<string, double>();
            if (!g.ContainsKey(equations[i][1])) g[equations[i][1]] = new Dictionary<string, double>();
            g[equations[i][0]][equations[i][1]] = values[i];
            g[equations[i][1]][equations[i][0]] = 1.0 / values[i];
        }
        var ans = new double[queries.Count];
        Func<string, string, HashSet<string>, double> DFS = null;
        DFS = (x, y, visited) => {
            if (!g.ContainsKey(x)) return -1.0;
            if (x == y) return 1.0;
            if (g[x].ContainsKey(y)) return g[x][y];
            visited.Add(x);// in case circular back;
            foreach (var kv in g[x]) {
                var nx = kv.Key;
                if (visited.Contains(nx)) continue;
                var d = DFS(nx, y, visited);
                if (d > 0) return g[x][nx] * d; // A / B =  A / C * C / B
            }
            return -1.0;
        };
        for (int i = 0; i < queries.Count; i++) {
            var A = queries[i][0];
            var B = queries[i][1];
            ans[i] = DFS(A, B, new HashSet<string>());
        }
        return ans;
    }
    // UnionFind T: O(E + Q * logQ) S: O(E)
    // check 2021-7 UnionFind implementation better!!!
    // if circular, then UnionFind does not work!!!
    public double[] CalcEquation2(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var root = new Dictionary<string, (string, double)>();
        Func<string, (string,double)> unionFind = null;
        unionFind = (x) => { 
            if (x != root[x].Item1) {
                var p =  unionFind(root[x].Item1);
                root[x] = (p.Item1, root[x].Item2 * p.Item2);
            } 
            return root[x];
        };
        for (int i = 0; i < equations.Count; i++) {
            if (!root.ContainsKey(equations[i][0])) root[equations[i][0]] = (equations[i][0], 1.0);
            if (!root.ContainsKey(equations[i][1])) root[equations[i][1]] = (equations[i][1], 1.0);
            var rA = unionFind(equations[i][0]);
            var rB = unionFind(equations[i][1]);
            root[rA.Item1] = (rB.Item1, values[i] / rA.Item2 * rB.Item2);
        }
        
        var ans = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++) {
            var X = queries[i][0];
            var Y = queries[i][1];
            if (!root.ContainsKey(X) || !root.ContainsKey(Y)) {
                ans[i] = -1.0;
                continue;
            }
            var rX = unionFind(X);
            var rY = unionFind(Y);
            // foreach (var kv in root) Console.WriteLine($"{kv.Key} {kv.Value.Item1} {kv.Value.Item2}");
            if (rX.Item1 != rY.Item1) ans[i] = -1.0; // not in the same group
            else ans[i] = rX.Item2 / rY.Item2;
        }
        return ans;
    }
    // Union Find 2021-7 version
    // if circular, then UnionFind does not work!!!
    Dictionary<string, string> parentUnion = new Dictionary<string, string>();
    Dictionary<string, double> v = new Dictionary<string, double>();   
    public double[] CalcEquation3(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var ans = new List<double>();
        if (equations.Count == 0) return ans.ToArray();
        for (int i = 0; i < equations.Count; i++) {
            var e = equations[i];
            string a = e[0], b = e[1];
            Union(a, b, values[i]);
        }
        foreach (var q in queries) {
            string x = q[0], y = q[1];
            if (parentUnion.ContainsKey(x) 
                && parentUnion.ContainsKey(y)
                && UnionFind(x) == UnionFind(y)) {
                ans.Add(v[x] / v[y]);
            }
            else ans.Add(-1);
        }
        // T: O(e + query) S: O(e)
        return ans.ToArray();
    }
    void Union(string a, string b, double val) {
        string pa = UnionFind(a), pb = UnionFind(b);
        parentUnion[pa] = pb;
        // a/b, c/e => b/e = (a/c)*(c/e)/(a/b)
        v[pa] = val * v[b] / v[a];
    }
    string UnionFind(string x) {
        if (!parentUnion.ContainsKey(x)) {
            parentUnion[x] = x;
            v[x] = 1.0;
            return x;
        }
        else {
            string px = parentUnion[x];
            if (x != px) {
                parentUnion[x] = UnionFind(px);
                v[x] = v[x]* v[px];
            }
            return parentUnion[x];
        }
    }
}
