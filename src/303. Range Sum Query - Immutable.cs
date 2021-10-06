public class NumArray {
    int[] sum; // prefix sum
    public NumArray(int[] nums) {
        int n = nums.Length;
        sum = new int[n+1];
        for (int i = 0; i < n; i++) sum[i+1] = sum[i] + nums[i];
    }
    
    public int SumRange(int left, int right) {
        return sum[right + 1] - sum[left]; // inclusive left and right
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
