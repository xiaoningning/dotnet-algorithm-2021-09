public class Solution {
    // monotonic stack.  similar to LC. 85
    // T: O(n^2)
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length, ans = 0;
        var st = new Stack<int>();
        for (int i = 0; i <= n; i++) { // <= n :=> handle left boarder
            int cur = i == n ? 0 : heights[i];
            while (st.Any() && heights[st.Peek()] >= cur) {
                ans = Math.Max(ans, heights[st.Pop()] * (st.Any() ? i - st.Peek() - 1 : i));
            }
            st.Push(i);
        }
        return ans;
    }
}
