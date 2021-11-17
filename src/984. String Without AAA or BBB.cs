public class Solution {
    // similar to LC. 1405
    public string StrWithout3a3b(int a, int b, char astr = 'a', char bstr = 'b') {
        if (a < b) return StrWithout3a3b(b, a, bstr, astr);
        if (b == 0) return string.Concat(Enumerable.Repeat(astr, a));
        int acnt= Math.Min(2, a), bcnt = a - acnt >= b ? 1 : 0; // use bstr to seperate astr
        return string.Concat(Enumerable.Repeat(astr, acnt)) +
                string.Concat(Enumerable.Repeat(bstr, bcnt)) +
                StrWithout3a3b(a - acnt, b - bcnt, astr, bstr);
    }
}
