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
    // greedy recursion search based on state
    // top down without memo
    public int MinCameraCover(TreeNode root) {
        int ans = 0;
        Func<TreeNode, State> f = null;
        f = (node) => {
            if (node == null) return State.Monitored;
            var left = f(node.left);
            var right = f(node.right);
            // if one of none, then node needs cam
            if (left == State.None || right == State.None) {
                ans++;
                return State.Cam;
            }
            // both left and right either cam or monitored, can not be none
            if (left == State.Cam || right == State.Cam) return State.Monitored;
            return State.None;
        };
        return f(root) == State.None ? ++ans : ans;
    }
    // Top-down to track min # of cam + node val as memo, otherwise TLE
    public int MinCameraCover1(TreeNode root) {
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
