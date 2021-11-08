public class Solution {
    public string MinWindow(string s, string t) {
        var freq = new int[128];
        foreach (var c in t) freq[c]++;
        int cnt = 0, left = 0, mnLeft = -1, mnLen = s.Length + 1;
        for (int i = 0; i < s.Length; i++) {
            if (--freq[s[i]] >= 0) cnt++;
            while (cnt == t.Length) {
                if (mnLen > i - left + 1) {
                    mnLen = i - left + 1;
                    mnLeft = left;
                }
                if (++freq[s[left]] > 0) cnt--;
                left++;
            }
        }
        return mnLeft == -1 ? "" : s.Substring(mnLeft, mnLen);
    }
}
