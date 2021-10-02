public class Solution {
    // Binary search T: O(nlogn) key := how to count 
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        int n = arr.Length;
        double l = (double) arr[0] / arr[n - 1], r = 1;
        while (l < r) {
            double m = l + (r - l) / 2;
            int cnt = 0, x = 0, y = 1; // x/y => smallest
            for (int i = 0, j = i + 1; i < n; i++) {
                // find arr[i]/arr[j] to avoid missing smaller one for cnt!!!
                while (j < n && arr[i] > arr[j] * m) j++;
                cnt += n - j; // calculate for each i
                // find biggest arr[i]/arr[j]
                if (j < n && x * arr[j] < arr[i] * y) {
                    x = arr[i]; y = arr[j];
                }
            }
            if (cnt == k) return new int[]{x, y};
            else if (cnt < k) l = m; // m is double
            else r = m;
        }
        return new int[]{};
    }
}
