public class Solution {
    // BFS T: O(n*26^word.Length) // Bidirectional BFS T: O(n*26^word.Length / 2)
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var st = new HashSet<string>(wordList);
        if (!st.Contains(endWord)) return 0;
        int cnt = 0;
        var q = new Queue<string>();
        q.Enqueue(beginWord);
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var prev = q.Dequeue();
                if (prev == endWord) return ++cnt;
                for (int i = 0; i < prev.Length; i++) {
                    for (char c = 'a'; c <= 'z'; c++) {
                        var t = prev.ToCharArray();
                        t[i] = c;
                        var nx = new string(t);
                        if (!st.Contains(nx) || nx == prev) continue;
                        q.Enqueue(nx);
                        st.Remove(nx); // pruning here to avoid duplicates in the ladder path
                    }
                }
            }
            cnt++;
        }
        return 0;
    }
}
