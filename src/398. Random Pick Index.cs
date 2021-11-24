public class Solution {
    int[] v;
    public Solution(int[] nums) {
        v = nums;
    }
    
    public int Pick(int target) {
        int cnt = 0, n = v.Length, ans = -1;
        var rnd = new Random();
        for (int i = 0; i< n; i++) {
            if (v[i] != target) continue;
            cnt++;
            if (rnd.Next() % cnt == 0) ans = i;
        }
        return ans;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */
