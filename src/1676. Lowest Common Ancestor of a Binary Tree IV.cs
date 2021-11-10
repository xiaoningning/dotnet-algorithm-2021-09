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
    // T: O(n) S: O(len(nodes) + height)
    // not neccessary all of nodes in the tree
    public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode[] nodes) {
        var st = new HashSet<TreeNode>(nodes);
        TreeNode lca = null;
        Func<TreeNode, int> DFS = null;
        DFS = (node) => {
            if (node == null) return 0;
            int left = DFS(node.left);
            int right = DFS(node.right);
            int cnt = left + right;
            if (st.Contains(node)) cnt++;
            if (cnt == st.Count && lca == null) lca = node;
            return cnt;
        };
        DFS(root);
        return lca;
    }   
    // All the nodes will exist in the tree, and all values of the tree's nodes are unique.
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        var st = new HashSet<TreeNode>(nodes);
        Func<TreeNode, TreeNode> DFS = null;
        DFS = (node) => {
            if (node == null) return null;
            if (st.Contains(node)) return node;
            var left = DFS(node.left);
            var right = DFS(node.right);
            if (left != null && right != null) return node;
            else return left != null ? left : right;
        };
        return DFS(root);
    }
}
