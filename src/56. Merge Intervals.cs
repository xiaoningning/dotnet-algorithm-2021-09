public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) return new int[][]{};
        Array.Sort(intervals, (x,y) => x[0] - y[0]);
        int n = intervals.Length;
        var ans = new List<int[]>();
        ans.Add(intervals[0]);
        for (int i = 1; i < n; i++) {
            if (ans.Last()[1] < intervals[i][0]) ans.Add(intervals[i]);
            else ans.Last()[1] = Math.Max(ans.Last()[1], intervals[i][1]);
        }
        return ans.ToArray();
    }
}
