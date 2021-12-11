/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */

class Solution {
    // BFS!!! DFS does not work for this case
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        var st = new HashSet<string>();
        var hostName = startUrl.Split("/")[2];
        var q = new Queue<string>();
        st.Add(startUrl);
        q.Enqueue(startUrl);
        while (q.Any()) {
            var nx = q.Dequeue();
            foreach (var uri in htmlParser.GetUrls(nx)) {
                if (!st.Contains(uri) && uri.IndexOf(hostName) >= 0) {
                    q.Enqueue(uri);
                    st.Add(uri);
                }
            }
        }
        return st.ToList();
    }
}
