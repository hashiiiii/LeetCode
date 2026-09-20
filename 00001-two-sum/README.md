- Dictionary を利用すれば O(n) で書ける

```csharp
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            map[nums[i]] = i;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var left = nums[i];
            var right = target - left;
            if (map.ContainsKey(right) && map[right] != i)
            {
                return [i, map[right]];
            }
        }

        throw new Exception();
    }
}
```

- まず Dictionary を頭に思い浮かべよう