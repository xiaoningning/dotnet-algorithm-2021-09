public class Solution {
    // pick min val of leaf at each level to form parent node
    // Monotonic stack => store min num of local range => greedy search
    // T: O(n) S: O(n)
    public int MctFromLeafValues1(int[] arr) {
        int ans = 0;
        var st = new Stack<int>();
        foreach (int n in arr) {
            while (st.Any() && st.Peek() < n) 
                ans += st.Pop() * Math.Min(st.Any() ? st.Peek() : Int32.MaxValue, n); // left boarder
            st.Push(n);
        }
        while (st.Count >= 2) ans += st.Pop() * st.Peek(); // right border
        return ans;
    }
    // recursion + memo
    public int MctFromLeafValues2(int[] arr) {
        int n = arr.Length;
        int[,] max = new int[n, n];
        for (int i = 0; i< n; i++) {
            max[i, i] = arr[i];
            for (int j = i + 1; j < n; j++) 
                max[i, j] = Math.Max(max[i, j - 1], arr[j]);
        }
        int[,] memo = new int[n, n]; // min val of [i, j]
        Func<int,int,int> f = null;
        f = (i, j) => {
            if (i == j) return 0;
            if (memo[i, j] != 0) return memo[i, j];
            int ans = Int32.MaxValue;
            for (int k = i; k < j; k++) {
                ans = Math.Min(ans, max[i, k] * max[k+1, j] + f(i, k) + f(k + 1, j));
            }
            return memo[i, j] = ans;
        };
        return f(0, n - 1);
    }
    // DP
    public int MctFromLeafValues(int[] arr) {
        int n = arr.Length;
        int[,] max = new int[n, n];
        for (int i = 0; i< n; i++) {
            max[i, i] = arr[i];
            for (int j = i + 1; j < n; j++) 
                max[i, j] = Math.Max(max[i, j - 1], arr[j]);
        }
        int[,] dp = new int[n, n];
        for (int len = 2; len <= n; len++) { // min as 2 for a tree
            for (int i = 0, j = i + len - 1; j < n; j++, i++) {
                dp[i, j] = Int32.MaxValue;
                for (int k = i; k < j; k++) 
                    dp[i, j] = Math.Min(dp[i, j], max[i, k] * max[k+1, j] + dp[i,k] + dp[k+1, j]);
            }
        }
        return dp[0, n - 1];
    }
}
