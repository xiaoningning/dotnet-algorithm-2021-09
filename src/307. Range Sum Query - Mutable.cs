// init: O(nlogn)
// query: O(logn)
// update: O(logn)
public class NumArray {
    int[] _nums;
    FenwickTree _tree;
    public NumArray(int[] nums) {
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
/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
