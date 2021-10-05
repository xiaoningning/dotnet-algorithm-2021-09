public class Solution {
    // DFS + pruning
    public bool CanPartitionKSubsets1(int[] nums, int k) {
        if (nums.Sum() % k != 0) return false;
        Array.Sort(nums);
        int t = nums.Sum() / k, n = nums.Length;
        int[] used = new int[n];
        Func<int, int, int, bool> DFS = null;
        DFS = (start, sum, cnt) => {
            if (cnt == 0) return used.Sum() == n; // all n should be used
            if (sum == t) return DFS(0, 0, cnt - 1);
            for (int i = start; i < n; i++) {
                // prunning + visited check
                if (used[i] == 1) continue;
                 // nums is sorted assume all positive
                if (sum + nums[i] > t) break;
                used[i] = 1;
                if (DFS(i + 1, sum + nums[i], cnt)) return true;
                used[i] = 0;
            }
            return false;
        };
        return DFS(0, 0, k);
    }
    // bucket parition
    public bool CanPartitionKSubsets(int[] nums, int k) {
        if (nums.Sum() % k != 0) return false;
        Array.Sort(nums);
        int t = nums.Sum() / k;
        int[] buckets = new int[k];
        Func<int,bool> DFS = null;
        DFS = (idx) => {
            if (idx == -1) { 
                foreach (int sum in buckets) if (sum != t) return false;
                return true;
            }
            int num = nums[idx];
            for (int j = 0; j < k; j++) {
                if (buckets[j] + num > t) continue;
                buckets[j] += num;
                if (DFS(idx - 1)) return true;
                buckets[j] -= num;
            }
            return false;
        };
        // sorted, from max to min otherwise TLE
        return DFS(nums.Length - 1);
    }
}
