public class Solution {
    // DFS + memo
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        var st = new HashSet<string>(words);
        var memo = new Dictionary<(string,int), bool>();
        Func<string, int, int, bool> f = null;
        f = (w, start, cnt) => {
            if (memo.ContainsKey((w, start))) return memo[(w, start)];
            if (start == w.Length && cnt >= 2) return memo[(w, start)] = true;
            for (int len = 1; len <= w.Length - start; len++){
                var t = w.Substring(start, len);
                if (st.Contains(t) && f(w, start + len, cnt + 1)) return memo[(w, start)] = true;
            }
            return memo[(w, start)] = false;
        };
        var ans = new List<string>();
        foreach (var w in st) if (f(w, 0, 0)) ans.Add(w);
        return ans;
    }
}
