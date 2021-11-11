public class Vector2D1 {
    List<int> v = new List<int>(); 
    int idx = 0;
    public Vector2D1(int[][] vec) {
        foreach (var x in vec) foreach (var n in x) v.Add(n);
    }
    
    public int Next() {
        if (!HasNext()) return -1;
        return v[idx++];
    }
    
    public bool HasNext() {
        return idx < v.Count;
    }
}

public class Vector2D {
    int[][] data;
    int x = 0;
    int y = 0;
    public Vector2D(int[][] vec) {
        data = (int[][])vec.Clone();
    }
    
    public int Next() {
        if (!HasNext()) return -1;
        return data[x][y++];
    }
    
    public bool HasNext() {
        while (x < data.Length && y == data[x].Length) {
            ++x; 
            y = 0;
        }
        return x < data.Length;
    }
}

/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(vec);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
