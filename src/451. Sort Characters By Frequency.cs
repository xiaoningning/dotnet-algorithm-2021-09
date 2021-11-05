public class Solution {
    public string FrequencySort(string s) {
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
}
