public class FreqStack {
    int mxFreq = 0;
    Dictionary<int,int> f = new Dictionary<int,int>(); // val: freq
    Dictionary<int,List<int>> d = new Dictionary<int,List<int>>(); // freq: list of vals
    public FreqStack() {}
    
    public void Push(int val) {
        if (!f.ContainsKey(val)) f[val] = 0;
        mxFreq = Math.Max(mxFreq, ++f[val]);
        if (!d.ContainsKey(f[val])) d[f[val]] = new List<int>();
        d[f[val]].Add(val);
    }
    
    public int Pop() {
        if (!d[mxFreq].Any()) return Int32.MinValue;
        int x = d[mxFreq].Last();
        d[mxFreq].RemoveAt(d[mxFreq].Count - 1);
        f[x]--;
        if (!d[mxFreq].Any()) mxFreq--;
        return x;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */
