/**
1 2 3 4 1
3 4 1 2 1 3
res: "1 2 3", "1 2 1", "3 4 1"
*/
public static List<int> longestCommonSubsequence(List<int> a, List<int> b)
{
    int m = a.Count, n = b.Count;
    var ans = new List<int>();
    var dirs = new int[,]{{0,1},{1,0}};
    Action<int,int,List<int>> lcs = null;
    lcs = (i,j,cur) => {
        if (i == m || j == n) {
            if (cur.Count >= ans.Count) ans = new List<int>(cur);
            return;
        }
        if (a[i] == b[j]) {
          cur.Add(a[i]);
          lcs(i+1,j+1,cur);
          cur.RemoveAt(cur.Count - 1);
        }
        else { 
            for (int d = 0; d < 2; d++) {
                int ni = i + dirs[d,0], nj = j + dirs[d,1];
                lcs(ni, nj, cur);
            }
        }
    };
    lcs(0,0,new List<int>());
    return ans;
}
