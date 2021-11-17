public class Solution {
    public string Multiply(string num1, string num2) {
        int m = num1.Length, n = num2.Length;
        var vals = new int[m + n];
        var ans = "";
        for (int i = m - 1; i >= 0; i--) { // start from high bit 
            for (int j = n - 1; j >= 0; j--) {
                int t = (num1[i] - '0') * (num2[j] - '0');
                int p1 = i + j, p2 = i + j + 1;
                t += vals[p2];
                vals[p2] = t % 10;
                vals[p1] += t / 10;
            }
        }
        foreach (var v in vals) if (ans != "" || v != 0) ans += v;
        return ans == "" ? "0" : ans;
    }
}
