public class Solution {
    // bit mask for combination
    public IList<string> LetterCasePermutation3(string s) {
        var ans = new List<string>();
        int cnt = 0;
        foreach (char c in s) if (char.IsLetter(c)) cnt++;
        // each state := j bit letter either upper or lower case
        for (int state = 0; state < 1 << cnt; state++) {
            int j = 0; // j := bit of letter in s, j < cnt;
            string cur = "";
            foreach (char c in s) {
                if (!char.IsLetter(c)) cur += c;
                else {
                    if ((state & (1 << j++)) > 0) cur += char.ToUpper(c);
                    else cur += char.ToLower(c);
                }
            }
            ans.Add(cur);
        }
        return ans;
    }
    // DFS => build out combination
    public IList<string> LetterCasePermutation2(string s) {
        int n = s.Length;
        var ans = new List<string>();
        Action<int, List<string>> DFS = null;
        DFS = (i, cur) => {
            if (i == n) { ans = cur ; return; }
            char c = s[i];
            var nx = new List<string>();
            if (char.IsLetter(c)) {
                foreach (string str in cur) { 
                    nx.Add(str + char.ToUpper(c));
                    nx.Add(str + char.ToLower(c));
                }
            }
            else foreach (string str in cur) nx.Add(str + c);
            DFS(i+1, nx);
        };
        DFS(0, new List<string>(){""});
        return ans;
    }
    // loop through a list
    public IList<string> LetterCasePermutation1(string s) {
        int n = s.Length;
        var ans = new List<string>(){s};
        for (int i  = 0; i < n; i ++) {
            int size = ans.Count;
            for (int j = 0; j < size; j++) {
                string x = ans[j];
                char c = x[i];
                var t = x.ToCharArray();
                if (c >= '0' && c <= '9') continue;
                if (c >= 'a' && c <= 'z')  {
                    t[i] = char.ToUpper(c);
                    ans.Add(new string(t));
                }
                if (c >= 'A' && c <= 'Z')  {
                    t[i] = char.ToLower(c);
                    ans.Add(new string(t));
                }
            }
        }
        return ans;
    }
    // standard combination template
    public IList<string> LetterCasePermutation(string s) {
        int n = s.Length;
        int[] used = new int[n];
        var ans = new List<string>();
        Action<int, List<string>> DFS = null;
        DFS = (start, cur) => {
            if (start == n ) { ans = cur; return; }
            for (int i = start ; i < n; i++) {
                if (used[i] == 1) continue;
                var nx = new List<string>();
                if (char.IsLetter(s[i])) { 
                    foreach (var str in cur) { 
                        nx.Add(str + char.ToLower(s[i]));
                        nx.Add(str + char.ToUpper(s[i])); 
                    }
                }
                else foreach (var str in cur) nx.Add(str + s[i]);
                used[i] = 1;
                DFS(start + 1, nx);
            }
        };
        DFS(0, new List<string>{""});
        return ans;
    }
}
