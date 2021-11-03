public class Solution {
    public string Evaluate(string s, IList<IList<string>> knowledge) {
        var d = new Dictionary<string,string>();
        foreach (var p in knowledge) d[p[0]] = p[1];
        string ans = "", cur = "";
        bool bracket = false;
        foreach (var c in s) {
            if (c == '(') bracket = true;
            else if (c == ')') {
                if (d.ContainsKey(cur)) ans += d[cur];
                else ans += "?";
                cur = "";
                bracket = false;
            }
            else {
                if (bracket) cur += c;
                else ans += c;
            }
        }
        return ans;
    }
}
