public class Solution {
    // binary search
    public int HIndex(int[] citations) {
        int len = citations.Length, l = 0, r = len;
        while (l < r) {
            int m = l + (r -l)/2;
            if (citations[m] == len - m) return citations[m];
            else if (citations[m] > len - m) r = m;
            else l = m + 1;
        }
        return len - l;
    }
}
