- テストケースを真面目に考えるのと、提出を数こなして Accepted に持っていくのどっちがいいんだろうね
- 前者の方が本質的だとは思う
- だいぶ糞コード書いてしまった
- 2ポインタ法, 動的計画法(の親戚)のどちらか

```csharp
public class Solution {
    public bool IsSubsequence(string s, string t) {
        var i = 0, j = 0;
        while (i < s.Length && j < t.Length) {
            if (s[i] == t[j]) {
                i++;
            }
            j++;
        }
        return i == s.Length;
    }
}
```

```csharp
public class Solution {
    public bool IsSubsequence(string s, string t) {
        var nxt = new Dictionary<char, int>[t.Length + 1];
        nxt[t.Length] = new Dictionary<char, int>();

        for (int i = t.Length - 1; i >= 0; i--) {
            nxt[i] = new Dictionary<char, int>(nxt[i + 1]);
            nxt[i][t[i]] = i + 1;
        }

        int position = 0;
        foreach (char c in s) {
            if (nxt[position].TryGetValue(c, out int nextPosition)) {
                position = nextPosition;
            } else {
                return false;
            }
        }
        return true;
    }
}
```

s = abcc
t = adefbghicjklcmn

とする。

t.Length -> 15
nxt[15] = new Dictionary<char, int>() // 空の Dict

最初の配列作成箇所では、

```txt
i = 15: []
i = 14: [{n:15}]
i = 13: [{n:15},{m:14}]
i = 12: [{n:15},{m:14},{c:13}]
i = 11: [{n:15},{m:14},{c:13},{l:12}]
i = 10: [{n:15},{m:14},{c:13},{l:12},{k:11}]
i =  9: [{n:15},{m:14},{c:13},{l:12},{k:11},{j:10}]
i =  8: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10}] // c が 13 -> 9 に上書き
i =  7: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8}]
i =  6: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7}]
i =  5: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7},{g:6}]
i =  4: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7},{g:6},{b:5}]
i =  3: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7},{g:6},{b:5},{f:4}]
i =  2: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7},{g:6},{b:5},{f:4},{e:3}]
i =  1: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7},{g:6},{b:5},{f:4},{e:3},{d:2}]
i =  0: [{n:15},{m:14},{c:9},{l:12},{k:11},{j:10},{i:8},{h:7},{g:6},{b:5},{f:4},{e:3},{d:2},{a:1}]
```

こんな感じで初期化される。ベースとなる文字列 t に含まれる文字をキーに持ち、そのキーの位置 + 1 したものをバリューとして持つ。s を foreach して TryGetKey にてキーを得られれば、その文字はベース文字列の中に存在するということが分かる。また、得られた値を index へ適用することでもう読まなくて良い文字列が取り除かれた状態になる。s の b を取得したタイミングで、adefb は取り除かれるということ。