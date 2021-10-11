public class Solution {
    // T: O(n * m.Count). if Trie, search can be O(1);
    public string EntityParser(string text) {
        var m = new Dictionary<string,string>(){
            {"&quot;", "\""}, 
            {"&apos;", "'"}, 
            {"&amp;", "&"}, 
            {"&gt;", ">"}, 
            {"&lt;", "<"}, 
            {"&frasl;", "/"}
        };
        string ans = "", tmp = "";
        foreach (char c in text) {
            tmp += c;
            if (tmp.Last() != ';') continue;
            foreach (var kv in m) {
                int l = tmp.Length;
                int len = kv.Key.Length;
                if (l < len || tmp.Substring(l - len) != kv.Key) continue;
                ans += tmp.Substring(0, l - len) + kv.Value;
                tmp = "";
            }
        }
        return ans + tmp; // add the rest string
    }
}
