public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var length = nums.Length;
        for (var i = 0; i < length - 1; i++)
        {
            var left = nums[i];
            for (var j = i + 1; j < length; j++)
            {
                var right = nums[j];
                if (left + right == target)
                {
                    return [i, j];
                }
            }
        }
        throw new Exception();
    }
}
