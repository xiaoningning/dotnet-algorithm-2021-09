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
// recursion
public class Solution {
    public IList<TreeNode> GenerateTrees(int n) {
        if (n == 0) return new List<TreeNode>();
        Func<int,int, List<TreeNode>> f = null;
        f = (l, r) => {
            var ans = new List<TreeNode>(){};
            if (l > r) {ans.Add(null); return ans;}
            for (int k = l; k <= r; k++) {
                var left = f(l, k-1);
                var right = f(k+1, r);
                foreach (var x in left) {
                    foreach (var y in right) {
                        var node = new TreeNode(k);
                        node.left = x;
                        node.right = y;
                        ans.Add(node);
                    }
                }
            }
            return ans;
        };
        return f(1,n);
    }
}
