public class MinStack {
    Stack<int> s = new Stack<int>();
    Stack<int> mns = new Stack<int>();
    public MinStack() { }
    
    public void Push(int val) {
        if (!mns.Any() || mns.Peek() >= val) mns.Push(val);
        s.Push(val);
    }
    
    public void Pop() {
        if (s.Peek() == mns.Peek()) mns.Pop();
        s.Pop();
    }
    
    public int Top() {
        return s.Peek();
    }
    
    public int GetMin() {
        return mns.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
