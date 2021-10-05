public class Solution {
    // DFS + memo
    public IList<int> DiffWaysToCompute(string expression) {
        Func<int, int, char, int> op = (x, y, c) => {
            if (c == '+') return x + y;
            if (c == '-') return x - y;
            if (c == '*') return x * y;
            return Int32.MaxValue;
        };
        int n = expression.Length;
        var memo = new Dictionary<string, List<int>>();
        Func<string,List<int>> DFS = null;
        DFS = (s) => {
            if (memo.ContainsKey(s)) return memo[s];
            var ans = new List<int>();
            for (int i = 0; i < s.Length; i++) {
                if (s[i] >= '0' && s[i] <= '9') continue;
                var left = DFS(s.Substring(0, i));
                var right = DFS(s.Substring(i+1));
                foreach (int l in left) foreach (int r in right) ans.Add(op(l, r, s[i]));
            }
            if (!ans.Any()) ans.Add(Int32.Parse(s));
            return memo[s] = ans;
        };
        return DFS(expression);
    }
}
