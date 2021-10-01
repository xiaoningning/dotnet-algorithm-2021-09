/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
        next = null;
    }

    public Node(int _val, Node _next) {
        val = _val;
        next = _next;
    }
}
*/

public class Solution {
    public Node Insert(Node head, int insertVal) {
        if (head == null) { 
            head = new Node(insertVal);
            head.next = head; // must create a circular list
            return head;
        }
        Node pre = head, cur = head.next;
        // it is circular, no null at the end
        while (cur != head) {
            // normal case
            if (pre.val <= insertVal && insertVal <= cur.val) break;
            // circular back now
            if (pre.val > cur.val && (insertVal >= pre.val || insertVal <= cur.val)) break;
            pre = pre.next;
            cur = cur.next;
        }
        pre.next = new Node(insertVal, cur);
        return head;
    }
}
