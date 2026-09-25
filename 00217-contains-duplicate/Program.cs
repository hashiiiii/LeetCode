public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var hash = new HashSet<int>();
        foreach (var n in nums) {
            if (hash.Contains(n)) return true;
            hash.Add(n);
        }
        return false;
    }
}