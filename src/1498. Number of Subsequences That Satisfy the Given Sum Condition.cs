public class Solution {
    // T: O(NlogN) S: O(N)
    public int NumSubseq(int[] nums, int target) {
        int kM = (int)Math.Pow(10,9) + 7, n = nums.Length;
        Array.Sort(nums); // min/max of subsequence, no care on the order
        int[] pows = new int[n];
        pows[0] = 1; // each i, pick or not pick := 2 ^ (j - i) subsequences
        for (int i = 1 ; i < n ; ++i)
            pows[i] = pows[i - 1] * 2 % kM;
        int l = 0, r = n - 1, ans = 0;
        while (l <= r) {
            if (nums[l] + nums[r] > target) r--;
            else ans = (ans + pows[r - l++]) % kM;
        }
        return ans;
    }
}
