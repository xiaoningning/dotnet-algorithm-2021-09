public class Solution {
    // DFS T: O(n^3) S: O(n^2)
    public int ContainVirus(int[][] isInfected) {
        int ans = 0, m = isInfected.Length, n = isInfected[0].Length;
        var dirs = new int[,]{{1,0},{-1,0},{0,1},{0,-1}};
        while (true) {
            var visited = new int[m,n];
            var nextRound = new List<List<List<int>>>();
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (isInfected[i][j] == 1 && visited[i,j] == 0) {
                        var q = new Queue<int>();
                        var nvs = new List<int>(){i * n + j};
                        var walls = new List<int>(); // health cell can share wall :=> set
                        visited[i, j] = 1;
                        q.Enqueue(i * n + j);
                        while (q.Any()) {
                            var t = q.Dequeue();
                            for (int d = 0; d < 4; d++) {
                                int ni = (t / n) + dirs[d, 0], nj = (t % n) + dirs[d, 1];
                                if (ni < 0 || ni >= m || nj < 0 || nj >= n || isInfected[ni][nj] == -1 || visited[ni, nj] == 1) continue;
                                if (isInfected[ni][nj] == 0) walls.Add(ni * n + nj);
                                if (isInfected[ni][nj] == 1) {
                                    q.Enqueue(ni * n + nj);
                                    nvs.Add(ni * n + nj);
                                    visited[ni, nj] = 1;
                                }
                            }
                        }
                        var nr = new List<List<int>>(){nvs, walls};
                        nextRound.Add(nr);
                    }
                }
            }
            if (!nextRound.Any()) break; // checked all
            nextRound.Sort((x,y) => y[1].Distinct().Count() - x[1].Distinct().Count()); // order based on actuall health cells, linq := count(), list := count as property
            for (int i = 0; i < nextRound.Count; i++) {
                if ( i == 0) {
                    ans += nextRound[i][1].Count; // wall in between cells. recount each cell with infected cell
                    foreach (var idx in nextRound[i][0]) isInfected[idx / n][idx % n] = -1; // visited in prev round
                }
                else foreach (var idx in nextRound[i][1]) isInfected[idx / n][idx % n] = 1; // walls => virus
            }
        }
        return ans;
    }
}
