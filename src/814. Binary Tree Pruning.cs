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
    // T: O(n)
    public TreeNode PruneTree(TreeNode root) {
        if (root == null) return null;
        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);
        // not containing 1 should be removed, left/right != null => contains 1 then
        return (root.val == 1 || root.left != null || root.right != null) ? root : null;
    }
}
