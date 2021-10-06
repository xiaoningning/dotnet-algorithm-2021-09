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
    // BFS + recursion traverse
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        int mn = Int32.MaxValue;
        int mx = Int32.MinValue;
        var d = new Dictionary<int, List<(int, int)>>();
        Action<TreeNode, int, int> BFS = null;
        BFS = (node, v, l) => {
            if (node == null) return;
            mn = Math.Min(mn, v);
            mx = Math.Max(mx, v);
            if (!d.ContainsKey(v)) d[v] = new List<(int, int)>();
            d[v].Add((l, node.val));
            BFS(node.left, v - 1, l + 1);
            BFS(node.right, v + 1, l + 1);
        };
        BFS(root, 0, 0);
        var ans = new List<IList<int>>();
        for (int i = mn; i <= mx; i++) {
            d[i].Sort((x,y) => x.Item1 == y.Item1 ? x.Item2 - y.Item2 : x.Item1 - y.Item1);
            ans.Add(new List<int>());
            foreach (var x in d[i]) ans.Last().Add(x.Item2);
        }
        return ans;
    }
}
