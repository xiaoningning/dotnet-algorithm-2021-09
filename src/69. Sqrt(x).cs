public class Solution {
    // binary search
    public int MySqrt(int x) {
        long l = 1, r = (long) x + 1;
        while (l < r) {
            long m = l + (r - l) / 2;
            // m*m overflow int32 => long
            if (m * m <= x) l = m + 1;
            else r = m;
        }
        return (int) l - 1;
    }
}
