public class Solution {
    // binary search 
    // T: O(log(m*n)) S: O(1)
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return false;
        int m = matrix.Length, n = matrix[0].Length;
        int i = 0, j = n - 1;
        while (i < m && j >= 0) {
            if (matrix[i][j] == target) return true;
            else if (matrix[i][j] < target) i++;
            else j--;
        }
        return false;
    }
}
