public class Solution {
    // DFS T: O(2^n) S: O(n)
    public IList<int> SplitIntoFibonacci(string num) {
        int n = num.Length;
        var ans = new List<int>();
        Func<int, bool> DFS = null;
        DFS = (start) => {
            if (start == n) return ans.Count >= 3;
            // 10 bit is max len of in 32 to avoid overflow in32
            int mxLen = num[start] == '0' ? 1 : 10;
            for (int len = 1; start + len <= n && len <= mxLen; len++) {
                string t = num.Substring(start, len);
                long f2 = Int64.Parse(t);
                if (f2 > Int32.MaxValue) break;
                // pruning invalid cases
                if (ans.Count >= 2) {
                    if (ans[ans.Count - 2] + ans[ans.Count - 1] > f2) continue;
                    else if (ans[ans.Count - 2] + ans[ans.Count - 1] < f2) break;
                }
                ans.Add((int)f2);
                if (DFS(start + len)) return true;
                ans.RemoveAt(ans.Count - 1);
            }
            return false;
        };
        DFS(0);
        return ans;
    }
}
