public class Solution {
    // left and right scan
    public bool CheckValidString1(string s) {
        int left = 0, right = 0, n = s.Length;
        for (int i = 0; i < n; i++) {
            if (s[i] == '(' || s[i] == '*') left++;
            else left--;
            if (left < 0) return false;
        }
        if (left == 0) return true; // * as '(' match
        for (int i = n - 1; i >= 0; i--) {
            if (s[i] == ')' || s[i] == '*') right++;
            else right--;
            if (right < 0) return false;
        }
        return true;
    }
    // stack
    public bool CheckValidString(string s) {
        Stack<int> left = new Stack<int>(), start = new Stack<int>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '*') start.Push(i);
            else if (s[i] == '(') left.Push(i);
            else {
                if (!start.Any() && !left.Any()) return false;
                if (left.Any()) left.Pop();
                else start.Pop(); // * as '('
            }
        }
        while (left.Any() && start.Any()) { // * as ')'
            if (left.Peek() > start.Peek()) return false; // case: * (
            left.Pop(); start.Pop();
        }
        return !left.Any();
    }
}
