public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var cnt = new int[26];
        foreach (var t in tasks) cnt[t - 'A']++;
        int mx = cnt.Max(), mxCnt = 0;
        foreach (var c in cnt) if (c == mx) mxCnt++;
        return Math.Max(tasks.Length, (mx - 1) * (n + 1) + mxCnt);
    }
}
