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
    // recursion T: O(n^2) S: O(n)
    public int PathSum1(TreeNode root, int targetSum) {
        if (root == null) return 0;
        Func<TreeNode, int, int> numOfPath = null;
        numOfPath = (node, sum) => {
            if (node == null) return 0;
            sum -= node.val;
            return (sum == 0 ? 1 : 0) + numOfPath(node.left, sum) + numOfPath(node.right, sum);
        };
        return numOfPath(root, targetSum) + PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
    }
    // prefix sum similar to LC. 560 Subarray Sum Equals K
    // T: O(n) S: O(h)
    public int PathSum(TreeNode root, int targetSum) {
        var d = new Dictionary<int,int>(){[0] = 1};
        int ans = 0;
        Action<TreeNode, int> f = null;
        f = (node, sum) => {
            if (node == null) return;
            sum += node.val;
            if (d.ContainsKey(sum - targetSum)) ans += d[sum - targetSum];
            if (!d.ContainsKey(sum)) d[sum] = 0;
            d[sum]++;
            f(node.left, sum);
            f(node.right, sum);
            // root to leave,
            // one side node could not be used in another side
            // => d[sum]--
            d[sum]--; 
        };
        f(root, 0);
        return ans;
    }
}
