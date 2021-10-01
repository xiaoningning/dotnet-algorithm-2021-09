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
    public int KthSmallest(TreeNode root, int k) {
        Func<TreeNode, int> getCnt = null;
        getCnt = (node) => {
            if (node == null) return 0;
            else return 1 + getCnt(node.left) + getCnt(node.right);
        };
        int n = getCnt(root.left);
        if (k <= n) return KthSmallest(root.left, k);
        else if (k > n + 1) return KthSmallest(root.right, k - n - 1);
        else return root.val;
    }
}
