public class FileSystem {
    FileNode root;
    public FileSystem() {
        root = new FileNode();
    }
    
    public IList<string> Ls(string path) {
        var ans = new List<string>();
        var node = root;
        var dirs = path.Split("/");
        foreach (var d in dirs) {
            if (d == "") continue;
            if (!node.children.ContainsKey(d)) return ans;
            node = node.children[d];
        }
        if (node.isFile) ans.Add(dirs.Last());
        else ans = node.children.Keys.ToList();
        ans.Sort();
        return ans;
    }
    
    public void Mkdir(string path) {
        var node = root;
        var dirs = path.Split("/");
        foreach (var d in dirs) {
            if (d == "") continue;
            if (!node.children.ContainsKey(d)) node.children.Add(d, new FileNode());
            node = node.children[d];
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        var node = root;
        var dirs = filePath.Split("/");
        foreach (var d in dirs) {
            if (d == "") continue;
            if (!node.children.ContainsKey(d)) node.children.Add(d, new FileNode());
            node = node.children[d];
        }
        node.isFile = true;
        node.content += content; // add content :=> +=
    }
    
    public string ReadContentFromFile(string filePath) {
        var node = root;
        var dirs = filePath.Split("/");
        foreach (var d in dirs) {
            if (d == "") continue;
            if (!node.children.ContainsKey(d)) node.children.Add(d, new FileNode());
            node = node.children[d];
        }
        return node.content;
    }
}
// Tries structure for file system
public class FileNode {
    public bool isFile = false;
    public string content = "";
    public Dictionary<string, FileNode> children = new Dictionary<string, FileNode>();
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */
