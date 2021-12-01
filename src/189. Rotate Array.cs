public class Solution {
    // T: O(n) S: O(n)
    public void Rotate1(int[] nums, int k) {
        int n = nums.Length;
        var t = new int[n];
        Array.Copy(nums, 0, t, 0, n);
        for (int i = 0; i < n; i++) nums[(i + k) % n] = t[i];
    }
    /**
    1. reverse the whole array O(n) [7,6,5,4,3,2,1]
    2. reverse the left part 0 ~ k – 1 O(k) [5,6,7,4,3,2,1]
    3. reverse the right part k ~ n – 1 O(n-k) [5,6,7,1,2,3,4]
*/
    // S: O(1)
    public void Rotate2(int[] nums, int k) {
        int n = nums.Length;
        if (n == 0) return;
        k %= n;
        if ( k == 0) return;
        Array.Reverse(nums);
        Array.Reverse(nums, 0, k);
        Array.Reverse(nums, k, n - k);
    }
    /**
    1 2 3 4 5 6 7 
    1 2 3 1 5 6 7
    1 2 3 1 5 6 4
    1 2 7 1 5 6 4
    1 2 7 1 5 3 4
    1 6 7 1 5 3 4
    1 6 7 1 2 3 4
    5 6 7 1 2 3 4
    */
    public void Rotate3(int[] nums, int k) {
        int n = nums.Length;
        if (n == 0) return;
        k %= n;
        if ( k == 0) return;
        int start = 0, idx = 0, pre = 0, cur = nums[0];
        for (int i = 0; i < n; i++) {
            pre = cur;
            idx = (idx + k) % n;
            cur = nums[idx];
            nums[idx] = pre;
            if (start == idx) {
                idx = ++start;
                cur = nums[idx];
            }
        }
    }
    /**
    1 2 3 4 5 6 7 
    5 2 3 4 1 6 7 
    5 6 3 4 1 2 7
    5 6 7 4 1 2 3
    5 6 7 1 4 2 3
    5 6 7 1 2 4 3
    5 6 7 1 2 3 4
    */
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        if (n == 0) return;
        int start = 0; 
        // k could > n => out of index
        while (n > 0 && ((k %= n) != 0)) {
            for (int i = 0; i < k; i++) {
                var t = nums[i + start];
                nums[i + start] = nums[i + start + n - k];
                nums[i + start + n - k] = t;
            }
            n -= k;
            start += k;
        }
    }
}
