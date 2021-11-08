public class MedianFinder {
    List<int> mx = new List<int>(); // as priority queue
    List<int> mn = new List<int>(); // as priority queue
    public MedianFinder() {}
    // balance mn/mx two queues
    // sort := O(nlogn) => TLE, priority queue insert := O(logn)
    public void AddNum(int num) {
        BinarySearchInsert(mn, num);
        BinarySearchInsert(mx, mn.Last()); mn.RemoveAt(mn.Count - 1);
        if (mn.Count < mx.Count) {
            BinarySearchInsert(mn, mx.First());
            mx.RemoveAt(0);
        }
    }
    // avoid int overflow
    public double FindMedian() {
        return mn.Count > mx.Count ? (double) mn.Last() : 0.5 * mn.Last() + 0.5 * mx.First(); 
    }
    // O(logn) => priority queue insert
    void BinarySearchInsert(List<int> q, int v) {
        int l = 0, r = q.Count;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (q[m] <= v) l = m + 1;
            else r = m;
        }
        q.Insert(l, v);
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
