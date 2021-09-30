public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int l = 0, r = numbers.Length - 1;
        while (l < r) {
            if (numbers[l] + numbers[r] == target) return new int[]{l+1,r+1};
            else if (numbers[l] + numbers[r] > target) r--;
            else l++;
        }
        return new int[]{};
    }
}
