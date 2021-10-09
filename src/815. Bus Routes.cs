public class Solution {
    // BFS := a single point path to dest without weight => track bus 
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        if (source == target) return 0;
        int n = routes.Length, ans = 0;
        var m = new Dictionary<int,List<int>>();
        for (int i = 0; i < n; i++) {
            foreach (var s in routes[i]) {
                if (!m.ContainsKey(s)) m[s] = new List<int>();
                m[s].Add(i);
            }
        }
        int[] visited = new int[n]; // track bus
        var q = new Queue<int>();
        foreach (int b in m[source]) {
            q.Enqueue(b);
            visited[b] = 1;
        }
        while (q.Any()) {
            int size = q.Count;
            ans++;
            while (--size >= 0) {
                var t = q.Dequeue();
                foreach (int nx in routes[t]) {
                    if (nx == target) return ans;
                    foreach (int b in m[nx]) {
                        if (visited[b] == 1) continue;
                        visited[b] = 1;
                        q.Enqueue(b);   
                    }
                }
            }
        }
        return -1;
    }
}
