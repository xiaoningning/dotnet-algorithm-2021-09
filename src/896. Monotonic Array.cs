public class Solution {
    public bool IsMonotonic(int[] nums) {
        bool inc = true, dec = true;
        for (int i = 1; i < nums.Length; i++) {
            inc &= (nums[i] >= nums[i-1]);
            dec &= (nums[i] <= nums[i-1]);
            if (!inc && !dec) return false;
        }
        return true;
    }
}
