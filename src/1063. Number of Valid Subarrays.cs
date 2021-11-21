public class Solution {
    // Monotonic stack T: O(n)
    public int ValidSubarrays(int[] nums) {
        var st = new Stack<int>();
        int ans = 0;
        foreach (var n in nums) {
            while (st.Any() && st.Peek() > n) st.Pop();
            st.Push(n);
            ans += st.Count;
        }
        return ans;
    }
}
