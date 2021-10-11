public class Solution {
    // Union find
    // case1: has cycle but no 2 parents => similar to LC. 684 union find to remove
    // case2.1: 2 parents, but no cycle => remove 2nd parent, check the cycle as LC 684
    // case2.2: 2 parents and has cycle 
    // T: O(nlogn)
    public int[] FindRedundantDirectedConnection(int[][] edges) {
        int n = edges.Length;
        int[] first = new int[2], second = new int[2];
        int[] root = new int[n + 1];
        foreach (var e in edges) {
            if (root[e[1]] == 0) root[e[1]] = e[0];
            else { // 2nd parent
                first = new int[]{root[e[1]], e[1]};
                second = new int[]{e[0], e[1]};
                e[0] = e[1] = -1; // remove 2nd parent
            }
        }
        for(int i = 1; i <= n; i++) root[i] = i; // prepare for union find
        Func<int, int> UnionFind = null; // Union Find with path compression T: O(logn)
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        foreach (var e in edges) {
            if (e[1] == -1) continue; // edge was removed
            int p0 = UnionFind(e[0]);
            int p1 = UnionFind(e[1]);
            if (p0 != p1) root[p1] = p0; // union
            else return first[0] == 0 ? e : first; // case 1 and 2.2 has cycle;
        }
        return second; // case 2.1, no cycle;
    }
}
