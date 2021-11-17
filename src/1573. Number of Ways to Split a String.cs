public class Solution {
    public int NumWays(string s) {
        int kM = (int)Math.Pow(10, 9) + 7;
        long n = s.Length; // overflow int32
        int t = 0;
        foreach (var c in s) if (c == '1') t++;
        if (t % 3 != 0) return 0;
        // all zeros case:  C(n-2, 2) = (n – 1) * (n – 2) / 2
        if (t == 0) return (int)((1 + (n - 1 - 1)) * (n - 1 - 1) / 2 % kM);
        t /= 3;
        long l = 0, r = 0;
        for (int i = 0, cnt = 0; i < n; i++) {
            if (s[i] == '1') cnt++;
            if (cnt == t) l++;
            else if (cnt == t * 2) r++;
        }
        return (int)(l * r % kM);
    }
}
