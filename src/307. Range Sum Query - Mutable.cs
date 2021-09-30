// init: O(nlogn)
// query: O(logn)
// update: O(logn)
public class NumArray1 {
    int[] _nums;
    FenwickTree _tree;
    public NumArray1(int[] nums) {
        int n = nums.Length;
        _nums = new int[n];
        _tree = new FenwickTree(n);
        for (int i = 0; i < n; i++) Update(i, nums[i]);
    }
    
    public void Update(int index, int val) {
        _tree.Update(index + 1, val - _nums[index]);
        _nums[index] = val;
    }
    
    public int SumRange(int left, int right) {
        // _tree is 1-based index
        return _tree.GetSum(right + 1) - _tree.GetSum(left);
    }
}
// Fenwick Tree := Binary Indexed Tree
public class FenwickTree {
    int[] _sums;
    public FenwickTree(int n) { 
        _sums = new int[n + 1];
    }
    public void Update(int i, int delta) {
        while (i < _sums.Length) {
            _sums[i] += delta;
            i += lowBit(i);
        }
    }
    public int GetSum(int i) {
        int sum = 0;
        while (i > 0) {
            sum += _sums[i];
            i -= lowBit(i);
        }
        return sum;
    }
    Func<int,int> lowBit = (x) => { return x & (-x); };
}
// Segment Tree := Binary tree with sum, start idx, end idx
public class NumArray {
    SegmentTreeNode _root;
    public NumArray(int[] nums) {
        _root = BuildTree(0, nums.Length - 1, nums);
    }
    // O(logn)
    public void Update(int index, int val) {
        UpdateTree(_root, index, val);
    }
    
    // ~O(logn) => worst O(n^2) Binary Indexed Tree is strictly O(logn)
    public int SumRange(int left, int right) {
        return GetSumRange(_root, left, right);
    }
    
    int GetSumRange(SegmentTreeNode node, int l, int r) {
        if (node.start == l && node.end == r) { return node.sum; }
        int m = node.start + (node.end - node.start) / 2;
        if (r <= m) return GetSumRange(node.left, l, r);
        else if (l > m) return GetSumRange(node.right, l, r);
        else return GetSumRange(node.left, l, m) + GetSumRange(node.right, m+1, r);
    }
    
    void UpdateTree(SegmentTreeNode node, int i, int v) {
        if (node.start == i && node.end == i) { node.sum = v; return; }
        int m = node.start + (node.end - node.start) / 2;
        if (i <= m) UpdateTree(node.left, i, v);
        if (i > m) UpdateTree(node.right, i, v);
        node.sum = node.left.sum + node.right.sum;
    }
    
    SegmentTreeNode BuildTree(int l, int r, int[] nums) {
        if (l == r) return new SegmentTreeNode(l, r, nums[l]);
        int m = l + (r - l) / 2;
        var left = BuildTree(l, m, nums);
        var right = BuildTree(m + 1, r, nums);
        return new SegmentTreeNode(l, r, left.sum + right.sum, left, right);
    }
}
public class SegmentTreeNode {
    public int start, end, sum;
    public SegmentTreeNode left, right;
    public SegmentTreeNode(int s, 
                           int e, 
                           int val, 
                           SegmentTreeNode l = null, 
                           SegmentTreeNode r = null) {
        start = s; end = e; sum = val;
        left = l; right = r;
    }
}
/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
