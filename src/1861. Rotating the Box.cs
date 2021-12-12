public class Solution {
    // empty point for stone update
    public char[][] RotateTheBox(char[][] box) {
        int m = box.Length, n = box[0].Length;
        var ans = new char[n][];
        for (int i = 0; i < n; i++)  { 
            ans[i] = new char[m];
            Array.Fill(ans[i], '.'); // must fill first since '#' can be '.' after rotate
        }
        for (int i = 0; i < m; i++) {
            for (int j = n - 1, empty = n - 1; j >= 0; j--) { // empty pointer
                if (box[i][j] == '.') continue; // 
                if (box[i][j] == '#') ans[empty--][m - 1 - i] = '#'; // prev '#' => '.'
                if (box[i][j] == '*') { ans[j][m - 1 - i] = '*'; empty = j - 1; } // update empty pointer
            }
        }
        return ans;
    }
}
