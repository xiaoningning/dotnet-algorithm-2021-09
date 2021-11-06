public class Solution {
    // sorting
    public string FrequencySort1(string s) {
        var freq = new Dictionary<char,int>();
        foreach (var c in s) {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
        }
        var lst = freq.ToList();
        lst.Sort((x,y) => x.Value == y.Value ? x.Key - y.Key : y.Value - x.Value);
        var ans = "";
        foreach (var kv in lst) { 
            int cnt = kv.Value;
            while (--cnt >= 0) ans += kv.Key; 
        }
        return ans;
    }
    // no sorting
    public string FrequencySort(string s) {
        int mxFreq = 0;
        var freq = new Dictionary<char,int>();
        foreach (var c in s) {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
            if (freq[c] > mxFreq) mxFreq = freq[c];
        }
        var strs = new string[mxFreq + 1];
        Array.Fill(strs, "");
        foreach (var kv in freq) {
            strs[kv.Value] += kv.Key;
        }
        var ans = "";
        for (int i = mxFreq; i > 0; i--) if (strs[i] != "")  {
            var t = new string(strs[i].OrderBy(c => c).ToArray());
            foreach (var c in t) { 
                int cnt = i;
                while (--cnt >= 0) ans += c;
            }
        }
        return ans;
    }
}
