public class Solution {
    // parentheses
    public int Calculate(string s) {
        int res = 0, curRes = 0, num = 0, n = s.Length;
        char op = '+';
        for (int i = 0; i < n; i++) {
            char c = s[i];
            if (c >= '0' && c <= '9') {
                num = 10 * num + (c - '0');
            }
            
            if (c == '+' || c == '-' || c == '*' || c == '/' || i == n - 1) {
                switch (op) {
                    case '+': curRes += num; break;
                    case '-': curRes -= num; break;
                    case '*': curRes *= num; break;
                    case '/': curRes /= num; break;
                }
                if (c == '+' || c == '-' || i == n - 1) {
                    res += curRes; // curRes hold *, /, prev res
                    curRes = 0;
                }
                num = 0;
                op = c;
            }
        }
        return res;
    }
}
