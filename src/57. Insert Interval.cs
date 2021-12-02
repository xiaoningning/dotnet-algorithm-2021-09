public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var ans = new List<int[]>();
        int n = intervals.Length, cur = 0;
        for (int i = 0; i < n; i++) {
            if (intervals[i][1] < newInterval[0]) {
                ans.Add(intervals[i]); 
                cur++;
            }
            else if (intervals[i][0] > newInterval[1]) ans.Add(intervals[i]); 
            else {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            }
        }
        ans.Insert(cur, newInterval);
        return ans.ToArray();
    }
}
