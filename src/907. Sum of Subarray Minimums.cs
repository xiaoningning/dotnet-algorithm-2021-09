public class Solution {
    // monotonic stack => storage min of local range [left,min,right]
    // T: O(n) S: O(n)
    public int SumSubarrayMins(int[] arr) {
        int kM = (int)Math.Pow(10,9) + 7, n = arr.Length, ans = 0;
        var st = new Stack<int>();
        for (int i = 0; i <= n; i++) {
            // i <= n pick the last one !!!
            int cur = i < n ? arr[i] : 0;
            while (st.Any() && arr[st.Peek()] > cur) {
                int mn = st.Pop();
                int left = mn - (st.Any() ? st.Peek() : - 1);
                int right = i - mn;
                ans = (int)(ans + (long) arr[mn] * left * right % kM) % kM;
            }
            st.Push(i);
        }
        return ans;
    }
}
