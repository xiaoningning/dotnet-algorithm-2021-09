public class Solution {
    public int LengthOfLongestSubstring1(string s) {
        int ans = 0, left = -1; // s.length == 1 case
        int[] m = new int[256];
        Array.Fill(m, -1); // 0 is valid position => -1
        for (int i = 0; i < s.Length; i++) {
            if (m[s[i]] > left) left = m[s[i]];
            m[s[i]] = i;
            ans = Math.Max(ans, i - left);
        }
        return ans;
    }
    public int LengthOfLongestSubstring(string s) {
        int ans = 0, left = -1; // s.length == 1 case
        var m = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            if (m.ContainsKey(s[i]) && m[s[i]] > left) left = m[s[i]];
            m[s[i]] = i;
            ans = Math.Max(ans, i - left);
        }
        return ans;
    }
}
