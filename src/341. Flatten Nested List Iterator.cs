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
public class NestedIterator {
    Stack<NestedInteger> st;
    public NestedIterator(IList<NestedInteger> nestedList) {
        st = new Stack<NestedInteger>();
        for (int i = nestedList.Count - 1; i >= 0; i--) st.Push(nestedList[i]);
    }

    public bool HasNext() {
        while (st.Any()) {
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

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
