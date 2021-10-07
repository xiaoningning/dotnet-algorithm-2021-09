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
    // DFS
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        var ans = new List<IList<int>>();
        Action<TreeNode, List<int>> DFS = null;
        DFS = (node, cur) => {
            if (node == null) return;
            if (node.left == null && node.right == null) {
                if (cur.Sum() + node.val == targetSum) {
                    // cur will be used on another path => don't add node.val
                    ans.Add(new List<int>(cur));
                    ans.Last().Add(node.val);
                }
                return;
            }
            cur.Add(node.val);
            DFS(node.left, cur);
            DFS(node.right, cur);
            cur.RemoveAt(cur.Count - 1); // list.remove != list.removeAt !!!
        };
        DFS(root, new List<int>());
        return ans;
    }
}
