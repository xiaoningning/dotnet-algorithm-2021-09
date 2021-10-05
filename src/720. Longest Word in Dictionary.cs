public class Solution {
    // hash set faster than trie search
    public string LongestWord(string[] words) {
        var st = new HashSet<string>(words);
        string ans = "";
        foreach (string w in st) {
            if (w.Length < ans.Length || (w.Length == ans.Length && ans.CompareTo(w) < 0)) continue;
            bool valid = true;
            for (int l = 1; l <= w.Length; l++) {
                if (!st.Contains(w.Substring(0,l))) {
                    valid = false;
                    break;
                }
            }
            if (valid) ans = w;
        }
        return ans;
    }
}
