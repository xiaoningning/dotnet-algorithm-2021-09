public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var ans = "";
        for (int i = 0; i < word1.Length || i < word2.Length; i++) {
            if (i < word1.Length) ans += word1[i];
            if (i < word2.Length) ans += word2[i];
        }
        return ans;
    }
}
