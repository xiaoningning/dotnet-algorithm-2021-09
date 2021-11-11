public class ZigzagIterator1 {
    List<int> v = new List<int>(); // can handle the follow up and cyclic
    int idx = 0;
    public ZigzagIterator1(IList<int> v1, IList<int> v2) {
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
        if (!HasNext()) return -1;
        return v[idx++];
    }
}
public class ZigzagIterator {
    List<IList<int>> v = new List<IList<int>>();
    int idx = 0, i = 0,  j = 0;
    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        v.Add(v1);
        v.Add(v2);
        i = j = 0;
    }

    public bool HasNext() {
        if (i >= v[0].Count) i = Int32.MaxValue;
        if (j >= v[1].Count) j = Int32.MaxValue;
        return i < v[0].Count || j < v[1].Count;
    }

    public int Next() {
        if (!HasNext()) return -1;
        if (i == Int32.MaxValue) return v[1][j++];
        else if (j == Int32.MaxValue) return v[0][i++];
        else return i <= j ? v[0][i++] : v[1][j++];
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */
