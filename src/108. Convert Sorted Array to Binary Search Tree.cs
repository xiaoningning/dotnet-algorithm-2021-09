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
    public TreeNode SortedArrayToBST(int[] nums) {
        Func<int,int, TreeNode> f = null;
        f = (l, r) => {
            if (l > r) return null;
            int m = l + (r - l) / 2;
            var node = new TreeNode(nums[m]);
            node.left = f(l, m - 1);
            node.right = f(m + 1, r);
            return node;
        };
        return f(0, nums.Length - 1);
    }
}
