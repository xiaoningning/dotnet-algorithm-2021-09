public class Solution {
    // DFS
    public IList<string> RemoveInvalidParentheses(string s) {
        var ans = new List<string>();
        int cnt1 = 0, cnt2 = 0;
        foreach (char c in s) {
            if (c == '(') cnt1++;
            else if (cnt1 > 0 && c == ')') cnt1--;
            else if (c == ')') cnt2++;
        }
        Action<int,int,int,string> DFS = null;
        DFS = (start, left, right, cur) => {
            if (left == 0 && right == 0) {
                if (isValid(cur)) ans.Add(cur); 
                return;
            }
            // use start from where invalid char is removed
            // avoid to duplicate scannings
            for (int i = start; i < cur.Length; i++) {
                // case "())" avoid duplicates 
                if (i > 0 && cur[i] == cur[i - 1]) continue;
                if (cur[i] == '(' && left > 0) DFS(i, left - 1, right, cur.Remove(i,1));
                if (cur[i] == ')' && right > 0) DFS(i, left, right - 1, cur.Remove(i,1));
            }
        };
        DFS (0, cnt1, cnt2, s);
        return ans;
    }
    // BFS => brute force
    public IList<string> RemoveInvalidParentheses1(string s) {
        var ans = new List<string>();
        var st = new HashSet<string>(){s};
        while (st.Any()) {
            var nx = new HashSet<string>();
            foreach (var t in st) {
                if (isValid(t)) ans.Add(t);
                if (ans.Any()) continue; // only this level
                for (int i = 0; i < t.Length; i++) {
                    if (t[i] != '(' && t[i] != ')') continue;
                    nx.Add(t.Remove(i, 1));
                }
            }
            st = nx;
        }
        return ans;
    }
    bool isValid(string s) {
        int cnt = 0;
        foreach (char c in s) {
            if (c== '(') cnt++;
            if (c == ')') cnt--;
            if (cnt < 0) return false; // case ")("
        }
        return cnt == 0;
    }
}
