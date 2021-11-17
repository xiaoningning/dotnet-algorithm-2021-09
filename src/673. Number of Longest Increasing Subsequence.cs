public class Solution {
    // DP T: O(n^2)
    public int FindNumberOfLIS(int[] nums) {
        int ans = 0, mx = 0, n = nums.Length;
        int[] cnt = new int[n], len = new int[n];
        Array.Fill(cnt, 1); Array.Fill(len, 1);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[i] <= nums[j]) continue;
                // some other reach i as long as j reach i => update cnt[i], not need to update len[i]
                if (len[i] == len[j] + 1) cnt[i] += cnt[j]; 
                if (len[i] < len[j] + 1) { //update len[i] and cnt[i]
                    len[i] = len[j] + 1;
                    cnt[i] = cnt[j]; // find a new longest subseq
                }
            }
            if (len[i] == mx) ans += cnt[i];
            else if (len[i] > mx) {
                mx = len[i]; ans = cnt[i]; 
            }
        }
        return ans;
    }
}
