public class Solution {
    // BFS
    public int[][] HighestPeak(int[][] isWater) {
        int m = isWater.Length, n = isWater[0].Length;
        var ans = new int[m][];
        for (int i = 0; i < m; i++) ans[i] = new int[n];
        var dirs = new int[,] {{1,0},{-1,0},{0,1},{0,-1}};
        var q = new Queue<int[]>();
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++) {
                ans[i][j] = Int32.MinValue;
                if (isWater[i][j] == 1) {
                    ans[i][j] = 0;
                    q.Enqueue(new int[]{i,j});
                }
            }
        while (q.Any()) {
            var t = q.Dequeue();
            for (int d = 0; d < 4; d++) {
                int ni = t[0] + dirs[d, 0], nj = t[1] + dirs[d, 1];
                if (ni < 0 || ni >= m || nj < 0 || nj >= n || ans[ni][nj] != Int32.MinValue) continue;
                ans[ni][nj] = ans[t[0]][t[1]] + 1;
                q.Enqueue(new int[]{ni, nj});
            }
        }
        return ans;
    }
}
