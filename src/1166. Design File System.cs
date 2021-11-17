// similar to LC. 588
public class FileSystem {
    FileNode root;
    public FileSystem() { root = new FileNode(); }
    
    public bool CreatePath(string path, int value) {
        var dirs = path.Split("/").ToList();
        var node = root;
        for (int i = 0; i < dirs.Count - 1; i++){
            if (dirs[i] == "") continue;
            if (!node.children.ContainsKey(dirs[i])) return false;
            node = node.children[dirs[i]];
        }
        if (node.children.ContainsKey(dirs.Last())) return false;
        node.children.Add(dirs.Last(), new FileNode());
        node = node.children[dirs.Last()];
        node.val = value;
        return true;
    }
    
    public int Get(string path) {
        var dirs = path.Split("/").ToList();
        var node = root;
        for (int i = 0; i < dirs.Count; i++){
            if (dirs[i] == "") continue;
            if (!node.children.ContainsKey(dirs[i])) return -1;
            node = node.children[dirs[i]];
        }
        return node.val;
    }
}
public class FileNode {
    public int val = -1;
    public Dictionary<string, FileNode> children = new Dictionary<string, FileNode>();
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * bool param_1 = obj.CreatePath(path,value);
 * int param_2 = obj.Get(path);
 */
