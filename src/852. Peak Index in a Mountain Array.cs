public class Solution {
    // binary search
    public int PeakIndexInMountainArray(int[] arr) {
        int l = 0, r = arr.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (arr[m] < arr[m+1]) l = m + 1;
            else r = m;
        }
        return l;
    }
    public int PeakIndexInMountainArray1(int[] arr) {
        int peak = 0;
        for (int i = 1; i < arr.Length; i++) {
            if (arr[peak] > arr[i]) return peak;
            peak = i;
        }
        return -1;
    }
}
