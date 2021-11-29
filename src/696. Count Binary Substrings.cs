public class Solution {
    public int CountBinarySubstrings(string s) {
        int ones = s[0] == '1' ? 1 : 0, zeros = s[0] == '0' ? 1 : 0, ans = 0;
        for (int i = 1; i < s.Length; i++) {
            if (s[i] == '1') {
                ones = s[i - 1] == '1' ? ones + 1 : 1;
                if (zeros >= ones) ans++;
            }
            else if (s[i] == '0') {
                zeros = s[i - 1] == '0' ? zeros + 1 : 1;
                if (ones >= zeros) ans++;
            }
        }
        return ans;
    }
}
