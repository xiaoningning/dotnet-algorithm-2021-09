/**
1 2 3 4 1
3 4 1 2 1 3
res: "1 2 3", "1 2 1", "3 4 1"
*/
public class Solution
{
    // DP PASSed
    public List<int> longestCommonSubsequence1(List<int> a, List<int> b)
    {
        int m = a.Count, n = b.Count;
        var dp = new int[m + 1, n + 1]; // track LCS result first
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i, j] = a[i - 1] == b[j - 1] ? 1 + dp[i - 1, j - 1] : Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        var ans = new List<int>(); // get LCS path now based on DP
        int x = m, y = n;
        while (x > 0 && y > 0)
        {
            if (a[x - 1] == b[y - 1])
            {
                ans.Insert(0, a[x - 1]);
                x--; y--;
            }
            else
            {
                // two ways to do it
                if (dp[x, y] == dp[x - 1, y]) x--;
                else y--;
                /**
                if (dp[x -1, y] > dp[x, y-1]) x--;
                else y--;
                */
            }
        }
        return ans;
    }
    // recursion without memo => TLE
    public List<int> longestCommonSubsequence1(List<int> a, List<int> b)
    {
        int m = a.Count, n = b.Count;
        var ans = new List<int>();
        var dirs = new int[,] { { 0, 1 }, { 1, 0 } };
        Action<int, int, List<int>> lcs = null;
        lcs = (i, j, cur) =>
        {
            if (i == m || j == n)
            {
                if (cur.Count >= ans.Count) ans = new List<int>(cur);
                return;
            }
            if (a[i] == b[j])
            {
                cur.Add(a[i]);
                lcs(i + 1, j + 1, cur);
                cur.RemoveAt(cur.Count - 1);
            }
            else
            {
                for (int d = 0; d < 2; d++)
                {
                    int ni = i + dirs[d, 0], nj = j + dirs[d, 1];
                    lcs(ni, nj, cur);
                }
            }
        };
        lcs(0, 0, new List<int>());
        return ans;
    }

}
