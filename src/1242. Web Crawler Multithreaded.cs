/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */
class Solution {
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        var hostname = startUrl.Split("/")[2];
        var cur = new List<string>() { startUrl };
        var visited = new HashSet<string>() { startUrl };
        while (cur.Any()) {
            var nx = new List<string>();
            System.Threading.Tasks.Parallel.ForEach(cur, 
                x => {
                var urls = htmlParser.GetUrls(x).Where(u => u.Contains(hostname)).ToList(); 
                lock(nx) {
                    foreach (string url in urls) {
                        if (!visited.Contains(url)) {
                            visited.Add(url);
                            nx.Add(url);
                        }
                    }
                }
            });
            cur = nx;
        }
        return visited.ToList();
    }
}
