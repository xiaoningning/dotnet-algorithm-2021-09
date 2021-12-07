public class Solution {
    public string NumberToWords(int num) {
        if (num == 0) return "Zero";
        return Convert(num).Substring(1); // recursion with " " prefix;
    }
    string[] kUnder20 = new string[]{"One", "Two", "Three", "Four", "Five", 
                           "Six", "Seven", "Eight", "Nine","Ten",
                           "Eleven", "Twelve", "Thirteen", "Fourteen",
                           "Fifteen", "Sixteen", "Seventeen", "Eighteen", 
                           "Nineteen"};
    string[] kUnder100 = new string[]{"Twenty", "Thirty", "Forty", "Fifty", 
                                "Sixty", "Seventy", "Eighty", "Ninety"};
    string[] kHTMB = new string[]{"Hundred", "Thousand", "Million", "Billion"};
    int[] kP = new int[]{100, 1000, 1000*1000, 1000*1000*1000};
    // recursion
    string Convert(int n) {
        if (n == 0) return "";
        if (n < 20) return " " + kUnder20[n - 1]; // 1 - 19
        if (n < 100) return " " + kUnder100[n / 10 - 2] + Convert(n % 10); // 20 ~ 99
        for (int i = 3; i >= 0; --i)
            if (n >= kP[i]) return Convert(n / kP[i]) + " " + kHTMB[i] + Convert(n % kP[i]);
        return "";
    }
}
