public class Solution {
    // binary search T: O(nlogn)
    public int MinEatingSpeed(int[] piles, int h) {
        int l = 1, r = piles.Max() + 1;
        while (l < r) {
            int m = l + (r - l) / 2;
            int cnt = 0;
            foreach (int p in piles) cnt += (p + m - 1) / m;
            if (cnt > h) l = m + 1;
            else r = m;
        }
        return l;
    }
}
