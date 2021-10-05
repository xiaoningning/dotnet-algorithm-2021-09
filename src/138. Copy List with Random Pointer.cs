/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    Dictionary<Node, Node> m = new Dictionary<Node, Node>();
    public Node CopyRandomList(Node head) {
        if (head == null) return head;
        if (m.ContainsKey(head)) return m[head];
        var ptr = new Node(head.val);
        m[head] = ptr;
        ptr.next = CopyRandomList(head.next);
        ptr.random = CopyRandomList(head.random);
        return ptr;
    }
}
