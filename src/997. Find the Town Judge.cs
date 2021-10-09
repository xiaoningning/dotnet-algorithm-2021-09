public class Solution {
    // in / out degrees
    public int FindJudge(int n, int[][] trust) {
        int[] ins = new int[n+1], outs = new int[n+1];
        foreach (var t in trust) {
            ins[t[1]]++; outs[t[0]]++;
        }
        for (int i = 1; i <= n; i++)
            if (ins[i] == n - 1 && outs[i] == 0) return i;
        return -1;
    }
    public int FindJudge1(int n, int[][] trust) {
        int[] cnt = new int[n+1];
        foreach (var t in trust) cnt[t[1]]++;
        int j = -1;
        for (int i = 1; i <= n; i++) if (cnt[i] == n - 1) j = i;
        foreach (var t in trust) if (j == t[0]) return -1;
        return j;
    }
}
