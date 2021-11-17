public class RandomizedCollection {
    List<int> nums = new List<int>();
    Dictionary<int,HashSet<int>> m = new Dictionary<int,HashSet<int>>();
    // O(1) with hashset
    public RandomizedCollection() {}
    
    public bool Insert(int val) {
        if (!m.ContainsKey(val)) m[val] = new HashSet<int>();
        nums.Add(val);
        m[val].Add(nums.Count - 1);
        return m[val].Count == 1; // true if 1st time insert, false if multiple occurrences
    }
    
    public bool Remove(int val) {
        if (!m.ContainsKey(val) || m[val].Count == 0) return false;
        int idx = m[val].First();
        m[val].Remove(idx);
        if (nums.Count - 1 != idx) {
            int last = nums.Last();
            nums[idx] = last;
            m[last].Remove(nums.Count - 1);
            m[last].Add(idx);
        }
        nums.RemoveAt(nums.Count - 1); // at last
        return true;
    }
    
    public int GetRandom() {
        var rnd = new Random();
        return nums[rnd.Next() % nums.Count];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
