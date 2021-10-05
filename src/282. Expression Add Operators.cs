public class Solution {
    public IList<string> AddOperators(string num, int target) {
        var ans = new List<string>();
        int n = num.Length;
        Action<int,int,int,string> DFS = null;
        DFS = (i, sum, prev, cur) => {
            if (i == n) {
                if (sum == target) ans.Add(cur);
                return; 
            }
            for (int len = 1; i + len <= n; len++) {
                string t = num.Substring(i, len);
                // handle leading 0 case
                if (t.Length > 1 && t[0] == '0') return;
                long tVal = Int64.Parse(t); 
                // overflow int32 for val or PREV !!!
                if (tVal > Int32.MaxValue || prev * tVal > Int32.MaxValue) break;
                int val = (int) tVal;
                if (cur.Length != 0) {
                    DFS(i + len, sum + val, val, cur + "+" + t);
                    DFS(i + len, sum - val, -val, cur + "-" + t);
                    DFS(i + len, sum - prev + prev * val, prev * val, cur + "*" + t);
                }
                else DFS(i + len, val, val, cur + t);
            }
        };
        DFS(0,0,0,"");
        return ans;
    }
}
