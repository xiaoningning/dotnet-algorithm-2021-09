public class Solution {
    // Binary search T: O(nlogn) key := how to count 
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        int n = arr.Length;
        double l = (double) arr[0] / arr[n - 1], r = 1;
        while (l < r) {
            double m = l + (r - l) / 2;
            int cnt = 0, x = 0, y = 1; // x/y => smallest
            for (int i = 0, j = i + 1; i < n; i++) {
                // find arr[i]/arr[j] > m to avoid missing smaller one for cnt!!!
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
    // priority queue := c# does not have PQ , runtime error
    public int[] KthSmallestPrimeFraction2(int[] arr, int k) {
        int n = arr.Length;
        // priority queue
        // primary number => key is unique
        var pq = new List<(double,int,int)>();
        for (int i = 0; i < n; i++) pq.Add((1.0 * arr[i]/arr[n-1], i, n - 1));
        while (--k >= 1) {
            pq.Sort((x,y) => x.Item1 - y.Item1 > 0 ? 1 : -1);
            var t = pq.First();
            pq.Remove(t);
            int j = t.Item3, i = t.Item2;
            j--; // add next bigger arr[i]/arr[j]
            pq.Add((1.0 * arr[i]/arr[j],i,j));
        }
        pq.Sort((x,y) => x.Item1 - y.Item1 > 0 ? 1 : -1);
        var ans = pq.First();
        return new int[]{arr[ans.Item2], arr[ans.Item3]};
    }
}
