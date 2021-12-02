public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        int ans = 0, n = intervals.Length, last = 0;
        Array.Sort(intervals, (x,y) => x[0] - y[0]);
        for (int i = 1; i < n; i++) {
            if (intervals[i][0] < intervals[last][1]) {
                ans++;
                if (intervals[i][1] < intervals[last][1]) last = i; // to remove min # of intervals
            }
            else last = i;
        }
        return ans;
    }
}
