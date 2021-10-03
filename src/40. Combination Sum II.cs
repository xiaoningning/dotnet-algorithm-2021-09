public class Solution {
    // DFS T: O(n^2)
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        int n = candidates.Length;
        Array.Sort(candidates); // it has duplicates
        var ans = new List<IList<int>>();
        Action<int, List<int>> DFS = null;
        DFS = (start, tmp) => {
            if (tmp.Sum() == target) { ans.Add(new List<int>(tmp)); return; }
            for (int i = start; i < n; i++) {
                // it must be i > start, NOT i > 0 !!!
                // i > start => no duplicate at each level of DFS
                // i > 0 => no duplicate value in the tmp
                if (i > start && candidates[i] == candidates[i - 1]) continue;
                if (tmp.Sum() + candidates[i] > target) break; // prunning
                tmp.Add(candidates[i]);
                DFS(i + 1, tmp);
                tmp.RemoveAt(tmp.Count - 1); // remove != removeAt
            }
        };
        DFS(0,new List<int>());
        return ans;
    }
}
