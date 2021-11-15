public class Solution {
    // DP 
    // T: O(m*n) S: O(1)
    public int MinFallingPathSum(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        for (int i = 1; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int sum = matrix[i-1][j];
                if (j > 0) sum = Math.Min(sum, matrix[i - 1][j - 1]);
                if (j < n - 1) sum = Math.Min(sum, matrix[i - 1][j + 1]);
                matrix[i][j] += sum;
            }
        }
        return matrix[m - 1].Min();
    }
}
