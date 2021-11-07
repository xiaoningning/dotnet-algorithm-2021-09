public class Solution {
    // HashTable + Sliding Window
    // T: O(n) S: O(n)
    public IList<int> FindAnagrams1(string s, string p) {
        var ans = new List<int>();
        if (string.IsNullOrEmpty(s)) return ans;
        int[] pcnt = new int[26], scnt = new int[26];
        foreach (char c in p) pcnt[c -'a']++;
        int sn = s.Length, pn = p.Length;
        for (int i = 0; i < sn; i++) {
            scnt[s[i] - 'a']++;
            if (i >= pn) scnt[s[i - pn] - 'a']--;
            if (scnt.SequenceEqual(pcnt)) ans.Add(i + 1 - pn);
        }
        return ans;
    }
    public IList<int> FindAnagrams(string s, string p) {
        var ans = new List<int>();
        if (string.IsNullOrEmpty(s)) return ans;
        int[] pcnt = new int[26];
        foreach (char c in p) pcnt[c -'a']++;
        int pn = p.Length, left = 0, right = 0;
        while (right < s.Length) {
            if (pcnt[s[right++] - 'a']-- >= 1) --pn;
            if (pn == 0) ans.Add(left);
            if (right - left == p.Length && pcnt[s[left++] - 'a']++ >= 0) ++pn;
        }
        return ans;
    }
}
