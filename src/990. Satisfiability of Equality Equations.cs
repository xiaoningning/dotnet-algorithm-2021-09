public class Solution {
    // union find
    public bool EquationsPossible(string[] equations) {
        int[] root = new int[26];
        for (int i = 0; i < 26; i++) root[i] = i;
        Func<int,int> UnionFind = null;
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        foreach (string e in equations)
            if (e[1] == '=') root[UnionFind(e[3] - 'a')] = root[UnionFind(e[0] - 'a')];
        foreach (string e in equations)
            if (e[1] == '!' && UnionFind(e[3] - 'a') == UnionFind(e[0] - 'a')) return false;
        return true;
    }
}
