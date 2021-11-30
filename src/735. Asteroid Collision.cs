public class Solution {
    // T: O(n), S: O(n)
    public int[] AsteroidCollision(int[] asteroids) {
        var ans = new List<int>();
        for (int i = 0; i < asteroids.Length; i++) {
            int size = asteroids[i];
            if (size > 0) ans.Add(size);
            else {
                if (!ans.Any() || ans.Last() < 0) ans.Add(size); // no more + OR all -
                else if (Math.Abs(ans.Last()) <= Math.Abs(size)) {
                    if (Math.Abs(ans.Last()) < Math.Abs(size)) --i;
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }
        return ans.ToArray(); // ans must look like [-s1, -s2, ... , si, sj, ...]
    }
}
