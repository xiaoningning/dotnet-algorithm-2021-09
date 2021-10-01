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
    // insert sort O(n^2), S: O(1)
    // merge sort O(nlogn), S: O(logn)
    // top down merge sort
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null) return head;
        ListNode slow = head, fast = head, ptr = head;
        while (fast != null && fast.next != null) {
            ptr = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        ptr.next = null; // split into two lists
        return MergeTwoLists(SortList(head), SortList(slow));
    }
    ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        if (l1.val < l2.val) {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else {
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}
