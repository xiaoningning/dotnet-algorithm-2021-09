public class Solution {
    public string AddBoldTag(string s, string[] words) {
        int n = s.Length;
        var ans = "";
        var bold = new bool[n];
        foreach (var w in words) {
            int len = w.Length;
            for (int i = 0; i + len <= n; i++) {
                if (s.Substring(i, len) == w) {
                    for (int j = i; j < i + len; j++) bold[j] = true;
                }
            }
        }
        for (int i = 0; i < n; i++) {
            if (bold[i]) {
                if (i == 0 || !bold[i-1]) ans += "<b>";
                ans += s[i];
                if (i == n - 1 || !bold[i + 1]) ans += "</b>";
            }
            else ans += s[i];
        }
        return ans;
    }
}
