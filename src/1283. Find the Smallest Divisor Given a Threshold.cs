public class Solution {
    // binary search + monotic order
    public int SmallestDivisor(int[] nums, int threshold) {
        Func<int, int> sum = (d) => {
            int s = 0;
            foreach (var n in nums) s += (n + d - 1) / d; // + d - 1 := round up
            return s;
        };
        int l = 1, r = (int)Math.Pow(10, 6);
        while (l < r) {
            int m = l + (r - l) / 2;
            if (sum(m) > threshold) l = m + 1;
            else r = m;
        }
        return l;
    }
}
