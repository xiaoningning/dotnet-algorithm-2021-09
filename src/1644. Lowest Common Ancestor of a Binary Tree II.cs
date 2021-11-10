/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    // different from LC. 236
    // NOT guaranteed that both p and q are in the tree.
    // A node can still be a descendant of itself.
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        int found = 0;
        Func<TreeNode, TreeNode> lca = null;
        lca = (node) => {
            if (node == null) return null;
            var left = lca(node.left);
            var right = lca(node.right);
            if (node == p || node == q)  {
                found++;
                return node;
            }
            return left == null ? right : right == null ? left : node;
        };
        var ans = lca(root);
        return found == 2 ? ans : null;
    }
}
