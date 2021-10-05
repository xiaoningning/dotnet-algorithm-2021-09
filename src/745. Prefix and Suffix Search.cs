// Dictionary without Trie
public class WordFilter {
    Dictionary<string, int> d = new Dictionary<string,int>();
    public WordFilter(string[] words) {
        for (int k = 0; k < words.Length; k++) {
            string w = words[k];
            for (int l = 1; l <= w.Length; l++)
                for (int r = 1; r <= w.Length; r++)
                    d[w.Substring(0,l) + "#" + w.Substring(w.Length - r)] = k;
        }
    }
    
    public int F(string prefix, string suffix) {
        return d.ContainsKey(prefix + "#" + suffix) ? d[prefix + "#" + suffix] : -1; 
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */
