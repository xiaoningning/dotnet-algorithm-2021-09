/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor1(Node p, Node q) {
        Node ptrp = p, ptrq = q;
        while (ptrp != ptrq) {
            ptrp = ptrp != null ? ptrp.parent : q;
            ptrq = ptrq != null ? ptrq.parent : p;
        }
        return ptrp;
    }
    public Node LowestCommonAncestor(Node p, Node q) {
        var st = new HashSet<Node>();
        while (p != null && st.Add(p)) p = p.parent;
        while (q != null && !st.Contains(q)) q = q.parent;
        return q;
    }
}
