public class Solution {
    public int NthUglyNumber(int n) {
        var ans = new List<int>(){1};
        int i2 = 0, i3 = 0, i5 = 0;
        while (ans.Count < n) {
            int n2 = ans[i2] * 2, n3 = ans[i3] * 3, n5 = ans[i5] * 5;
            int mn = new int[]{n2,n3,n5}.Min();
            if (mn == n2) i2++;
            if (mn == n3) i3++;
            if (mn == n5) i5++;
            ans.Add(mn); // nth number => pick mn one
        }
        return ans.Last();
    }
     public int NthUglyNumber2(int n) {
         var pq = new List<long>(){1};
         for (long i = 1; i < n; i++) {
             var t = pq[0]; pq.RemoveAt(0);
             while (pq.Any() && pq[0] == t) pq.RemoveAt(0);
             pq.Add(t * 2);
             pq.Add(t * 3);
             pq.Add(t * 5);
             pq.Sort(); // pick mn one of pq for nth number
         }
         return (int)pq[0];
     }
}
