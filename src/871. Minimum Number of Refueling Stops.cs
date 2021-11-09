public class Solution {
    // DP
    public int MinRefuelStops1(int target, int startFuel, int[][] stations) {
        int n = stations.Length;
        var dp = new long[n + 1]; // use long avoid overflow
        Array.Fill(dp, startFuel); // init startFuel at each station
        for (int i = 0; i < n; i++) {
            // j-- avoid to overwrite prev j
            for (int j = i; j >= 0 && dp[j] >= stations[i][0]; j--)
                dp[j + 1] = Math.Max(dp[j + 1], dp[j] + stations[i][1]);
        }
        for (int i = 0; i <= n; i++) if (dp[i] >= target) return i; // first station to target
        return -1;
    }
    // priority queue
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        int n = stations.Length, ans = 0, start = 0;
        var pq = new List<int>(); // as priority queue
        for(; startFuel < target; ans++) {
            while (start < n && startFuel >= stations[start][0]) pq.Add(stations[start++][1]);
            if (!pq.Any()) return -1;
            pq.Sort(); // take most fuel first and see if reach target
            startFuel += pq.Last(); pq.RemoveAt(pq.Count - 1);
        }
        return ans;
    }
}
