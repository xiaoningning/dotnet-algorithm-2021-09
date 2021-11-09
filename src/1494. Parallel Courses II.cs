public class Solution {
    /**
    dp[m] := min semesters to reach state m.
    dp[m | c] = min{dp[m | c], dp[m] + 1}, if we can reach m | c from m.
    This allows us to get rid of enumerate n semesters.
    Time complexity: O(2^n*2^n) <– This will be much smaller in practice.
    and can be reduced to O(3^n).
    Space complexity: O(2^n)
    */
    // iterate the taken state
    public int MinNumberOfSemesters(int n, int[][] relations, int k) {
        var deps = new int[n];
        foreach (var r in relations) deps[r[1] - 1] |= 1 << (r[0] - 1);
        var prereq = new int[1 << n];
        var dp = new int[1 << n]; // min # of sememters of bit mask state of i
        Array.Fill(dp, n + 1);
        dp[0] = 0; // init state
        for (int s = 0; s < 1 << n; s++) {
            // if (dp[s] == n + 1) continue; // not reachable yet
            int ns = 0; // next bit mask of state to study with current s
            for (int i = 0; i < n; i++) 
                if ((s & 1 << i) == 0 && (s & deps[i]) == deps[i])
                    ns |= 1 << i;
            // pruning here
            if (CountSetBit(ns) <= k) dp[s | ns] = Math.Min(dp[s | ns], dp[s] + 1);
            else {
                // iterate all submask of mask i to see which ns can be taken
                // see: https://cp-algorithms.com/algebra/all-submasks.html
                for (int c = ns; c != 0; c = (c-1) & ns)
                    if (CountSetBit(c) <= k) 
                        dp[s | c] = Math.Min(dp[s | c], dp[s] + 1);
            }
        }
        return dp[(1 << n) - 1];
    }
    // T: O(3^n) iterate not taken state
    public int MinNumberOfSemesters2(int n, int[][] relations, int k) {
        var deps = new int[n];
        foreach (var r in relations) deps[r[1] - 1] |= 1 << (r[0] - 1);
        var prereq = new int[1 << n];
        // iterate all mask and generate prerequisites mask of each state i
        for (int s = 0; s < 1 << n; s++)
            for (int i = 0; i < n; ++i)
                if ((s & (1 << i)) > 0) prereq[s] |= deps[i];

        var dp = new int[1 << n]; // min # of sememters of bit mask state of i
        Array.Fill(dp, n + 1);
        dp[0] = 0; // init state
        for (int s = 0; s < 1 << n; s++) {
            // iterate all submask of mask i to see which ns can be taken
            // see: https://cp-algorithms.com/algebra/all-submasks.html
            // check the prev prereq state and see if we can take s
            for (int c = s; c != 0; c = (c - 1) & s) {
                if (CountSetBit(c) > k) continue;
                int taken = s ^ ((1 << n) - 1);
                if ((taken & prereq[c]) == prereq[c])
                    dp[s] = Math.Min(dp[s], dp[s ^ c] + 1);
            }
        }
        return dp[(1 << n) - 1];
    }
    // https://kalkicode.com/count-set-bits-in-an-integer-in-csharp
    int CountSetBit(int mask) {
        return mask == 0 ? 0 : 1 + CountSetBit(mask & (mask - 1));
    }
}
