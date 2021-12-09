public class Codec {
    string dict = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    Dictionary<string,string> long2short = new Dictionary<string,string>();
    Dictionary<string,string> short2long = new Dictionary<string,string>();
    
    // Encodes a URL to a shortened URL
    // 6^62
    public string encode(string longUrl) {
        if (long2short.ContainsKey(longUrl)) return "http://tinyurl.com/" + long2short[longUrl];
        var rnd = new Random();
        int idx = 0;
        string randStr = "";
        for (int i = 0; i < 6; ++i) randStr += dict[rnd.Next() % dict.Length];
        var randStrArray = randStr.ToCharArray();
        while (short2long.ContainsKey(randStr)) {
            randStrArray[idx] = dict[rnd.Next() % dict.Length];
            idx = (idx + 1) % 5;
        }
        randStr = new string(randStrArray);
        short2long[randStr] = longUrl;
        long2short[longUrl] = randStr;
        return "http://tinyurl.com/" + randStr;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        string randStr = shortUrl.Substring(shortUrl.LastIndexOf("/") + 1);
        return short2long.ContainsKey(randStr) ? short2long[randStr] : shortUrl;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
