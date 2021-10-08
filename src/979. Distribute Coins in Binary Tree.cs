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
    public int DistributeCoins(TreeNode root) {
        int ans = 0;
        Func<TreeNode, int> getMoves = null;
        getMoves = (node) => {
            if (node == null) return 0;
            int left = getMoves(node.left);
            int right = getMoves(node.right);
            // # of moves for children := each side ABS(moves)
            ans += Math.Abs(left) + Math.Abs(right);
            // # of moves of this subtree, including node
            // node needs to keep one coin
            return left + right + node.val - 1;
        };
        getMoves(root);
        return ans;
    }
}
