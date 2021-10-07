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
    public int MaxPathSum(TreeNode root) {
        int ans = Int32.MinValue;
        Func<TreeNode, int> pathSum = null;
        pathSum = (node) => {
            if (node == null) return 0;
            // node val can be < 0
            int left = Math.Max(0, pathSum(node.left));
            int right = Math.Max(0, pathSum(node.right));
            ans = Math.Max(ans, node.val + left + right);
            return node.val + Math.Max(left, right);
        };
        pathSum(root);
        return ans;
    }
}
