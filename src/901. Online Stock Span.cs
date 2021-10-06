public class StockSpanner {
    // monotonic stack (price, span/cnt)
    Stack<(int, int)> st = new Stack<(int,int)>();
    public StockSpanner() {}
    
    public int Next(int price) {
        int span = 1;
        while (st.Any() && st.Peek().Item1 <= price) span += st.Pop().Item2;
        st.Push((price, span));
        return span;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
