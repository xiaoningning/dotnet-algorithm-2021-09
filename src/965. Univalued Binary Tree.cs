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
    // inorder
    public bool IsUnivalTree1(TreeNode root) {
        TreeNode prev = null;
        Func<TreeNode, bool> inOrder = null;
        inOrder = (node) => {
            if (node == null) return true;
            if (!inOrder(node.left)) return false;
            if (prev != null && prev.val != node.val) return false;
            prev = node;
            return inOrder(node.right);
        };
        return inOrder(root);
    }
    public bool IsUnivalTree(TreeNode root) {
        if (root == null) return true;
        if (root.left != null && root.left.val != root.val) return false;
        if (root.right != null && root.right.val != root.val) return false;
        return IsUnivalTree(root.left) && IsUnivalTree(root.right);
    }
}
