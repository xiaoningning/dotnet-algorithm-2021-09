public class WordDictionary {
    TrieNode root;
    public WordDictionary() { root = new TrieNode();}
    
    public void AddWord(string word) {
        var ptr = root;
        foreach (var c in word) {
            int idx = c - 'a';
            if (ptr.children[idx] == null) ptr.children[idx] = new TrieNode();
            ptr = ptr.children[idx];
        }
        ptr.isWord = true;
    }
    
    public bool Search(string word) {
        return Search(root, word, 0);
    }
    bool Search(TrieNode node, string word, int i) {
        if (node == null) return false;
        if (i == word.Length) return node != null && node.isWord == true;
        if (word[i] == '.') {
            foreach (var nx in node.children) if (Search(nx, word, i + 1)) return true;
            return false;
        }
        else {
            var nx = node.children[word[i] - 'a'];
            return Search(nx, word, i + 1);
        }
    }
}
public class TrieNode {
    public bool isWord = false;
    public TrieNode[] children = new TrieNode[26];
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
