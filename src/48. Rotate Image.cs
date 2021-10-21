public class Solution {
    public void Rotate1(int[][] matrix) {
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
    // First pass: mirror around diagonal 
    // Second pass: mirror around y axis
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        Action<(int, int), (int, int)> swapM = (x, y) => {
            int t = matrix[x.Item1][x.Item2];
            matrix[x.Item1][x.Item2] = matrix[y.Item1][y.Item2]; 
            matrix[y.Item1][y.Item2] = t;
        };
        for (int i = 0; i < n; ++i)
          for (int j = i + 1; j < n; ++j)
            swapM((i,j), (j,i));
        for (int i = 0; i < n; ++i)
            Array.Reverse(matrix[i]);
    }
}
