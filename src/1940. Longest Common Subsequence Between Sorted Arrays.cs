public class Solution {
    public IList<int> LongestCommonSubsequence(int[][] arrays) {
        var ans = new List<int>();
        var cnt = new int[101]; // max of arrays + 1
        foreach (var a in arrays) {
            foreach (var n in a) {
                if (++cnt[n] == arrays.Length) ans.Add(n);
            }
        }
        return ans;
    }
}
