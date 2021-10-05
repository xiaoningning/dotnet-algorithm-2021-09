public class Solution {
    // DFS without Trie => TLE
    public IList<string> FindWords2(char[][] board, string[] words) {
        int m = board.Length, n = board[0].Length;
        int[,] dirs = new int[4,2]{{1,0},{-1,0},{0,1},{0, -1}};
        Func<int,int,int,string,bool> DFS = null;
        DFS = (i, j, x, s) => {
            if (x == s.Length) return true;
            if (i < 0 || i >= m || j < 0 || j >= n || s[x] != board[i][j]) return false;
            char cur = board[i][j];
            bool ans = false;
            board[i][j] = '#';
            for (int d = 0; d < 4; d++) ans |= DFS(i + dirs[d, 0], j + dirs[d, 1], x + 1, s);
            board[i][j] = cur;
            return ans;
        };
        var ans = new List<string>();
        var dict = new HashSet<string>(words);
        foreach (string w in dict) {
            bool found = false;
            for (int i = 0; i < m && !found; i++) 
                for (int j = 0; j < n && !found; j++)
                    if (DFS(i, j, 0, w)) { 
                        ans.Add(w);
                        found = true;
                    }
        }
        return ans;
    }
    // Trie + DFS => multiple source to destination
    // T: O(sum(words) + m*n*4^l) l:maxLen(words) S: O(sum(words) + words)
    public IList<string> FindWords(char[][] board, string[] words) {
        int m = board.Length, n = board[0].Length;
        int[,] dirs = new int[4,2]{{1,0},{-1,0},{0,1},{0, -1}};
        var root = new TrieNode();
        Action<string> buildTrie = (s) => {
            if (string.IsNullOrEmpty(s)) return;
            var ptr = root;
            foreach (char c in s) {
                int idx = c - 'a';
                if (ptr.children[idx] == null) ptr.children[idx] = new TrieNode();
                ptr = ptr.children[idx];
            }
            ptr.word = s;
        };
        foreach (string w in words) buildTrie(w);
        var ans = new List<string>();
        Action<TrieNode, int, int> DFS = null;
        DFS = (ptr, i, j) => {
            if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] == '#') return;
            char cur = board[i][j];
            var nptr = ptr.children[cur - 'a'];
            if (nptr == null) return;
            // continue search for overlapping words
            if (nptr.word != null) { ans.Add(nptr.word); nptr.word = null; }
            board[i][j] = '#';
            for (int d = 0; d < 4; d++) DFS(nptr, i + dirs[d, 0], j + dirs[d, 1]);
            board[i][j] = cur;
        };
        for (int i = 0; i < m; i++) 
            for (int j = 0; j < n; j++) DFS(root, i, j);
        return ans;
    }
}
public class TrieNode {
    public string word;
    public TrieNode[] children;
    public TrieNode() { 
        children = new TrieNode[26];
        word = null;
    }
}
