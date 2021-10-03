public class Solution {
    // DFS T:O(k!/(9!(9-k)!)) => C(m,n) => O(m!/(n!(n-m)!))
    public IList<IList<int>> CombinationSum31(int k, int n) {
        var ans = new List<IList<int>>();
        Action<int, List<int>> DFS = null;
        DFS = (start, t) => {
            if (t.Sum() == n && t.Count == k) { ans.Add(new List<int>(t)); return; }
            for (int i = start; i <= 9; i++) {
                if (t.Sum() + i > n) break;
                t.Add(i);
                DFS(i + 1, t); // i+1, NOT start +1 => duplicates
                t.RemoveAt(t.Count - 1);
            }
        };
        DFS(1, new List<int>());
        return ans;
    }
    // bit mask
    // T: O(2^m) = O(2^9)
    // S: O(k + k * ans.Count)
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var ans = new List<IList<int>>();
        // 2^9 states => generate all combinations of [1 .. 9]
        for (int s = 0; s < 1 << 9; s++) {
            var t = new List<int>();
            for (int i = 1; i <= 9; i++) if ((s & 1 << (i-1)) > 0) t.Add(i);
            if (t.Sum() == n && t.Count == k) ans.Add(t);
        }
        return ans;
    }
}
