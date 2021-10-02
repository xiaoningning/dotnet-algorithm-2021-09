public class Solution {
    public bool Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;
        while (l <= r) {
            int m = l + (r - l) / 2;
            if (nums[m] == target) return true;
            if (nums[l] < nums[m]) {
                if (nums[l] <= target && target < nums[m]) r = m - 1;
                else l = m;
            }
            else if (nums[l] > nums[m]) { // rotated side
                if (nums[r] >= target && target > nums[m]) l = m + 1;
                else r = m;
            }
            else l++; // nums[l] == nums[m]
        }
        return false;
    }
    public bool Search2(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;
        while (l <= r) {
            int m = l + (r - l) / 2;
            if (nums[m] == target) return true;
            if (nums[m] < nums[r]) {
                if (nums[m] < target && target <= nums[r]) l = m + 1;
                else r = m - 1;
            }
            else if (nums[m] > nums[r]){
                if (nums[l] <= target && target < nums[m]) r = m - 1;
                else l = m + 1;
            }
            else r--; // nums[m] == nums[r]
        }
        return false;
    }
}
