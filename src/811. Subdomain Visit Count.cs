public class Solution {
    public IList<string> SubdomainVisits(string[] cpdomains) {
        var ans = new List<string>();
        var cnt = new Dictionary<string, int>();
        foreach (var d in cpdomains) {
            var t = d.Split(" ");
            int n = Int32.Parse(t[0]);
            string domain = t[1];
            for (int i = 0; i < domain.Length; i++) {
                if (domain[i] == '.') {
                    string subDomain = domain.Substring(i+1);
                    if (!cnt.ContainsKey(subDomain)) cnt[subDomain] = 0;
                    cnt[subDomain] += n;
                }
            }
            if (!cnt.ContainsKey(domain)) cnt[domain] = 0;
            cnt[domain] += n;
        }
        foreach (var kv in cnt) ans.Add(kv.Value + " " + kv.Key);
        return ans;
    }
}
