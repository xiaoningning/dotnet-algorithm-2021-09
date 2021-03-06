/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator1 {
    Stack<NestedInteger> st;
    public NestedIterator1(IList<NestedInteger> nestedList) {
        st = new Stack<NestedInteger>();
        for (int i = nestedList.Count - 1; i >= 0; i--) st.Push(nestedList[i]);
    }

    public bool HasNext() {
        while (st.Any()) { // multi level nested [1,[4, [6]]]
            var nx = st.Peek();
            if (nx.IsInteger()) return true;
            nx = st.Pop();
            foreach (var ni in nx.GetList().Reverse()) st.Push(ni); // Stack, it has to be reserved!!!
        }
        return false; // st empty
    }

    public int Next() {
        return st.Pop().GetInteger();
    }
}

public class NestedIterator {
    Queue<int> q = new Queue<int>();
    public NestedIterator(IList<NestedInteger> nestedList) {
        AddQueue(nestedList);
    }

    public bool HasNext() {
       return q.Any();
    }

    public int Next() {
        return q.Dequeue();
    }
    void AddQueue(IList<NestedInteger> nestedList) {
        foreach (var ni in nestedList) {
            if (ni.IsInteger()) q.Enqueue(ni.GetInteger());
            else AddQueue(ni.GetList());
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
