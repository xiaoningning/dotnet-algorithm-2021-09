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
    enum State { None = 0, Cam, Monitored }
    // Top-down + node val as memo, otherwise TLE
    public int MinCameraCover(TreeNode root) {
        if (root == null) return 0;
        // state: 0 not monitored, 1 camera, 2 monitored
        Func<TreeNode, State, int> f = null;
        f = (node, s) => {
            if (node == null) return 0;
            if (s == State.Cam) return 1 + f(node.left, State.Monitored) + f(node.right, State.Monitored);
            if (s == State.Monitored) {
                int noCam = f(node.left, State.None) + f(node.right, State.None);
                int cam = 1 + f(node.left, State.Monitored) + f(node.right, State.Monitored);
                return Math.Min(noCam, cam);
            }
            else { // not monitored, only memo for this case
                if (node.val != 0) return node.val;
                int rootCam = 1 + f(node.left, State.Monitored) + f(node.right, State.Monitored);
                // if left/right == null, then left/right cam is invalid case
                int leftCam = node.left != null ? f(node.left, State.Cam) + f(node.right, State.None) : Int32.MaxValue / 2;
                int rightCam = node.right != null ? f(node.right, State.Cam) + f(node.left, State.None) : Int32.MaxValue / 2;
                return node.val = new int[]{rootCam, leftCam, rightCam}.Min();
            }
        };
        // not monitor case including root cam or not case
        return f(root, State.None);
    }
}
