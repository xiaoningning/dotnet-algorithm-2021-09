public class Solution {
    int[] sum;
    public Solution(int[] w) {
        sum = (int[])w.Clone(); // a shadow copy
        for (int i = 1 ; i < sum.Length; i++) sum[i] += sum[i-1];
    }
    // The probability of picking an index i is w[i] / sum(w)
    // 权重数组为 [1, 3, 2], 那么累加和数组为 [1, 4, 6]，整个的权重和为6，我们 rand() % 6，可以随机出范围 [0, 5] 内的数，
    // 随机到 0 则为第一个点，随机到 1，2，3 则为第二个点，随机到 4，5 则为第三个点
    public int PickIndex() {
        var rnd = new Random();
        int x = rnd.Next() % sum.Last(), l = 0, r = sum.Length - 1;
        while (l < r) {
            int m = l + (r -l) / 2;
            if (sum[m] <= x) l = m + 1;
            else r = m;
        }
        return r;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */
