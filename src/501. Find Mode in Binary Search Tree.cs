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
    // no extra space, otherwise map count of each node.val
    public int[] FindMode(TreeNode root) {
        var ans = new List<int>();
        int mx = 0, cnt = 0;
        TreeNode prev = null;
        Action<TreeNode> inOrder = null;
        inOrder = (node) => {
            if (node == null) return;
            inOrder(node.left);
            cnt = prev != null && prev.val == node.val ? cnt + 1 : 1;
            if (cnt >= mx) {
                if (cnt > mx) ans.Clear();
                mx = cnt;
                ans.Add(node.val);
            }
            prev = node;
            inOrder(node.right);
        };
        inOrder(root);
        return ans.ToArray();
    }
}
