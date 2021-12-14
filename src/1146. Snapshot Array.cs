public class SnapshotArray {
    /**
    Set: O(log|snap_id|)
    Get: O(log|snap_id|) 
    Snap: O(1)
    Space complexity: O(length + set_calls)
    */
    int _id;
    Dictionary<int, Dictionary<int, int>> _vals;
    // Initially, each element equals 0
    public SnapshotArray(int length) {
        _id = 0;
        _vals = new Dictionary<int, Dictionary<int,int>>(length);
    }
    
    public void Set(int index, int val) {
        if (!_vals.ContainsKey(index)) _vals[index] = new Dictionary<int,int>();
        _vals[index][_id] = val;
    }
    
    public int Snap() { return _id++; }
    // at the time we took the snapshot with the given snap_id
    public int Get(int index, int snap_id) {
        if (!_vals.ContainsKey(index)) return 0; // all init as 0
        // find upper bound of snap_id
        // The map stores {snap_id -> val}, 
        // use upper_bound to find the first version >= snap_id and use previous version’s value.
        var snaps = _vals[index].Keys.ToList();
        int l = 0, r = snaps.Count;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (snaps[m] <= snap_id) l = m + 1;
            else r = m;
        }
        // l == 0 => snap_id < any snaps of index
        // _vals[1] -> {4: 1, 5: 2} => query snap_id == 1, then => 0
        if (l == 0) return 0; 
        return _vals[index][snaps[l-1]];
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */
