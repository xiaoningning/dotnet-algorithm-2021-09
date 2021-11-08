public class AutocompleteSystem {
    Dictionary<string, int> freq = new Dictionary<string,int>();
    string str = "";
    public AutocompleteSystem(string[] sentences, int[] times) {
        for (int i = 0; i < times.Length; i++) {
            if (!freq.ContainsKey(sentences[i])) freq[sentences[i]] = 0;
            freq[sentences[i]] += times[i];
        }
        str = "";
    }
    
    public IList<string> Input(char c) {
        var ans = new List<string>();
        if (c == '#') {
            if (!freq.ContainsKey(str)) freq[str] = 0;
            freq[str]++; str = "";
            return ans;
        }
        str += c;
        var q = new List<(string,int)>(); // priority queue
        foreach (var kv in freq) {
            if(!kv.Key.StartsWith(str)) continue;
            q.Add((kv.Key, kv.Value));
            q.Sort((x,y) => x.Item2 == y.Item2 ? x.Item1.CompareTo(y.Item1) : y.Item2 - x.Item2);
            if (q.Count > 3) q.RemoveAt(q.Count - 1);
        }

        for (int i = 0; i < q.Count; i++) {
            ans.Add(q[i].Item1);
        }
        return ans;
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */
