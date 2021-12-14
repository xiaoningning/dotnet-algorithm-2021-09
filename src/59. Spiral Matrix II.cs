public class Solution {
    public int[][] GenerateMatrix(int n) {
        var ans = new int[n][];
        for (int i = 0; i < n; i++) ans[i] = new int[n];
        int up = 0, down = n - 1, left = 0, right = n - 1, val = 1;
        while (true) {
            for (int j = left; j <= right; ++j) ans[up][j] = val++;
            if (++up > down) break;
            for (int i = up; i <= down; ++i) ans[i][right] = val++;
            if (--right < left) break;
            for (int j = right; j >= left; --j) ans[down][j] = val++;
            if (--down < up) break;
            for (int i = down; i >= up; --i) ans[i][left] = val++;
            if (++left > right) break;
        }
        return ans;
    }
}
