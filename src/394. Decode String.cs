public class Solution {
    // Recursion
    int i = 0;
    int n = 0;
    string str = "";
    public string DecodeString(string s) {
        n = s.Length;
        str = s;
        return decode();
    }
    string decode() {
        string ans = "";
        while (i < n && str[i] != ']') { // ']' stop at this level for recursion
            if (str[i] >= 'a' && str[i] <= 'z') ans += str[i++];// handler 0 num case
            else {
                int num = 0;
                while (str[i] >= '0' && str[i] <= '9') num = num * 10 + str[i++] - '0';
                i++; // skip '['
                var ns = decode(); 
                i++; // skip ']'
                while (--num >= 0) ans += ns;
            }
        }
        return ans;
    }
}
