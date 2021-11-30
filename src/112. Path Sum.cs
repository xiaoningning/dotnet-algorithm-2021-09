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
    public bool HasPathSum1(TreeNode root, int targetSum) {
        if (root == null) return false;
        if (root.left == null && root.right == null && root.val == targetSum) return true;
        else return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null) return false;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Any()) {
            var t = q.Dequeue();
            if (t.left == null && t.right == null && t.val == targetSum) return true;
            if (t.left != null) {
                t.left.val += t.val;
                q.Enqueue(t.left);
            }
            if (t.right != null) {
                t.right.val += t.val;
                q.Enqueue(t.right);
            }
        }
        return false;
    }
}
