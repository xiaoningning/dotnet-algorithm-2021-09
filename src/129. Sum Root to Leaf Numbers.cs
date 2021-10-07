/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int SumNumbers(TreeNode root) {
        if (root == null) return 0;
        int ans = 0;
        Action<TreeNode, int> f = null;
        f = (node, prev) => {
            if (node == null) return;
            prev = prev * 10 + node.val;
            if (node.left != null || node.right != null) {
                f(node.left, prev);
                f(node.right, prev);
            }
            else ans += prev; // leave case
        };
        f(root, 0);
        return ans;
    }
    public int SumNumbers1(TreeNode root) {
        if (root == null) return 0;
        int ans = 0;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var prev = q.Dequeue();
                if (prev.left != null) { 
                    prev.left.val += prev.val * 10;
                    q.Enqueue(prev.left);
                }
                if (prev.right != null) { 
                    prev.right.val += prev.val * 10;
                    q.Enqueue(prev.right);
                }
                if (prev.left == null && prev.right == null) ans += prev.val;
            }
        }
        return ans;
    }
}
