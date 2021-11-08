public class MaxStack {
    Stack<int> s = new Stack<int>();
    Stack<int> mxs = new Stack<int>();
    public MaxStack() { }
    
    public void Push(int x) {
        if (!mxs.Any() || mxs.Peek() <= x) mxs.Push(x);
        s.Push(x);
    }
    
    public int Pop() {
        if (s.Peek() == mxs.Peek()) mxs.Pop();
        return s.Pop();
    }
    
    public int Top() {
        return s.Peek();
    }
    
    public int PeekMax() {
        return mxs.Peek();
    }
    
    public int PopMax() {
        int mx = mxs.Pop();
        var t = new Stack<int>();
        while (mx != s.Peek()) t.Push(s.Pop());
        s.Pop();
        while (t.Any()) Push(t.Pop()); // call Push to update mxs
        return mx;
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */
