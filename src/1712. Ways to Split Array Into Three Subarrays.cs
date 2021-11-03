public class Solution {
    // two pointers: the right end of the middle array is in range [j, k – 1] and there are k – j choices.
    // T: O(n) S: O(1)
    public int WaysToSplit(int[] nums) {
        int kMod = (int)Math.Pow(10,9) + 7, n = nums.Length;
        long ans = 0;
        for (int i = 1; i < n; i++) nums[i] += nums[i-1];
        for (int i = 0, j = 0, k = 0; i < n; i++) {
            j = Math.Max(j, i+1);
            while (j < n - 1 && nums[i] > nums[j] - nums[i]) j++;
            k = Math.Max(k, j);
            while (k < n - 1 && nums[k] - nums[i] <= nums.Last() - nums[k]) k++;
            ans += k - j;
        }Console.WriteLine(ans);
        return (int)(ans % kMod);
    }
}
