public class Solution {
    // moore voting if  # n / 3, then could be 2 results.
    public IList<int> MajorityElement(int[] nums) {
        var ans = new List<int>();
        // init m1/m2 different <= it could be only one majority
        int n = nums.Length, cnt1 = 0, cnt2 = 0, m1 = nums[0], m2 = Int32.MaxValue;
        foreach (int x in nums) {
            if (x == m1) cnt1++;
            else if (x == m2) cnt2++;
            else if (cnt1 == 0) {
                m1 = x; cnt1 = 1;
            }
            else if (cnt2 == 0) {
                m2 = x; cnt2 = 1;
            }
            else {
                cnt1--; cnt2--;
            }
        }
        cnt1 = 0; cnt2 = 0;
        foreach (int x in nums) { 
            if (x == m1) cnt1++;
            if (x == m2) cnt2++;
        }
        if (cnt1 > n / 3) ans.Add(m1);
        if (cnt2 > n / 3) ans.Add(m2);
        return ans;
    }
}
