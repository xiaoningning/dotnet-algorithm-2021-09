public class Solution {
    // double median = (MAX(L1, L2) + MIN(R1, R2)) / 2.0
    // Binary search
    // T: O(log(min(n1,n2))) S: O(1)
    public double FindMedianSortedArrays1(int[] nums1, int[] nums2) {
        int n1 = nums1.Length, n2 = nums2.Length;
        if (n1 > n2) return FindMedianSortedArrays(nums2, nums1);
        // k := the right side # of merged array
        int k = (n1 + n2 + 1) / 2;
        int l = 0, r = n1, m1 = 0, m2 = 0;
        while (l < r) {
            m1 = l + (r - l) / 2;
            m2 = k - m1;
            // n1 < n2 => m2 - 1
            if (nums1[m1] < nums2[m2 - 1]) l = m1 + 1;
            else r = m1;
        }
        m1 = l;
        m2 = k - m1;
        int c1 = Math.Max(m1 > 0 ? nums1[m1 - 1] : Int32.MinValue,
                        m2 > 0 ? nums2[m2 - 1] : Int32.MinValue);
        if ((n1 + n2) % 2 == 1) return c1;
        int c2 = Math.Min(m1 < n1 ? nums1[m1] : Int32.MaxValue,
                        m2 < n2 ? nums2[m2] : Int32.MaxValue);
        return (c1 + c2) / 2.0;
    }
    // find kth smallest n in both nums1 and nums2 merged array
    // T: O(log(n1 + n2))
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int n1 = nums1.Length, n2 = nums2.Length;
        Func<int, int, int, int> findK = null;
        findK = (s1, s2, k) => {
            if (s1 == n1) return nums2[s2+k-1];
            if (s2 == n2) return nums1[s1+k-1];
            // base case for binary search
            if (k == 1) return Math.Min(nums1[s1], nums2[s2]);
            // k > 1 => s1+k/2-1 >= 0
            // s1+k/2-1 >= n1 => m1 in nums2
            int m1 = s1 + k/2 - 1 < n1 ? nums1[s1 + k/2 - 1] : Int32.MaxValue;
            int m2 = s2 + k/2 -1 < n2 ? nums2[s2 + k/2 - 1] : Int32.MaxValue;
            if (m1 < m2) return findK(s1 + k/2, s2, k - k/2);
            else return findK(s1, s2 + k/2, k - k/2);
        };
        int left = (n1 + n2 + 1) / 2, right = (n1 + n2 + 2) / 2;
        return (findK(0,0,left) + findK(0,0,right)) / 2.0;
    }
}
