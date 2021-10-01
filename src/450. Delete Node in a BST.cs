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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) return root;
        if (key < root.val) root.left = DeleteNode(root.left, key);
        else if (key > root.val) root.right = DeleteNode(root.right, key);
        else { // find the key
            if (root.right != null) {
                var ptr = root.right;
                while (ptr.left != null) ptr = ptr.left;
                ptr.left = root.left;
                return root.right;
            }
            else return root.left;
        }
        return root;
    }
}
