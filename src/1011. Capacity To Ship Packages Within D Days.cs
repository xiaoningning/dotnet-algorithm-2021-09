public class Solution {
    // binary search
    public int ShipWithinDays(int[] weights, int days) {
        int l = weights.Max(), r = weights.Sum() + 1;
        while (l < r) {
            int m = l + (r - l) / 2;
            int cnt = 1, sum = 0;
            foreach (int w in weights) {
                if (sum + w > m) {
                    sum = w;
                    cnt++;
                }
                else sum += w;
            }
            if (cnt > days) l = m + 1;
            else r = m;
        }
        return l;
    }
}
