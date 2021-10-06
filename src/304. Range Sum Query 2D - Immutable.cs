public class NumMatrix {
    int[,] sum; // prefix sum
    public NumMatrix(int[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return;
        int m = matrix.Length, n = matrix[0].Length;
        sum = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++) 
            for (int j = 0; j < n; j++)
                sum[i + 1, j + 1] = matrix[i][j] + sum[i, j + 1] + sum[i + 1, j] - sum[i, j];
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        return sum[row2 + 1, col2 + 1] - sum[row1, col2 + 1] - sum[row2 + 1, col1] + sum[row1, col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
