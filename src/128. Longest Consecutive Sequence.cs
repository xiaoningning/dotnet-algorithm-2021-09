public class Solution {
    public int LongestConsecutive(int[] nums) {
        var st = new HashSet<int>(nums);
        int ans = 0;
        foreach (int n in nums) {
            // from lower bound to check
            if (!st.Contains(n - 1)) {
                int cnt = 0, x = n;
                while (st.Contains(x++)) cnt++;
                ans = Math.Max(ans, cnt);
            }
        }
        return ans;
    }
}
