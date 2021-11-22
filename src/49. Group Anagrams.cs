public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var ans = new List<IList<string>>();
        var m = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            var t = s.ToCharArray();
            Array.Sort(t);
            var ts = new string(t);
            if (!m.ContainsKey(ts)) m[ts] = new List<string>();
            m[ts].Add(s);
        }
        foreach (var kv in m) ans.Add(kv.Value);
        return ans;
    }
}
