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
    // BFS
    public int DeepestLeavesSum1(TreeNode root) {
        if (root == null) return 0;
        var ans = new List<int>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Any()) {
            int size = q.Count;
            ans = new List<int>();
            while (--size >= 0) {
                var node = q.Dequeue();
                ans.Add(node.val);
                // deepest level
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }
        return ans.Sum();
    }
    // recursion
    public int DeepestLeavesSum(TreeNode root) {
        if (root == null) return 0;
        int ans = 0, mx = 0;
        Action<TreeNode, int> BFS = null;
        BFS = (node, level) => {
            if (node == null) return;
            if (level > mx) {
                mx = level;
                ans = 0; // reset sum of new level
            }
            if (level == mx) ans += node.val;
            BFS(node.left, level + 1);
            BFS(node.right, level + 1);
        };
        BFS(root, mx);
        return ans;
    }
}
