public class Solution {
    // DFS
    public int NumIslands(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        Action<int,int> DFS = null;
        DFS = (x, y) => {
            if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] != '1') return;
            grid[x][y] = '0';
            DFS(x + 1, y);
            DFS(x - 1, y);
            DFS(x, y + 1);
            DFS(x, y - 1);
        };
        int ans = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1') {
                    DFS(i,j);
                    ans++;
                }
            }
        }
        return ans;
    }
}
