public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int n = matrix.Length;
        int l = matrix[0][0], r = matrix[n-1][n-1] + 1;
        while (l < r) {
            int m = l + (r - l) / 2;
            int cnt = 0;
            foreach (var row in matrix) 
                foreach (int x in row) if (x <= m) cnt++;
            if (cnt < k) l = m + 1;
            else r = m;
        }
        return l;
    }
}
