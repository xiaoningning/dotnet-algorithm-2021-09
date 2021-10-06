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
    // Inoder BST
    public void RecoverTree(TreeNode root) {
        TreeNode prev = null, x = null, y = null;
        Action<TreeNode> inOrder = null;
        inOrder = (node) => {
            if (node == null) return;
            inOrder(node.left);
            if (prev != null && prev.val > node.val) {
                // once find a misorder node,
                // it needs to be swapped with 2nd one
                // since only two nodes swapped.
                if (x == null) x = prev;
                y = node;
            }
            prev = node;
            inOrder(node.right);
        };
        inOrder(root);
        int t = x.val;
        x.val = y.val;
        y.val = t;
    }
}
