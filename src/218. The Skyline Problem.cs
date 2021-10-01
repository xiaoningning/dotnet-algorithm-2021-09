public class Solution {
    // T: O(nlogn)
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        Action<List<int>,int> binarySearchInsert = (q, v) => {
            int l = 0, r = q.Count;
            while (l < r) {
                int m = l + (r - l) / 2;
                if (q[m] <= v) l = m + 1;
                else r = m;
            }
            q.Insert(r, v);
        };
        // need x => handle xi == xj case
        var h = new List<(int,int)>();
        foreach (int[] b in buildings) {
            h.Add((b[0], b[2]));
            h.Add((b[1], -b[2])); // -b[2] mark as end
        }
        h.Sort((x,y) => x.Item1 == y.Item1 ? y.Item2 - x.Item2 : x.Item1 - y.Item1);
        var ans = new List<IList<int>>();
        int prev = 0;
        var pq = new List<int>(){prev}; // priority queue
        foreach (var cur in h) {
            int curH = cur.Item2;
            bool left = cur.Item2 > 0;
            if (left)  {
                if (curH > pq.Last()) ans.Add(new List<int>(){cur.Item1, curH});
                binarySearchInsert(pq, cur.Item2);
            }
            else { // right
                pq.Remove(-cur.Item2);
                if (-curH > pq.Last()) ans.Add(new List<int>(){cur.Item1, pq.Last()});
            }
        }
        /**
        foreach (var cur in h) {
            if (cur.Item2 > 0) binarySearchInsert(pq, cur.Item2);
            else pq.Remove(-cur.Item2);
            if (pq.Last() != prev) {
                ans.Add(new List<int>(){cur.Item1, pq.Last()});
                prev = pq.Last();
            }
        } 
        */
        return ans;
    }
}
