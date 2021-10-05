/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    // T: O(V+E)
    Dictionary<Node, Node> m = new Dictionary<Node, Node>();
    public Node CloneGraph1(Node node) {
        if (node == null) return null;
        if (m.ContainsKey(node)) return m[node];
        var ptr = new Node(node.val);
        // the graph can be cycled back to head => save m first there
        m[node] = ptr; 
        foreach (var c in node.neighbors) {
            ptr.neighbors.Add(CloneGraph(c));
        }
        return m[node];
    }
    // BFS
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        if (m.ContainsKey(node)) return m[node];
        var q = new Queue<Node>();
        m[node] = new Node(node.val);
        q.Enqueue(node);
        while (q.Any()) {
            var t = q.Dequeue();
            foreach (var c in t.neighbors) {
                if (!m.ContainsKey(c)) m[c] = CloneGraph(c);
                m[t].neighbors.Add(m[c]);
            }
        }
        return m[node];
    }
}
