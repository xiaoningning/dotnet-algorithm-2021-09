public class Solution {
    // T:  O(n*n)
    public string LongestPalindrome(string s) {
        if (s.Length < 2) return s;
        int n = s.Length, mxLen = 0, mxLeft = 0;
        Action<int,int> searchPalindrome = (l, r) => {
            while (l >= 0 && r < n && s[l] == s[r]) {
                l--; r++;
            }
            if (mxLen < r - l - 1) { // -1 :=> l--, r++ in while
                mxLen = r - l - 1;
                mxLeft = l + 1;
            }
        };
        for (int i = 0; i < n - 1; ++i) {
            searchPalindrome(i, i);
            searchPalindrome(i, i + 1);
        }
        return s.Substring(mxLeft, mxLen);
    }
}
