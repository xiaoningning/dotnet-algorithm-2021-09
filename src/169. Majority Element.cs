public class Solution {
    // Majority cnt >= 1
    // T: O(n), S: O(1)
    public int MajorityElement(int[] nums) {
        int ans = nums[0], cnt = 0;
        foreach (int n in nums) {
            if (n == ans) cnt++;
            else if (--cnt == 0) { 
                ans = n; 
                cnt = 1;
            }
        }
        return ans;
    }
}
