public class Solution {
    public bool IsValid(string code) {
        var st = new Stack<string>();
        for (int i = 0; i < code.Length; i++) {
            if (i > 0 && !st.Any()) return false; // should have at least 1 tag
            if (i + 9 <= code.Length && code.Substring(i, 9) == "<![CDATA[") {
                int j = i + 9;
                i = code.IndexOf("]]>", j);
                if (i < 0) return false;
                i += 2;
            }
            else if (i + 2 <= code.Length && code.Substring(i,2) == "</") { // search "</" before "<"
                int j = i + 2;
                i = code.IndexOf(">", j);
                if (i < 0) return false;
                string tag = code.Substring(j, i - j);
                if (!st.Any() || st.Peek() != tag) return false;
                st.Pop(); // end of tag
            }
            else if (i + 1 <= code.Length && code.Substring(i,1) == "<") {
                int j = i + 1;
                i = code.IndexOf(">", j);
                // no > || empty <> || tag is [1,9]
                if (i < 0 || i == j || i - j > 9) return false;
                for (int k = j; k < i; k++) if (code[k] < 'A' || code[k] > 'Z') return false;
                string tag = code.Substring(j, i - j);
                st.Push(tag);
            }
        } 
        return !st.Any(); // valid case, no more tag in Stack
    }
}
