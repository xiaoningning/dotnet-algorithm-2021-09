public class Solution {
    public int FindKthLargest1(int[] nums, int k) {
        Array.Sort(nums);
        Array.Reverse(nums);
        return nums[k - 1];
    }
    // quick sort / parition
    public int FindKthLargest(int[] nums, int k) {
        Action<int,int> swap = (x, y) => {
            int t = nums[x]; nums[x] = nums[y]; nums[y] = t;
        };
        Func<int, int, int> partitionSort = (left, right) => {
            int pivot = nums[left], l = left + 1, r = right;
            while (l <= r) {
                if (nums[l] < pivot && nums[r] > pivot) {
                    swap(l,r);
                    l++; r--;
                }
                // must be after swap of the above => move point correctly
                if (nums[l] >= pivot) l++;
                if (nums[r] <= pivot) r--;
            }
            swap(left, r); // r-- already, := nums[r] is already > pivot
            return r;
        };
        int l = 0, r = nums.Length - 1;
        while (true) {
            int pos = partitionSort(l, r);
            if (pos == k - 1) return nums[pos];
            if (pos > k - 1) r = pos - 1;
            else l = pos + 1;
        }
    }
}
