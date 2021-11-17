public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return false;
        int m = matrix.Length, n = matrix[0].Length;
        if (target < matrix[0][0] || target > matrix[m-1][n-1]) return false;
        int x = m - 1, y = 0;
        while (x >= 0 && y < n) {
            if (matrix[x][y] == target) return true;
            else if (matrix[x][y] < target) y++;
            else x--;
        }
        return false;
    }
}
