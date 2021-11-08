public class FreqStack {
    Dictionary<int,int> f = new Dictionary<int,int>(); // val: freq
    List<List<int>> stack = new List<List<int>>(); // as stack
    public FreqStack() {}
    // O(1)
    public void Push(int val) {
        if (!f.ContainsKey(val)) f[val] = 0;
        int freq = ++f[val];
        if (stack.Count < freq) stack.Add(new List<int>());
        stack[freq - 1].Add(val);
    }
    // O(1)
    public int Pop() {
        int x = stack.Last().Last();
        stack.Last().RemoveAt(stack.Last().Count - 1);
        if (!stack.Last().Any()) stack.RemoveAt(stack.Count - 1);
        --f[x];
        if (f[x] == 0) f.Remove(x);
        return x;
    }
}

public class FreqStack1 {
    int mxFreq = 0;
    Dictionary<int,int> f = new Dictionary<int,int>(); // val: freq
    Dictionary<int,List<int>> d = new Dictionary<int,List<int>>(); // freq: list of vals
    public FreqStack1() {}
    // O(1)
    public void Push(int val) {
        if (!f.ContainsKey(val)) f[val] = 0;
        mxFreq = Math.Max(mxFreq, ++f[val]);
        if (!d.ContainsKey(f[val])) d[f[val]] = new List<int>();
        d[f[val]].Add(val);
    }
    // O(1)
    public int Pop() {
        if (!d[mxFreq].Any()) return Int32.MinValue;
        int x = d[mxFreq].Last();
        d[mxFreq].RemoveAt(d[mxFreq].Count - 1);
        f[x]--;
        if (f[x] == 0) f.Remove(x);
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
