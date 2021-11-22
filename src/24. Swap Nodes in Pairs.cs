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
    // recursion
    public ListNode SwapPairs1(ListNode head) {
        if (head == null || head.next == null) return head;
        var ans = head.next;
        head.next = SwapPairs(head.next.next);
        ans.next = head;
        return ans;
    }
    
    // two tmp nodes. easy to read
    public ListNode SwapPairs(ListNode head) {
        ListNode ans = new ListNode();
        ans.next = head;
        // create a object as pointer in c# or java
        ListNode ptr = ans;
        while (ptr.next != null && ptr.next.next != null) {
            var first = ptr.next; // head
            var second = ptr.next.next; // head.next
            first.next = second.next; // swap first and second
            second.next = first;
            ptr.next = second; // move the pointer
            ptr.next.next = first;
            ptr = first; // move to the new first
        }
        return ans.next;
    }
}
