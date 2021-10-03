public class Solution {
    // permutation is ordered v.s. combination is not
    public IList<IList<int>> PermuteUnique(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums); // it has duplicates
        var ans = new List<IList<int>>();
        var used = new int[n];
        Action<List<int>> DFS = null;
        DFS = (tmp) => {
            if (tmp.Count == n) { ans.Add(new List<int>(tmp)); return; }
            for (int i = 0; i < n; i++) {
                if (used[i] == 1) continue;
                // permutation no duplicates at each LEVEL of DFS
                // the same number can be used only once at each LEVEL of DFS
                // used[i-1] := 0 means  it was used in the previous level and reset as 0 in recursion
                if (i > 0 && used[i - 1] == 0 && nums[i] == nums[i - 1]) continue;
                tmp.Add(nums[i]);
                used[i] = 1;
                DFS(tmp);
                used[i] = 0;
                tmp.RemoveAt(tmp.Count - 1);
            }
        };
        DFS(new List<int>());
        return ans;
    }
}
