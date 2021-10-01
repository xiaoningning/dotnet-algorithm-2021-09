/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList1(ListNode head) {
        if (head == null || head.next == null) return head;
        var n = ReverseList(head.next);
        // base case to reverse two nodes
        head.next.next = head;
        head.next = null;
        return n;
    }
    public ListNode ReverseList(ListNode head) {
        ListNode pre = null;
        while (head != null) {
            var t = head.next;
            head.next = pre;
            pre = head;
            head = t;
        }
        return pre;
    }
}
