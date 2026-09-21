- パッと見て Stack を使えば良さそうと思えたのは good
- dict を使って ( / ) などのそれぞれのペアを Key / Value 管理しておけばロジックを抽象化できたのでよりスマートだった

```csharp
public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        var dict = new Dictionary<char, char> {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
        };
        for (var i = 0; i < s.Length; i++) {
            var c = s[i];
            if (dict.ContainsKey(c)) {
                stack.Push(c);
            } else if (stack.Count > 0) {
                if (c != dict[stack.Pop()]) return false;
            } else {
                return false;
            }
        }

        if (stack.Count > 0) return false;
        return true;
    }
}
```

- でもこっちのが遅かった (2ms vs 5ms)
  - dict の new
  - ハッシュ探索x2
  - 一方で解答の方は char の比較のみ