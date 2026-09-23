public class Solution {
    public int Search(int[] nums, int target) {
        var lo = 0;
        var hi = nums.Length - 1;
        while (lo <= hi) {
            // 絶対位置が必要なので lo を足している
            int mid = lo + (hi - lo + 1) / 2;
            if (nums[mid] == target) {
                return mid;
            } else if (nums[mid] < target) {
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        return -1;
    }
}