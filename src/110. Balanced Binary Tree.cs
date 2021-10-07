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
    public bool IsBalanced(TreeNode root) {
        Func<TreeNode, int> getH = null;
        getH = (node) => {
            if (node == null) return 0;
            return 1 + Math.Max(getH(node.left), getH(node.right));
        };
        if (root == null) return true;
        if (Math.Abs(getH(root.left) - getH(root.right)) > 1) return false;
        else return IsBalanced(root.left) && IsBalanced(root.right);
    }
}
