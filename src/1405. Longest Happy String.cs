public class Solution {
    // similar to LC. 984
    public string LongestDiverseString(int a, int b, int c) {
        Func<int,int,int,string,string,string,string> generate = null;
        generate = (a, b, c, astr, bstr, cstr) => {
            // need to start with a >= b >= c, if not rotate a/b/c
            if (a < b) return generate(b, a, c, bstr, astr, cstr);
            if (b < c) return generate(a, c, b, astr, cstr, bstr);
            if (b == 0) return string.Concat(Enumerable.Repeat(astr, Math.Min(2, a)));
            int acnt= Math.Min(2, a), bcnt = a - acnt >= b ? 1 : 0; // use bstr to seperate astr
            return string.Concat(Enumerable.Repeat(astr, acnt)) +
                    string.Concat(Enumerable.Repeat(bstr, bcnt)) +
                    generate(a - acnt, b - bcnt, c, astr, bstr, cstr);
            };
        return generate(a, b, c, "a", "b", "c");
        }
    }

