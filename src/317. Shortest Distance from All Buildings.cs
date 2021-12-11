public class Solution {
    public int ShortestDistance(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var dirs = new int[,] {{1,0},{-1,0},{0,1},{0,-1}};
        var sum = new int[m, n];
        int ans = Int32.MaxValue, landVal = 0;
        for (int i = 0; i < m; i++) 
            for (int j = 0; j < n; j++) 
                if (grid[i][j] == 1) {
                    ans = Int32.MaxValue;
                    var dist = new int[m,n];
                    var q = new Queue<int[]>();
                    q.Enqueue(new int[]{i,j});
                    while (q.Any()) {
                        var t = q.Dequeue();
                        for (int d = 0; d < 4; d++) {
                            int x = t[0] + dirs[d,0], y = t[1] + dirs[d,1];
                            if (x < 0 || x >= m | y < 0 || y >= n || grid[x][y] != landVal) continue;
                            dist[x,y] = dist[t[0], t[1]] + 1;
                            sum[x,y] += dist[x, y];
                            q.Enqueue(new int[]{x, y});
                            grid[x][y]--; // update empty land val for next round
                            ans = Math.Min(ans, sum[x,y]);
                        }
                    }
                    landVal--; // track land, building/obstacle > 0
                }
        return ans == Int32.MaxValue ? -1 : ans;
    }
}
