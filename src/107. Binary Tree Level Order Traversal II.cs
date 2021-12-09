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
    public IList<IList<int>> LevelOrderBottom1(TreeNode root) {
        var ans = new List<IList<int>>();
        Action<TreeNode, int> f = null;
        f = (node, level) => {
            if (node == null) return;
            if (level > ans.Count - 1) ans.Add(new List<int>());
            ans[level].Add(node.val);
            f(node.left, level+1);
            f(node.right, level+1);
        };
        f(root,0);
        ans.Reverse();
        return ans;
    }
    // BFS
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        var ans = new List<IList<int>>();
        if (root == null) return ans;
        var cur = new Queue<TreeNode>();
        cur.Enqueue(root);
        while (cur.Any()) {
            ans.Insert(0, new List<int>());
            var next = new Queue<TreeNode>();
            foreach (var t in cur) {
                ans.First().Add(t.val);
                if (t.left != null) next.Enqueue(t.left);
                if (t.right != null) next.Enqueue(t.right);
            }
            cur = next;
        }
        return ans;
    }
}
