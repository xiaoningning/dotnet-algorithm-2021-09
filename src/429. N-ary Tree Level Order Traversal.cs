/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
// BFS
public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var ans = new List<IList<int>>();
        if (root == null) return ans;
        var q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Any()) {
            int size = q.Count;
            var t = new List<int>();
            while (--size >= 0) {
                var p = q.Dequeue();
                t.Add(p.val);
                foreach (var c in p.children) q.Enqueue(c);
            }
            ans.Add(t);
        }
        return ans;
    }
}
