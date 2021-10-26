public class Solution {
    // sparse matrix := most of nums is 0
    public int[][] Multiply(int[][] mat1, int[][] mat2) {
        var ans = new int[mat1.Length][];
        for (int i = 0; i < mat1.Length; i++) ans[i] = new int[mat2[0].Length];
        for (int i = 0; i < mat1.Length; i++) {
            for (int k = 0; k < mat1[i].Length; k++) {
                if (mat1[i][k] == 0) continue;
                for (int j = 0; j < mat2[0].Length; j++) {
                    if (mat2[k][j] == 0) continue;
                    ans[i][j] += mat1[i][k] * mat2[k][j];
                }
            }
        }
        return ans;
    }
}
