public class Solution {
    // 255.0.0.7 -> 11111111 00000000 00000000 00000111 (IP form -> Integer form)
    public IList<string> IpToCIDR(string ip, int n) {
        var start = ipToLong(ip);
        var ans = new List<string>();
        int cover = 0;
        while (cover < n) {
            long cntZero = countZero(start); 
            // each 0 => two IPs, 2^cntZeros
            while (Math.Pow(2, cntZero) + cover > n) cntZero = cntZero - 1;
            int mask = (int)(32 - cntZero);
            ans.Add($"{longToIp(start)}/{mask}");
            cover += (int)Math.Pow(2, cntZero);
            start += (long)Math.Pow(2, cntZero);
        }
        return ans;
    }
    long ipToLong(string ip) {
        long ans = 0;
        foreach (var p in ip.Split(".")) ans = ans * 256 + Int32.Parse(p);
        return ans;
    }
    int countZero(long n) {
        if (n == 0) return 32; // handling 0.0.0.0 case.
        int ans = 0;
        while (n > 0 && (n % 2 == 0)) {
            ans += 1;
            n = n / 2;
        }
        return ans;
    }
    string longToIp(long n) {
        return $"{(n >> 24) & 255}.{(n >> 16) & 255}.{(n >> 8) & 255}.{n & 255}";
    }
}
