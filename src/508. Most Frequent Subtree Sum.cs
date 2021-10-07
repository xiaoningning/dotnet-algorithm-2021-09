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
    public int[] FindFrequentTreeSum(TreeNode root) {
        int mx = 0;
        var d = new Dictionary<int,int>();
        var ans = new List<int>();
        Func<TreeNode, int> f = null;
        f = (node) => {
            if (node == null) return 0;
            int sum = node.val + f(node.left) + f(node.right);
            if (!d.ContainsKey(sum)) d[sum] = 0;
            int freq = ++d[sum];
            if (freq > mx) {
                mx = freq;
                ans.Clear();
            }
            if (freq == mx) ans.Add(sum);
            return sum;
        };
        f(root);
        return ans.ToArray();
    }
}
