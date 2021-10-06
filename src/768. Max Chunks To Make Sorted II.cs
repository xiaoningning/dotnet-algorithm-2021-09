public class Solution {
    // T: O(n)
    public int MaxChunksToSorted(int[] arr) {
        int n = arr.Length, ans = 0;
        int[] forward = (int[]) arr.Clone();
        int[] backward = (int[]) arr.Clone();
        for (int i = 1; i < n; i++) forward[i] = Math.Max(arr[i], forward[i-1]);
        for (int i = n - 2; i >= 0; i--) backward[i] = Math.Min(arr[i], backward[i+1]);
        for (int i = 0; i < n - 1; i++) if (forward[i] <= backward[i+1]) ans++;
        return ans + 1; // add last chuck
    }
    // monotonic stack
    // T: O(n + nlogn);
    public int MaxChunksToSorted2(int[] arr) {
        // store the largest num of each chunk
        var st = new Stack<int>();
        for (int i = 0; i < arr.Length; i++) {
            // Max Chunks II => it can be the same
            if (!st.Any() || st.Peek() <= arr[i]) st.Push(arr[i]);
            else {
                int mx = st.Pop();
                while (st.Any() && st.Peek() > arr[i]) st.Pop();
                st.Push(mx);
            }
        }
        return st.Count;
    }
    // T: O(n + nlogn);
    public int MaxChunksToSorted1(int[] arr) {
        int ans = 0;
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);
        for (int i = 0; i < arr.Length; i++) {
            arr[i] += i > 0 ? arr[i-1] : 0;
            sorted[i] += i > 0 ? sorted[i-1] : 0;
            if (arr[i] == sorted[i]) ans++;
        }
        return ans;
    }
}
