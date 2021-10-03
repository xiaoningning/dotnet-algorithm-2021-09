public class Solution {
    // permutation is ordered v.s. combination is not
    // T: O(n!)
    public IList<IList<int>> PermuteUnique2(int[] nums) {
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
    public IList<IList<int>> PermuteUnique(int[] nums) {
        int n = nums.Length;
        var ans = new List<IList<int>>();
        Array.Sort(nums);
        Action<int[], int,int> swap = (a, i,j) => {
            int t = a[i]; a[i] = a[j]; a[j] = t;
        };
        Action<int,int[]> DFS = null;
        DFS = (start,t) => {
            if (start >= n) { ans.Add(new List<int>(t)); return;}
            for (int i = start; i < n; i++) {
                if (i != start && t[i] == t[start]) continue; // avoid duplicates
                swap(t, start, i);
                // new int[] at each level of DFS to keep start as the same
                DFS(start + 1,(int[])t.Clone());
            }
        };
        DFS(0, nums);
        return ans;
    }
    // WRONG => c# hashset<list> not unique due to list is a reference type
    public IList<IList<int>> PermuteUniqueX(int[] nums) {
        int n = nums.Length;
        // use set to remove duplicates (x)
        var ans = new HashSet<IList<int>>();
        if (n == 0) { ans.Add(new List<int>()); return ans.ToList(); }
        int first = nums[0];
        int[] tmp = new int[n-1];
        Array.Copy(nums, 1, tmp, 0, n - 1);
        var prev = PermuteUnique(tmp);
        foreach (var l in prev) {
            // <= l.Count => insert at last
            for (int i = 0; i <= l.Count; i++) {
                if (l.Any() && i < l.Count && l[i] == first) continue;
                l.Insert(i,first);
                ans.Add(new List<int>(l));
                l.RemoveAt(i);
            }
        }
        return ans.ToList();
    }
}
