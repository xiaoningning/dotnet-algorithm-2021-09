public class Solution {
    public int FindKthNumber(int m, int n, int k) {
        int l = 1, r = m * n + 1;
        while (l < r) {
            int mid = l + (r - l) / 2;
            int cnt = 0;
            // count row by row in Multiplication Table
            for (int i = 1; i <= m; i++) cnt += mid >= i * n ? n : mid / i;
            if (cnt < k) l = mid + 1;
            else r = mid;
        }
        return l;
    }
}
