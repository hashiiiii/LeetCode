public class Solution {
    public bool IsSubsequence(string s, string t) {
        var lastIndex = 0;
        // 部分列
        if (s.Length > t.Length) return false;
        for (var i = 0; i < s.Length; i++) {
            var sc = s[i];
            // 列
            for (var j = lastIndex; j < t.Length; j++) {
                if (sc == t[j]) {
                    // 列のどこまで見たかを覚えておく
                    lastIndex = j + 1;
                    break;
                }
                if (j == t.Length - 1) {
                    // 最後の要素にも関わらず break せずここに到達しているのはだめ
                    return false;
                }
            }
            // 汚すぎる
            // lastIndex はすでに更新済みなので - 1 してから比較する
            if (i != s.Length - 1 && lastIndex - 1 == t.Length - 1) return false;
        }
        return true;
    }
}
