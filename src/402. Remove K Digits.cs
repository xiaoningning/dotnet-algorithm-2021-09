public class Solution {
    // monotonic stack
    public string RemoveKdigits(string num, int k) {
        var st = new List<char>(); // monotonic stack, use lst without reverse later
        foreach (var c in num) {
            while (k > 0 && st.Any() && st.Last() > c) {
                st.RemoveAt(st.Count - 1); k--;
            }
            st.Add(c);
        }
        while (st.Any() && st[0] == '0') st.RemoveAt(0); // remove 0
        while (st.Any() && k-- > 0) st.RemoveAt(st.Count - 1); // for case "9", k = 1 
        return st.Count == 0 ? "0" : new string(st.ToArray());
    }
}
