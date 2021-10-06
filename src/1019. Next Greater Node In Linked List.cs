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
// Monotonic stack T: O(n)
public class Solution {
    public int[] NextLargerNodes(ListNode head) {
        var nums = new List<int>();
        while (head != null) { 
            nums.Add(head.val); 
            head = head.next; 
        }
        int n = nums.Count;
        var ans = new int[n];
        var st = new Stack<int>();
        for (int i = n - 1; i >= 0; i--) {
            while (st.Any() && st.Peek() <= nums[i]) st.Pop();
            if(st.Any()) ans[i] = st.Peek();
            st.Push(nums[i]);
        }
        return ans;
    }
}
