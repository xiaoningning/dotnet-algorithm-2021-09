public class Solution {
    public int HIndex1(int[] citations) {
        Array.Sort(citations);
        Array.Reverse(citations);
        for (int i = 0; i < citations.Length; i++) if (i >= citations[i]) return i;
        return citations.Length;
    }
    public int HIndex(int[] citations) {
            int n = citations.Length;
            var m = new int[n+1];
            foreach(int c in citations){
                if(c >= n) m[n]++;
                else m[c]++;
            }
            int cnt = 0;
            for(int i = n; i >= 0; i--) {
                cnt += m[i];
                if(cnt >= i)return i;
            }
            return 0;
        }
}
