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
    
    public int LongestUnivaluePath(TreeNode root) {
        int ans = 0;
        Func<TreeNode, int> f = null;
        f = (node) => {
            if (node == null) return 0;
            int left = f(node.left);
            int right = f(node.right);
            int l = 0, r = 0;
            if (node.left != null && node.val == node.left.val) l = left + 1;
            if (node.right != null && node.val == node.right.val) r = right + 1;
            // count edge, not node => both sides + 1
            // path from left to root, to right
            ans = Math.Max(ans, l + r);
            // a subtree path => only count one side
            return Math.Max(l, r);
        };
        f(root);
        return ans;
    }
}
