public class Solution {
    public int MaxProfit(int[] prices) {
        var hi = prices[0];
        var lo = prices[0];
        var diff = 0;
        for (var i = 1; i < prices.Length; i++) {
            var p = prices[i];
            if (p < lo) {
                if (diff < hi - lo) {
                    diff = hi - lo;
                }
                lo = p;
                hi = p;
            } else if (p > hi) {
                if (diff < p - lo) {
                    diff = p - lo;
                }
                hi = p;
            }

            // lo <= p <= hi
            continue;
        }

        return diff;
    }
}