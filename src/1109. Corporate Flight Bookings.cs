public class Solution {
    // T: O(|bookings|) S: O(n)
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        var ans = new int[n];
        foreach (var b in bookings) {
            ans[b[0] - 1] += b[2];
            // end + 1 -= seats => O(n) ans[i] += ans[i-1] 
            if (b[1] < n) ans[b[1]] -= b[2]; 
        }
        for (int i = 1; i < n; i++) ans[i] += ans[i-1];
        return ans;
    }
}
