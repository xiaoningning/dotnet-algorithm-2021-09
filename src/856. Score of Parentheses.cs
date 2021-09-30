public class Solution {
    // Monotonic Stack T: O(n)
    public int ScoreOfParentheses1(string s) {
        int res = 0;
        var st = new Stack<int>();
        foreach (char c in s) {
            if (c == '(') {
                st.Push(res);
                res = 0;
            }
            // first ')' res should be 1 since res init as 0
            else res = st.Pop() + Math.Max(1, res * 2);
        }
        return res;
    }
    // array linear T: O(n)
    public int ScoreOfParentheses(string s) {
        int cnt = 0, ans = 0;
        for (int i = 0; i < s.Length; i++) {
            cnt += s[i] == '(' ? 1 : -1;
            // init cnt == 0 => 1 << 0 = 1. if cnt >=1, 1 << cnt = 2 * cnt
            if (s[i] == ')' && s[i-1] == '(') ans += 1 << cnt;
        }
        return ans;
    }
}
