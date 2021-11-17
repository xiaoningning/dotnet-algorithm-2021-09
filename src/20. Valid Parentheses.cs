public class Solution {
    // stack
    public bool IsValid(string s) {
        var p = new Dictionary<char, char>(){{')', '('}, {']', '['}, {'}', '{'}};
        var st = new Stack<char>();
        foreach (var c in s) {
            if (!p.ContainsKey(c)) st.Push(c);
            else {
                if (!st.Any() || st.Peek() != p[c]) return false;
                st.Pop();
            }
        }
        return !st.Any();
    }
}
