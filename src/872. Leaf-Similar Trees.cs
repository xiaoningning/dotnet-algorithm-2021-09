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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        Action<TreeNode, List<int>> getL = null;
        getL= (node, cur) => {
            if (node == null) return;
            if (node.left == null && node.right == null) cur.Add(node.val);
            getL(node.left, cur); 
            getL(node.right, cur);
        };
        var l1 = new List<int>();
        var l2 = new List<int>();
        getL(root1, l1);
        getL(root2, l2);
        if (l1.Count != l2.Count) return false;
        for (int i = 0; i < l1.Count; i++) if (l1[i] != l2[i]) return false;
        return true;
    }
}
