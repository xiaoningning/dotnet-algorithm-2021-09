public class Solution {
    // monotonic stack
    public int Trap1(int[] height) {
        int i = 0, n = height.Length, ans = 0;
        var st = new Stack<int>();
        while (i < n) {
            if (!st.Any() || height[i] <= height[st.Peek()]) st.Push(i++);
            else {
                var t = st.Pop();
                if (!st.Any()) continue;
                ans += (Math.Min(height[i], height[st.Peek()]) - height[t]) * (i - st.Peek() - 1);
            }
        }
        return ans;
    }
    // two pointers
    public int Trap2(int[] height) {
        int l = 0, r = height.Length - 1, level = 0, ans = 0;
        while (l < r) {
            int lower = height[(height[l] < height[r]) ? l++ : r--];
            level = Math.Max(level, lower);
            ans += level - lower;
        }
        return ans;
    }
    // DP left/right scan to find min level of left or right in dp[i]
    public int Trap(int[] height) {
        int ans = 0, mx = 0, n = height.Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++) {
            dp[i] = mx;
            mx = Math.Max(mx, height[i]);
        }
        mx = 0;
        for (int i = n - 1; i >= 0; i--) {
            dp[i] = Math.Min(dp[i], mx);
            mx = Math.Max(mx, height[i]);
            if (dp[i] - height[i] > 0) ans += dp[i] - height[i];
        }
        return ans;
    }
}
