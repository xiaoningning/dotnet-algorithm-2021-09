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
    // inorder
    public int GetMinimumDifference3(TreeNode root) {
        int ans = Int32.MaxValue;
        TreeNode prev = null;
        Action<TreeNode> inOrder = null;
        inOrder = (node) => {
            if (node == null) return;
            inOrder(node.left);
            if (prev != null) ans = Math.Min(ans, node.val - prev.val);
            prev = node;
            inOrder(node.right);
        };
        inOrder(root);
        return ans;
    }
    // check bst
    public int GetMinimumDifference2(TreeNode root) {
        int ans = Int32.MaxValue;
        Action<TreeNode, int, int> f = null;
        f = (node, low, high) => {
            if (node == null) return;
            if (low != Int32.MinValue) ans = Math.Min(ans, node.val - low);
            if (high != Int32.MaxValue) ans = Math.Min(ans, high - node.val);
            f(node.left, low, node.val);
            f(node.right, node.val, high);
        };
        f(root, Int32.MinValue, Int32.MaxValue);
        return ans;
    }
    // similar idea to check bst
    public int GetMinimumDifference(TreeNode root) {
        if (root == null) return Int32.MaxValue;
        Func<TreeNode, int> getMx = (node) => {
            var ptr = node;
            while (node != null) { ptr = node; node = node.right; }
            return ptr != null ? ptr.val : Int32.MaxValue/ 2;
        };
        Func<TreeNode, int> getMn = (node) => {
            var ptr = node;
            while (node != null) { ptr = node; node = node.left; }
            return ptr != null ? ptr.val : Int32.MaxValue / 2;
        };
        // avoid overflow without check int32.min or int32.max
        var t = new int[]{Math.Abs(root.val - getMx(root.left)), 
                         Math.Abs(getMn(root.right) - root.val), 
                         GetMinimumDifference(root.left), 
                         GetMinimumDifference(root.right)};
        return t.Min();
    }
}
