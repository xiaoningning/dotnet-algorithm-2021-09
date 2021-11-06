public class Solution {
    public int LengthOfLongestSubstringKDistinct1(string s, int k) {
        int ans = 0, left = 0;
        var m = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            m[s[i]] = i;
            while (m.Count > k) {
                if (m[s[left]] == left) m.Remove(s[left]);
                left++;
            }
            ans = Math.Max(ans, i - left + 1);
        }
        return ans;
    }
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        int ans = 0, left = 0;
        var freq = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            if (!freq.ContainsKey(s[i])) freq[s[i]] = 0;
            freq[s[i]]++;
            while (freq.Count > k) {
                if (--freq[s[left]] == 0) freq.Remove(s[left]);
                left++;
            }
            ans = Math.Max(ans, i - left + 1);
        }
        return ans;
    }
}
