public class Solution {
    public IList<IList<string>> Partition(string s) {
        var ans = new List<IList<string>>();
        Func<string, bool> isValid = (w) => {
            int i = 0, j = w.Length - 1;
            while (i < j) if (w[i++] != w[j--]) return false;
            return true;
        };
        Action<int, List<string>> DFS = null;
        DFS = (start, cur) => {
            if (start == s.Length) {
                ans.Add(new List<string>(cur));
                return;
            }
            for (int len = 1; start + len <= s.Length; len++) {
                string t = s.Substring(start, len);
                if (!isValid(t)) continue;
                cur.Add(t);
                DFS(start + len, cur);
                cur.RemoveAt(cur.Count - 1);
            }
        };
        DFS(0, new List<string>());
        return ans;
    }
}
