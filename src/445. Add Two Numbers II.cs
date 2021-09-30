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
    // stack
    public ListNode AddTwoNumbers1(ListNode l1, ListNode l2) {
        var s1 = new Stack<int>();
        var s2 = new Stack<int>();
        while (l1 != null) { s1.Push(l1.val); l1 = l1.next; }
        while (l2 != null) { s2.Push(l2.val); l2 = l2.next; }
        ListNode ptr = null;
        int sum = 0;
        while (s1.Any() || s2.Any() || sum != 0) {
            sum += s1.Any() ? s1.Pop() : 0;
            sum += s2.Any() ? s2.Pop() : 0;
            var n = new ListNode(sum % 10, ptr);
            sum /= 10;
            ptr = n;
        }
        return ptr;
    }
    // recursion without reverse linked list
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        Func<ListNode, int> getCnt = (l) => {
            int cnt = 0;
            while (l != null) { cnt++; l = l.next; }
            return cnt;
        };
        
        Func<ListNode, ListNode, (ListNode Node, int Carry)> addTwo = null;
        addTwo = (x1, x2) => {
            // x1 is always longer x2
            if (x1 == null) return (null, 0);
            int cnt1 = getCnt(x1), cnt2 = getCnt(x2);
            var nx = cnt1 > cnt2 ? addTwo(x1.next, x2) : addTwo(x1.next, x2.next);
            int v = nx.Carry + (cnt1 > cnt2 ? x1.val : x1.val + x2.val);
            return (new ListNode(v % 10, nx.Node), v / 10);
        };
        
        int n1 = getCnt(l1), n2 = getCnt(l2);
        var ans = n1 > n2 ? addTwo(l1, l2) : addTwo(l2, l1);
        if (ans.Carry == 0) return ans.Node;
        else return new ListNode(1, ans.Node);
    }
}
