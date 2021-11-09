public class Solution {
    // monotonic stack.  similar to LC. 84
    // T: O(m*n^2)
    public int MaximalRectangle1(char[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int ans = 0, m = matrix.Length, n = matrix[0].Length;
        int[] h = new int[n + 1];
        for (int i = 0; i < m; i++) {
            var st = new Stack<int>();
            for (int j = 0; j <= n; j++) { // <= n :=> handle left boarder
                if (j < n) h[j] = matrix[i][j] == '1' ? h[j] + 1 : 0;
                while (st.Any() && h[st.Peek()] >= h[j]) {
                    ans = Math.Max(ans, h[st.Pop()] * (st.Any() ? j - st.Peek() - 1 : j));
                }
                st.Push(j);
            }
        }
        return ans;
    }
    // T: O(m*n)
    public int MaximalRectangle(char[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int ans = 0, m = matrix.Length, n = matrix[0].Length;
        int[] h = new int[n], left1Pos = new int[n], right1Pos = new int[n];
        Array.Fill(right1Pos, n); // set max on the right
        for (int i = 0; i < m; i++) {
            int curLeft = 0, curRight = n;
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == '1') {
                    h[j]++;
                    left1Pos[j] = Math.Max(curLeft, left1Pos[j]); 
                }
                else {
                    h[j] = 0;
                    left1Pos[j] = 0;
                    curLeft = j + 1;
                }
            }
            for (int j = n - 1; j >= 0; j--) {
                if (matrix[i][j] == '1') right1Pos[j] = Math.Min(curRight, right1Pos[j]); 
                else { 
                    curRight = j;
                    right1Pos[j] = n; 
                }
                ans = Math.Max(ans, h[j] * (right1Pos[j] - left1Pos[j]));
            }
        }
        return ans;
    }
}
