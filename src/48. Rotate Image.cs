public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        // (i, j) <- (n-1-j, i) <- (n-1-i, n-1-j) <- (j, n-1-i)
        for (int i = 0; i < n / 2; i++) {
            for (int j = i; j < n - 1 - i; j++) {
                int t = matrix[i][j];
                matrix[i][j] = matrix[n - 1 - j][i];
                matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                matrix[j][n - 1 - i] = t;
            }
        }
    }
}
