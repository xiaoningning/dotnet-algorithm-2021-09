public class Solution {
    public int UniqueLetterString(string s) {
        int res = 0, n = s.Length, kM = (int)Math.Pow(10,9) + 7;
        int[] first = new int[26], second = new int[26];
        Array.Fill(first, -1); Array.Fill(second, -1);
        for (int i = 0; i < n; i++) {
            int c = s[i] - 'A';
            res = (res + (i - second[c]) * (second[c] - first[c]) % kM) % kM;
        	first[c] = second[c];
        	second[c] = i; 
        }
        for (int c = 0; c < 26; ++c)
        	res = (res + (n - second[c]) * (second[c] - first[c]) % kM) % kM;
        return res;
    }
}
