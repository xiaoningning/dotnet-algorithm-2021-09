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
    public TreeNode RemoveLeafNodes(TreeNode root, int target) {
        if (root == null) return null;
        root.left = RemoveLeafNodes(root.left, target);
        root.right = RemoveLeafNodes(root.right, target);
        // remove children leaves first, then root could be leave then
        if (root.val == target && root.left == null && root.right == null) return null;
        return root;
    }
}
