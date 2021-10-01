public class Solution {
    // recursion
    public string CountOfAtoms(string s) {
        int i = 0, len = s.Length;
        Func<int> getCnt = () => {
            int cnt = 0;
            while (i < len && s[i] >= '0' && s[i] <= '9')
                cnt = cnt * 10 + s[i++] - '0';
            return cnt == 0 ? 1 : cnt; // default should be 1
        };
        Func<string> getName = () => {
            string name = "" + s[i++]; // 1st is CAP letter
            while (i < len && s[i] >= 'a' && s[i] <= 'z')
                name += s[i++];
            return name;
        };
        Func<Dictionary<string,int>> countNames = null;
        countNames = () => {
            var counts = new Dictionary<string,int>();
            while (i < len) {
                if (s[i] == '(') {
                    i++;
                    var t = countNames();
                    int tCnt = getCnt(); // cnt after ')'
                    foreach (var kv in t) 
                        counts[kv.Key] = kv.Value * tCnt + (counts.ContainsKey(kv.Key) ? counts[kv.Key] : 0);
                }
                else if (s[i] == ')') {
                    i++;
                    return counts;
                }
                else {
                    string atom = getName();
                    counts[atom] = getCnt() + (counts.ContainsKey(atom) ? counts[atom] : 0);
                }
            }
            return counts;
        };
        var d = countNames();
        var ks = d.Keys.OrderBy(s => s);
        string ans = "";
        foreach (string k in ks) ans += k + (d[k] > 1 ? d[k].ToString() : "");
        return ans;
    }
}
