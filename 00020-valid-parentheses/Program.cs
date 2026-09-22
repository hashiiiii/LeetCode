public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        var ok = true;
        for (var i = 0; i < s.Length; i++) {
            var c = s[i];
            if (c is '(' or '{' or '[')
            {
                stack.Push(c);
                if (i < s.Length - 1) continue;
                // 最後の要素が開始括弧の場合
                ok = false;
                break;
            }

            if (c is ')')
            {
                if (stack.Count <= 0) {
                    ok = false;
                    break;
                }
                var v = stack.Pop();
                if (v == '(') continue;
                ok = false;
                break;
            }

            if (c is '}')
            {
                if (stack.Count <= 0) {
                    ok = false;
                    break;
                }
                var v = stack.Pop();
                if (v == '{') continue;
                ok = false;
                break;
            }

            if (c is ']')
            {
                if (stack.Count <= 0) {
                    ok = false;
                    break;
                }
                var v = stack.Pop();
                if (v == '[') continue;
                ok = false;
                break;
            }

        }

        if (stack.Count > 0)
        {
            ok = false;
        }

        return ok;
    }
}