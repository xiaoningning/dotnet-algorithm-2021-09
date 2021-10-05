// Dictionary
public class MapSum1 {
    Dictionary<string, int> sums = new Dictionary<string,int>();
    Dictionary<string, int> vals = new Dictionary<string,int>();
    public MapSum1() {}
    
    public void Insert(string key, int val) {
        int diff = val;
        if (vals.ContainsKey(key)) diff -= vals[key];
        vals[key] = val;
        for (int l = 1; l <= key.Length; l++) {
            string prefix = key.Substring(0, l);
            if (!sums.ContainsKey(prefix)) sums[prefix] = 0;
            sums[prefix] += diff;
        }
    }
    
    public int Sum(string prefix) {
        if (string.IsNullOrEmpty(prefix) || !sums.ContainsKey(prefix)) return 0;
        return sums[prefix];
    }
}
// Trie
public class MapSum {
    TrieNode root = new TrieNode();
    Dictionary<string, int> vals = new Dictionary<string,int>();
    public MapSum() {}
    
    public void Insert(string key, int val) {
        int diff = val;
        if (vals.ContainsKey(key)) diff -= vals[key];
        vals[key] = val;
        var ptr = root;
        foreach (char c in key) {
            int idx = c - 'a';
            if (ptr.nodes[idx] == null) ptr.nodes[idx] = new TrieNode();
            ptr = ptr.nodes[idx];
            ptr.sum += diff;
        }
        ptr.word = key;
    }
    
    public int Sum(string prefix) {
        var ptr = root;
        foreach (char c in prefix) {
            if (ptr.nodes[c - 'a'] == null) return 0;
            ptr = ptr.nodes[c - 'a'];
        }
        return ptr.sum;
    }
}
public class TrieNode {
    public int sum;
    public string word;
    public TrieNode[] nodes;
    public TrieNode() {
        sum = 0;
        word = null;
        nodes = new TrieNode[26];
    }
}
/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */
