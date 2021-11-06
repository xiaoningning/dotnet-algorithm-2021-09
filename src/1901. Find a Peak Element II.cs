public class Solution {
    // T: O(m log(n)) similar to LC 162
    public int[] FindPeakGrid(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, lCol = 0, rCol = n - 1;
        while (lCol <= rCol){
            int mCol = lCol + (rCol - lCol) / 2, mxRow = 0;
            for (int i = 0; i < m; i++) if (mat[i][mCol] > mat[mxRow][mCol]) mxRow = i;
            if ((mCol == 0 ||  mat[mxRow][mCol] > mat[mxRow][mCol - 1])
                && (mCol == n - 1 ||  mat[mxRow][mCol] > mat[mxRow][mCol + 1])) return new int[]{mxRow, mCol};
            else if (mCol > 0 && mat[mxRow][mCol - 1] > mat[mxRow][mCol]) rCol = mCol - 1;
            else lCol = mCol + 1;
        }
        return new int[]{};
    }
}
