public class Solution {
    // float point => do the floating num first, then do the rest, then add them back
    public string AddStrings1(string num1, string num2) {
        int m = num1.Length, n = num2.Length, i = m - 1, j = n - 1, carry = 0;
        var ans = "";
        while (i >= 0 || j >= 0 || carry == 1) {
            int a = i >= 0 ? num1[i--] - '0' : 0;
            int b = j >= 0 ? num2[j--] - '0' : 0;
            int sum = a + b + carry;
            carry = sum / 10;
            ans = sum % 10 + ans; // reverse here
        }
        return ans;
    }
    // support the float number TESTed!!!
    public string AddStrings(string num1, string num2) {
        string[] n1 = num1.Split(".");
        string[] n2 = num2.Split(".");
        if (n1.Length == 2 && n2.Length == 2) {
            int l1 = n1[1].Length, l2 = n2[1].Length;
            int mxLen = Math.Max(l1, l2);
            string zeros = GetZeros(Math.Abs(n1[1].Length - n2[1].Length));
            string right = l1 < l2 ? AddNums(n1[1] + zeros, n2[1], 0) : AddNums(n1[1], n2[1] + zeros, 0);
            if (right.Length > mxLen) return AddNums(n1[0], n2[0], right[0] - '0') + "." + right.Substring(1);
            else return AddNums(n1[0], n2[0], 0) + "." + right;
        }
        else {
            string left = AddNums(n1[0], n2[0], 0);
            if (n1.Length == 2) return left + "." + n1[1];
            else if (n2.Length == 2) return left + "." + n2[1];
            else return left;
        }
    }
    string GetZeros(int cnt) {
        string ans = "";
        while(--cnt >= 0) ans += "0";
        return ans;
    }
    string AddNums(string num1, string num2, int carry) {
        int m = num1.Length, n = num2.Length, i = m - 1, j = n - 1;
        var ans = "";
        while (i >= 0 || j >= 0 || carry == 1) {
            int a = i >= 0 ? num1[i--] - '0' : 0;
            int b = j >= 0 ? num2[j--] - '0' : 0;
            int sum = a + b + carry;
            carry = sum / 10;
            ans = sum % 10 + ans; // reverse here
        }
        return ans;
    }
}
