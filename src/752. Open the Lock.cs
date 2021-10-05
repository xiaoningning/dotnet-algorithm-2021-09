public class Solution {
    // BFS
    public int OpenLock(string[] deadends, string target) {
        string start = "0000";
        var st = new HashSet<string>(deadends);
        if (deadends.Contains(target) || deadends.Contains(start)) return -1;
        int cnt = 0;
        var used = new HashSet<string>(){start};
        var q = new Queue<string>();
        q.Enqueue(start);
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var prev = q.Dequeue();
                if (prev == target) return cnt;
                for (int i = 0; i < prev.Length; i++) {
                    foreach (int j in new int[]{-1, +1}) {
                        var t = prev.ToCharArray();
                        t[i] = (char)((t[i] - '0' + j + 10) % 10 + '0');
                        var nx = new string(t);
                        if (st.Contains(nx) || used.Contains(nx)) continue;
                        q.Enqueue(nx);
                        used.Add(nx);
                    }
                }
            }
            cnt++;
        }
        return -1;
    }
}
