public class MedianFinder {
    List<int> mx = new List<int>(); // as priority queue
    List<int> mn = new List<int>(); // as priority queue
    public MedianFinder() {}
    // balance mn/mx two queues
    // sort := O(nlogn) => TLE, priority queue insert := O(logn)
    public void AddNum(int num) {
        mn.Add(num); mn.Sort();
        mx.Add(mn.Last()); mx.Sort(); mn.RemoveAt(mn.Count - 1);
        if (mn.Count < mx.Count) {
            mn.Add(mx.First()); mn.Sort();
            mx.RemoveAt(0);
        }
    }
    // avoid int overflow
    public double FindMedian() {
        return mn.Count > mx.Count ? (double) mn.Last() : 0.5 * mn.Last() + 0.5 * mx.First(); 
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
