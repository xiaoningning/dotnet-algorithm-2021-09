public class Solution {
    public int Calculate(string s) {
        int res = 0, num = 0, sign = 1, n = s.Length;
        for (int i = 0; i < n; i++) {
            char c = s[i];
            if (c >= '0' && c <= '9') {
                num = 10 * num + (c - '0');
            }
            else if (c == '(') {
                int j = i, cnt = 0;
                for(; i < n; i++) {
                    if (s[i] == '(') cnt++;
                    if (s[i] == ')') cnt--;
                    if (cnt == 0) break;
                }
                num = Calculate(s.Substring(j + 1, i - j - 1));
            }
            
            if (c == '+' || c == '-' || i == n - 1) {
                res += sign * num;
                num = 0;
                sign = (c == '+') ? 1 : -1;
            }
        }
        return res;
    }
}
