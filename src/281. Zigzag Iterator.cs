public class ZigzagIterator {
    List<int> v = new List<int>(); // can handle the follow up and cyclic
    int idx = 0;
    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        int n1 = v1.Count, n2 = v2.Count, n = Math.Max(n1, n2);
        for (int i = 0; i < n; i++) {
            if (i < n1) v.Add(v1[i]);
            if (i < n2) v.Add(v2[i]);
        }
    }

    public bool HasNext() {
        return idx < v.Count;
    }

    public int Next() {
        return v[idx++];
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */
