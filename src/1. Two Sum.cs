public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var d = new Dictionary<int,int>();
        for (int i = 0; i < nums.Length; i++) {
            int x = target - nums[i];
            if (d.ContainsKey(x)) return new int[]{d[x], i};
            d[nums[i]] = i;
        }
        return new int[]{};
    }
}
