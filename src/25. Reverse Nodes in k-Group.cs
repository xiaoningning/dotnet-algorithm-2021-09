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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null || k == 1) return head;
        var dummy = new ListNode(0);
        dummy.next = head;
        int len = 0;
        while (head != null) { head = head.next; len++; }
        var prev = dummy;
        for (int i = 0; i + k <= len; i += k) {
            var cur = prev.next;
            for (int j = 1; j < k; j++) { // reverse within group
                var nx = cur.next;
                cur.next = nx.next;
                nx.next = prev.next;
                prev.next = nx;
            }
            prev = cur;
        }
        return dummy.next;
    }
    // recursion
    public ListNode ReverseKGroup2(ListNode head, int k) {
        if (head == null || k == 1) return head;
        var cur = head;
        for (int i = 0; i < k; i++)  {
            if (cur == null) return head; // k > the length of listnode head
            cur = cur.next;
        }
        var newHead = ReverseGroup(head, cur);
        head.next = ReverseKGroup(cur, k);
        return newHead;
    }
    ListNode ReverseGroup(ListNode head, ListNode tail) {
        var prev = tail;
        while (head != tail) {
            var nx = head.next;
            head.next = prev;
            prev = head;
            head = nx;
        }
        return prev;
    }
}
