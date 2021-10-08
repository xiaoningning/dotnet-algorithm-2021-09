public class Solution {
    // DFS
    public int FindCircleNum1(int[][] isConnected) {
        int n = isConnected.Length;
        int ans = 0;
        int[] visited = new int[n];
        Action<int> DFS = null;
        DFS = (x) => {
            visited[x] = 1;
            for (int j = 0; j < n; j++) {
                if (visited[j] == 0 && isConnected[x][j] == 1) DFS(j);
            }
        };
        for (int i = 0; i < n; i++) {
            if (visited[i] == 0) {
                DFS(i);
                ans++;
            }
        }
        return ans;
    }
    // union find
    public int FindCircleNum(int[][] isConnected) {
        int n = isConnected.Length, ans = 0;
        int[] root = new int[n];
        for (int i = 0; i < n; i++) root[i] = i;
        Func<int, int> UnionFind = null;
        UnionFind = (x) => {
            return root[x] == x ? x : root[x] = UnionFind(root[x]);
        };
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (isConnected[i][j] == 1) 
                    root[UnionFind(j)] = root[UnionFind(i)];
            }
        }
        for (int i = 0; i < n; i++) if (root[i] == i) ans++;
        return ans;
    }
}
