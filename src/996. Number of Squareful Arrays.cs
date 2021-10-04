public class Solution {
    // DFS 
    public int NumSquarefulPerms(int[] nums) {
        int n = nums.Length, ans = 0;
        Array.Sort(nums);
        int[] used = new int[n]; // permutation checks used[i]
        Action<List<int>> DFS = null;
        DFS = (cur) => {
            if (cur.Count == n) { ans++; return; }
            for (int i = 0; i < n; i++) {
                if (used[i] == 1) continue;
                if (i > 0 && used[i-1] == 0 && nums[i] == nums[i - 1]) continue;
                if (cur.Any() && !isSquareful(cur.Last(), nums[i])) continue;
                used[i] = 1;
                cur.Add(nums[i]);
                DFS(cur);
                used[i] = 0;
                cur.RemoveAt(cur.Count - 1);
            }
        };
        DFS(new List<int>());
        return ans;
    }
    // bit mask
    public int NumSquarefulPerms1(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums); // avoid duplicates
        int[,] g = new int[n,n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) 
                if (i != j && isSquareful(nums[i], nums[j])) g[i,j] = 1;
        int[,] dp = new int[1 << n, n];
        // base case
        for (int i = 0; i < n; i++) {
            if (i > 0 && nums[i] == nums[i-1]) continue;
            dp[1 << i, i] = 1;
        }
        for (int s = 0; s < 1 << n; s++) {
             for (int i = 0; i < n; i++) {
                if (dp[s, i] == 0) continue;
                for (int j = 0; j < n; j++) {
                    if (g[i,j] != 1 || (s & (1 << j)) > 0) continue;
                    // avoid duplicates, // Only the first one can be used of each path
                    if (j > 0 && (s & (1 << (j - 1))) == 0 && nums[j] == nums[j - 1]) continue;
                    dp[s | 1 << j, j] += dp[s, i];
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < n; i++) ans += dp[(1 << n) - 1, i];
        return ans;
    }
    bool isSquareful(int x, int y) {
        int a = (int) Math.Sqrt(x + y);
        return a * a == x + y;
    }
}
