public class Solution {
    // DFS topological sorting
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var g = new Dictionary<int, List<int>>();
        for (int i = 0; i < numCourses; i++) g[i] = new List<int>();
        foreach (var pre in prerequisites) g[pre[0]].Add(pre[1]);
        var state = new int[numCourses]; // 0: unknown, 1: done, 2: taking
        Func<int, bool> DFS = null;
        DFS = (i) => {
            if (state[i] == 1) return true;
            if (state[i] == 2) return false;
            state[i] = 2;
            foreach (var ni in g[i]) if (!DFS(ni)) return false;
            state[i] = 1;
            return true;
        };
        for (int i = 0; i < numCourses; i++) if (!DFS(i)) return false;
        return true;
    }
}
