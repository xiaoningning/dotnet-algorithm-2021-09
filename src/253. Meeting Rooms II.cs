public class Solution {
    public int MinMeetingRooms1(int[][] intervals) {
        var map = new SortedDictionary<int, int>();
        foreach (var i in intervals) {
            if (!map.ContainsKey(i[0])) map.Add(i[0],0);
            if (!map.ContainsKey(i[1])) map.Add(i[1],0);
            map[i[0]]++; // start
            map[i[1]]--; // end
        }
        int res = 0, room = 0;
        foreach (int i in map.Keys){
            room += map[i]; // if no overlapping, then start - end = 0
            res = Math.Max(res, room);
        }
        return res;
    }
    public int MinMeetingRooms2(int[][] intervals) {
        var starts = new List<int>();
        var ends = new List<int>();
        foreach (var i in intervals) { starts.Add(i[0]); ends.Add(i[1]); };
        starts.Sort();
        ends.Sort();
        int room = 0, endPos = 0;
        for (int i = 0; i < starts.Count; i++) {
            if (starts[i] < ends[endPos]) room++;
            else endPos++;
        }
        return room;
    }
    // prioirty queue
    public int MinMeetingRooms(int[][] intervals) {
        Array.Sort(intervals, (x,y) => x[0] - y[0]);
        var q = new List<int>(); // priority queue
        foreach (var i in intervals) {
            if (q.Any() && q.First() <= i[0]) q.RemoveAt(0);
            q.Add(i[1]);
            q.Sort();
        }
        return q.Count;
    }
}
