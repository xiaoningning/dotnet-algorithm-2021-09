public class Solution {
    // hash table T:(n) Brute force + presum T: O(n^2)
    public int SubarraySum(int[] nums, int k) {
        int ans = 0, sum = 0;
        var m = new Dictionary<int,int>(){[0] = 1};
        foreach (int n in nums) {
            sum += n;
            if (m.ContainsKey(sum - k)) ans += m[sum - k];
            // k == 0 => update m after check sum - k
            if (!m.ContainsKey(sum)) m[sum] = 0;
            m[sum]++;
        }
        return ans;
    }
}
