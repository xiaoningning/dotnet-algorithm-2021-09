public class Solution {
    // 255.0.0.7 -> 11111111 00000000 00000000 00000111 (IP form -> Integer form)
    public IList<string> IpToCIDR2(string ip, int n) {
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
    public IList<string> IpToCIDR(string startIp, int n)
    {
        long s = ipToLong(startIp);
        long e = s + n - 1;
        if (s > e) throw new Exception("invalid iput");
        var ans = new List<string>();
        while (s <= e)
        {
            // identify the location of first 1's from lower bit to higher bit of start IP
            // e.g. 00000001.00000001.00000001.01101100, return 4 (100) <= x^2 !!!
            long locOfFirstOne = s & (-s);
            int maxMask = 32 - (int)Math.Log2(locOfFirstOne);

            // calculate how many IP addresses between the start and end
            // e.g. between 1.1.1.111 and 1.1.1.120, there are 10 IP address
            // 3 bits to represent 8 IPs, from 1.1.1.112 to 1.1.1.119 (119 - 112 + 1 = 8)
            double curRange = Math.Log2(e - s + 1);
            int maxDiff = 32 - (int)Math.Floor(curRange);

            // why max?
            // if the maxDiff is larger than maxMask
            // which means the numbers of IPs from start to end is smaller than mask range
            // so we can't use as many as bits we want to mask the start IP to avoid exceed the end IP
            // Otherwise, if maxDiff is smaller than maxMask, which means number of IPs is larger than mask range
            // in this case we can use maxMask to mask as many as IPs from start we want.
            maxMask = Math.Max(maxDiff, maxMask);

            // Add to results
            string ip = longToIp(s);
            ans.Add(ip + "/" + maxMask);
            // We have already included 2^(32 - maxMask) numbers of IP into result
            // So the next round start must add that number
            s += (long)Math.Pow(2, (32 - maxMask));
        }
        return ans;
    }
}
