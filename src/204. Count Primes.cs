public class Solution {
    public int CountPrimes(int n) {
        var primes = new bool[n];
        Array.Fill(primes, true);
        int ans = 0;
        for (int i = 2; i < n; i++) {
            if (!primes[i]) continue;
            ans++;
            for (int j = 2; i * j < n; j++) primes[i * j] = false;
        }
        return ans;
    }
}
