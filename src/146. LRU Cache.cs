public class LRUCache {
    int _size;
    List<int> keys = new List<int>();
    Dictionary<int,int> cache = new Dictionary<int,int>();
    public LRUCache(int capacity) { 
        _size = capacity;
    }
    // update least recent used key order
    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;
        keys.Remove(key);
        keys.Insert(0, key);
        return cache[key];
    }
    
    public void Put(int key, int value) {
        if (_size <= 0) return;
        else if (Get(key) != -1) cache[key] = value;
        else {
            if (keys.Count == _size) {
                cache.Remove(keys.Last());
                keys.RemoveAt(keys.Count - 1);
            }
            cache[key] = value;
            keys.Insert(0, key);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
