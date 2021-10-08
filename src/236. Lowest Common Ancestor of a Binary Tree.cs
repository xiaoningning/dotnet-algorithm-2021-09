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
    // p and q must exist in root
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root.val == p.val || root.val == q.val) return root;
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if (left != null && right != null) return root;
        else return left != null ? left : right;
    }
    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q) {
        Func<TreeNode, TreeNode, bool> findT = null;
        findT = (node, t) => {
            if (node == null) return false;
            if (node.val == t.val) return true;
            else {
                var left = findT(node.left, t);
                var right = findT(node.right, t);
                return left || right;
            }
        };
        // p or q might not be in tree
        if (root == null || !findT(root, p) || !findT(root, q)) return null;
        if (root.val == p.val || root.val == q.val) return root;
        if (findT(root.left, p) && findT(root.left, q)) return LowestCommonAncestor(root.left, p, q);
        if (findT(root.right, p) && findT(root.right, q)) return LowestCommonAncestor(root.right, p, q);
        else return root;
    }
}
