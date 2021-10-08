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
    public int DiameterOfBinaryTree(TreeNode root) {
        int ans = 0;
        Func<TreeNode, int> f = null;
        f = (node) => {
            if (node == null) return 0;
            int left = f(node.left);
            int right = f(node.right);
            // diameter := hights of left + right
            ans = Math.Max(ans, left + right);
            // hight of subtree
            return 1 + Math.Max(left, right); 
        };
        f(root);
        return ans;
    }
}
