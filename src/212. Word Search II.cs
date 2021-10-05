public class Solution {
    // Trie + DFS => multiple source to destination
    // T: O(sum(words) + 4^maxLength(words)) S: O(sum(words) + words)
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
        Action<TrieNode, int,int, int[,]> DFS = null;
        DFS = (ptr,i,j, visited) => {
            var nptr = ptr.children[board[i][j] - 'a'];
            if (nptr == null) return;
            // continue search for overlapping words
            if (nptr.word != null) { ans.Add(nptr.word); nptr.word = null; }
            for (int d = 0; d < 4; d++) {
                int ni = i + dirs[d, 0], nj = j + dirs[d, 1];
                if (ni < 0 || ni >= m || nj < 0 || nj >= n || visited[ni,nj] == 1) continue;
                visited[ni,nj] = 1;
                DFS(nptr, ni, nj, visited);
                visited[ni,nj] = 0;
            }
        };
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                var t = new int[m,n];
                t[i,j] = 1;
                DFS(root, i, j, t);
            }
        }
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
