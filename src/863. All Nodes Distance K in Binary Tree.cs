/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        var g = new Dictionary<TreeNode, List<TreeNode>>();
        Action<TreeNode,TreeNode> buildG = null;
        buildG = (node, prev) => {
            if (node == null) return;
            if (!g.ContainsKey(node)) g[node] = new List<TreeNode>();
            if (prev != null) g[node].Add(prev);
            if (node.left != null) g[node].Add(node.left);
            if (node.right != null) g[node].Add(node.right);
            buildG(node.left, node); 
            buildG(node.right, node);
        };
        buildG(root, null);
        var ans = new List<int>();
        var visited = new HashSet<int>(){target.val};
        var q = new Queue<TreeNode>();
        q.Enqueue(target);
        while (q.Any()) {
            int size = q.Count;
            while (--size >= 0) {
                var t = q.Dequeue();
                if (k == 0) ans.Add(t.val);
                else {
                    foreach (var nx in g[t]) {
                        if (visited.Contains(nx.val)) continue;
                        visited.Add(nx.val);
                        q.Enqueue(nx);
                    }
                }
            }
            k--;
        }
        return ans;
    }
}
