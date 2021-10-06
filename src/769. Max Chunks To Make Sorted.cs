public class Solution {
    // monotonic stack
    public int MaxChunksToSorted(int[] arr) {
        // store the largest num of each chunk
        var st = new Stack<int>();
        for (int i = 0; i < arr.Length; i++) {
            if (!st.Any() || st.Peek() < arr[i]) st.Push(arr[i]);
            else {
                int mx = st.Pop();
                while (st.Any() && st.Peek() > arr[i]) st.Pop();
                st.Push(mx);
            }
        }
        return st.Count;
    }
    // T: O(n)
    public int MaxChunksToSorted2(int[] arr) {
        int ans = 0, mx = Int32.MinValue;
        for (int i = 0; i < arr.Length; i++) {
            mx = Math.Max(mx, arr[i]);
            // arr[i] is in [0... (arr.Length =1)]
            if (mx == i) ans++;
        }
        return ans;
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
