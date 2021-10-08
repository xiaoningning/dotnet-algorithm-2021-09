public class Solution {
    // if not use bit mask, then hashset to track the colors of neighbors
    public int[] GardenNoAdj(int n, int[][] paths) {
        var g = new Dictionary<int,List<int>>();
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var p in paths) {
            g[p[0] - 1].Add(p[1] - 1);
            g[p[1] - 1].Add(p[0] - 1);
        }
        // 1/2/3/4 flower types
        int[] color = new int[n];
        for (int i = 0; i < n; i++) {
            if (color[i] != 0) continue;
            int state = 0;
            foreach (int nx in g[i]) state |= 1 << color[nx];
            for (int f = 1; f <= 4; f++) if ((state & 1 << f) == 0) color[i] = f;
        }
        return color;
    }
}
