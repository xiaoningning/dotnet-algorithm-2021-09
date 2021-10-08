public class Solution {
    // BFS in/out degree of node
    public int[] FindOrder1(int numCourses, int[][] prerequisites) {
        var ans = new List<int>();
        var cnt = new int[numCourses];
        var g = new Dictionary<int,List<int>>();
        for (int i = 0; i < numCourses; i++) g[i] = new List<int>();
        foreach (var p in prerequisites) {
            g[p[1]].Add(p[0]);
            cnt[p[0]]++;
        }
        var q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) 
            if (cnt[i] == 0) { 
                q.Enqueue(i); 
                ans.Add(i);
            }
        while (q.Any()) {
            var t = q.Dequeue();
            foreach (int nx in g[t]) {
                if (--cnt[nx] == 0) {
                    q.Enqueue(nx);
                    ans.Add(nx);
                }
            }
        }
        return cnt.Sum() == 0 ? ans.ToArray() : new int[]{};
    }
    // DFS state of node: 0 unknown, 1 finished, 2 taking
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var ans = new List<int>();
        int[] state = new int[numCourses];
         var g = new Dictionary<int,List<int>>();
        for (int i = 0; i < numCourses; i++) g[i] = new List<int>();
        foreach (var p in prerequisites) g[p[0]].Add(p[1]);
        Func<int,bool> DFS = null;
        DFS = (x) => {
            if (state[x] == 2) return false;
            if (state[x] == 1) return true;
            state[x] = 2;
            foreach (int nx in g[x]) if (!DFS(nx)) return false;
            state[x] = 1;
            ans.Add(x);
            return true;
        };
        for (int i = 0; i < numCourses; i++) DFS(i);
        return ans.Count == numCourses ? ans.ToArray() : new int[]{};
    }
}
