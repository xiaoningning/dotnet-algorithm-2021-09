public class Solution {
    Dictionary<int,int> m = new Dictionary<int,int>();
    int len = 0;
    // O(length of blacklist)
    public Solution(int n, int[] blacklist) {
        var st = new HashSet<int>();
        len = n - blacklist.Length; // [0, n)
        for (int i = len; i < n; i++) st.Add(i);
        foreach (var num in blacklist) st.Remove(num);
        int idx = 0; // map num of blacklist < len into higher of idx in st
        var lst = st.ToList();
        foreach (var num in blacklist) if (num < len) m[num] = lst[idx++];
    }
    // O(1)
    public int Pick() {
        var rnd = new Random();
        var k = rnd.Next() % len;
        return m.ContainsKey(k) ? m[k] : k;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(n, blacklist);
 * int param_1 = obj.Pick();
 */
