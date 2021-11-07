public class Solution {
    // T: O(n), S: O(1)
    public int CountPalindromicSubsequence(string s) {
        int ans = 0;
        for (int i = 0; i < 26; i++) {
            int first = s.IndexOf((char)('a' + i)), last = s.LastIndexOf((char)('a' + i));
            if (first > -1 && last > first) 
                ans += s.Substring(first + 1, (last - 1) - (first + 1) + 1).Distinct().Count();
        }
        return ans;
    }
}
