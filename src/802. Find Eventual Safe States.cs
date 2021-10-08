public class Solution {
    // T: O(V+E)
    public IList<int> EventualSafeNodes(int[][] graph) {
        int n = graph.Length;
        var ans = new List<int>();
        // state:= 1: safe, 2 checking 0 unknown
        int[] state = new int[n];
        Func<int,int> DFS = null;
        DFS = (x) => {
            if (state[x] != 0) return state[x];
            state[x] = 2;
            foreach (int nx in graph[x]) if (DFS(nx) == 2) return state[x];
            return state[x] = 1;
        };
        for (int i = 0; i < n; i++)
            if (DFS(i) == 1) ans.Add(i);
        return ans;
    }
}
