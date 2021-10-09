public class Solution {
    // union find
    public int LargestComponentSize(int[] nums) {
        int mx = nums.Max(); // without this TLE
        // root of all common factor
        int[] root = new int[mx + 1];
        for (int i = 0; i <= mx; i++) root[i] = i;
        Func<int,int> UnionFind = null;
        UnionFind = (x) => root[x] == x ? x : root[x] = UnionFind(root[x]);
        Action<int,int> Union = (x,y) => {
            int rx = UnionFind(x);
            int ry = UnionFind(y);
            if (rx != ry) root[rx] = ry;
        };
        foreach (int n in nums) {
            for (int f = (int)Math.Sqrt(n); f >=2 ; f--) {
                if (n % f != 0) continue;
                // union with all factors := union(6,2), union(6,3)
                // union all factors to one root
                Union(n, f);
                Union(n, n / f);
            }
        }
        int ans = 0;
        int[] cnt = new int[mx + 1];
        foreach (int n in nums) ans = Math.Max(ans, ++cnt[UnionFind(n)]);
        return ans; // the size of group of largest common factor components
    }
}
