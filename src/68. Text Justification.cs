public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var ans = new List<string>();
        int i = 0;
        while (i < words.Length) {
            int j = i, len = 0;
            while (j < words.Length && len + words[j].Length + j - i <= maxWidth) len += words[j++].Length; // j - i is min of spaces for this line
            string str = "";
            int extraSpace = maxWidth - len;
            for (int k = i; k < j; ++k) {
                str += words[k];
                int tmp = 0;
                if (extraSpace > 0) {
                    if (j == words.Length) {
                        if (j - k == 1) tmp = extraSpace;
                        else tmp = 1;
                    }
                    else {
                        if (j - k > 1) {
                            if (extraSpace % (j - k - 1) == 0) tmp = extraSpace / (j - k - 1);
                            else tmp = extraSpace / (j - k - 1) + 1;
                        }
                        else tmp = extraSpace;
                        
                    }
                }
                for (int t = 0; t < tmp; t++) str += " ";
                extraSpace -= tmp;
            }
            i = j;
            ans.Add(str);
        }
        return ans;
    }
}
