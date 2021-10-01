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
    public ListNode InsertionSortList(ListNode head) {
        var ans = new ListNode();
        var ptr = ans;
        while (head != null) {
            var t = head.next;
            ptr = ans; // reset ptr to the head of list
            while (ptr.next != null && ptr.next.val <= head.val) ptr = ptr.next;
            // insert head into the list
            head.next = ptr.next;
            ptr.next = head;
            head = t;
        }
        return ans.next;
    }
}
