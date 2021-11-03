public class Solution {
    public int NumberOfPatterns(int m, int n) {
        int ans = 0;
        var visited = new bool[10];
        var jumpRules = new int[10,10];
        jumpRules[1,3] = jumpRules[3,1] = 2;
        jumpRules[4,6] = jumpRules[6,4] = 5;
        jumpRules[7,9] = jumpRules[9,7] = 8;
        jumpRules[1,7] = jumpRules[7,1] = 4;
        jumpRules[2,8] = jumpRules[8,2] = 5;
        jumpRules[3,9] = jumpRules[9,3] = 6;
        jumpRules[1,9] = jumpRules[9,1] = jumpRules[3,7] = jumpRules[7,3] = 5;
        Action<int,int> DFS = null;
        DFS =(start,len) =>{
            if (len >= m) ans++;
            len++;
            if (len > n) return;
            visited[start] = true;
            for (int nx = 1; nx <= 9; nx++) {
                int j = jumpRules[start, nx];
                if (!visited[nx] && (visited[j] || j == 0)) DFS(nx, len);
            }
            visited[start] = false;
        };
        DFS(1,1); // 1/3/7/9 are same
        DFS(3,1);
        DFS(7,1);
        DFS(9,1);
        DFS(2,1); // 2/4/6/8 are same
        DFS(4,1);
        DFS(6,1);
        DFS(8,1);
        DFS(5,1);
        return ans;
    }
}
