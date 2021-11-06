public class Solution {
    public IList<IList<string>> FindDuplicate(string[] paths) {
        var ans = new List<IList<string>>();
        var d = new Dictionary<string, List<string>>(); // HashSet<string> better
        foreach (var p in paths) {
            var fs = p.Split(" ");
            for (int i = 1; i < fs.Length; i++) {
                int idx = fs[i].IndexOf("(");
                var content = fs[i].Substring(idx); // (abcd)
                if (!d.ContainsKey(content)) d[content] = new List<string>();
                var fn = $"{fs[0]}/{fs[i].Substring(0, idx)}";
                d[content].Add(fn);
            }      
        }
        foreach (var kv in d) if (kv.Value.Count > 1) ans.Add(kv.Value);
        return ans;
    }
}
