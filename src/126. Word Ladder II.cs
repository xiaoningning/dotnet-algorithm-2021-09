public class Solution {
    // BFS :=> Bi-directional BFS
    // T: O(n*26^word.Length)
    // S: O(n)
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var ans = new List<IList<string>>();
        var dict = new HashSet<string>(wordList);
        if (!dict.Contains(endWord)) return ans;
        dict.Remove(beginWord);
        var q = new Queue<List<string>>();
        q.Enqueue(new List<string>(){beginWord});
        bool found = false;
        while (q.Any() && !found) {
            foreach (var path in q) foreach (var w in path) dict.Remove(w);
            int size = q.Count;
            while (--size >= 0) {
                var p = q.Dequeue();
                var w = p.Last();
                for (int i = 0; i < w.Length; i++) {
                    var cur = w.ToArray();
                    for (char c = 'a'; c <= 'z'; c++) {
                        cur[i] = c;
                        var nw = new string(cur);
                        if (!dict.Contains(nw)) continue;
                        var np = new List<string>(p);
                        np.Add(nw);
                        if (nw == endWord) {
                            // found := finish this level, but no more next level
                            ans.Add(np); found = true; 
                        }
                        else q.Enqueue(np);
                    }
                }
            }
        }
        return ans;
    }
}
