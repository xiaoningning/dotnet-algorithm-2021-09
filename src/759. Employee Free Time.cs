/*
// Definition for an Interval.
public class Interval {
    public int start;
    public int end;

    public Interval(){}
    public Interval(int _start, int _end) {
        start = _start;
        end = _end;
    }
}
*/

public class Solution {
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule) {
        var lst = new List<Interval>();
        foreach (var s in schedule) foreach (var i in s) lst.Add(i);
        lst.Sort((x,y) => x.start - y.start);
        var ans = new List<Interval>();
        int end = lst.First().end;
        for (int i = 1; i < lst.Count; i++) {
            if (lst[i].start > end) ans.Add(new Interval(end, lst[i].start));
            end = Math.Max(lst[i].end, end);
        }
        return ans;
    }
}
