public class RandomizedSet {
    List<int> nums = new List<int>();
    Dictionary<int,int> m = new Dictionary<int,int>();
    public RandomizedSet() { }
    
    public bool Insert(int val) {
        if (m.ContainsKey(val)) return false;
        nums.Add(val);
        m[val] = nums.Count - 1;
        return true;
    }
    
    public bool Remove(int val) {
        if (!m.ContainsKey(val)) return false;
        int last = nums.Last();
        m[last] = m[val];
        nums[m[val]] = last;
        nums.RemoveAt(nums.Count - 1);
        m.Remove(val);
        return true;
    }
    
    public int GetRandom() {
        var rnd = new Random();
        return nums[rnd.Next() % nums.Count];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
