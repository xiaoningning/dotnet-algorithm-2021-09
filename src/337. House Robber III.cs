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
    // recursion + memo, without memo => TLE
    Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();
    public int Rob(TreeNode root) {
        if (root == null) return 0;
        if (memo.ContainsKey(root)) return memo[root];
        Func<TreeNode, bool,int> f = null;
        f = (node, rob) => {
            if (node == null) return 0;
            if (rob) return node.val + f(node.left, false) + f(node.right, false);
            else {
                int left = Rob(node.left);
                int right = Rob(node.right);
                return left + right;
            }
        };
        return memo[root] = Math.Max(f(root, false), f(root, true));
    }
    // recursion with children' val, no need for memo
    public int Rob2(TreeNode root) {
        Func<TreeNode,(int rob, int noRob)> DFS = null;
        DFS = (node) => {
            if (node == null) return (0, 0);
            var left = DFS(node.left);
            var right = DFS(node.right);
            int r = node.val + left.noRob + right.noRob;
            int nR = Math.Max(left.rob, left.noRob) + Math.Max(right.rob, right.noRob);
            return (r, nR);
        };
        var ans = DFS(root);
        return Math.Max(ans.rob, ans.noRob);
    }
}
