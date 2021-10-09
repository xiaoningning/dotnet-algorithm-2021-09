public class Solution {
    // BFS := a single point to dest path without weight
    public int MinMutation(string start, string end, string[] bank) {
        var st = new HashSet<string>(bank);
        if (!st.Contains(end)) return -1;
        var q = new Queue<string>();
        q.Enqueue(start);
        int ans = 0;
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                if (t == end) return ans;
                for (int i = 0; i < t.Length; i++) {
                    var arr = t.ToCharArray();
                    foreach (var c in new char[]{'A','C','G','T'}) {
                        arr[i] = c;
                        string nx = new string(arr);
                        if (!st.Contains(nx)) continue;
                        st.Remove(nx);
                        q.Enqueue(nx);
                    }
                }
            }
            ans++;
        }
        return -1;
    }
}
