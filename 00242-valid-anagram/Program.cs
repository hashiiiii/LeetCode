public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;
        var dict_s = new Dictionary<char, int>();
        var dict_t = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++) {
            if (dict_s.ContainsKey(s[i])) {
                dict_s[s[i]]++;
            } else {
                dict_s[s[i]] = 1;
            }
            if (dict_t.ContainsKey(t[i])) {
                dict_t[t[i]]++;
            } else {
                dict_t[t[i]] = 1;
            }
        }
        for (var i = 0; i < s.Length; i++) {
            if (!dict_t.ContainsKey(s[i]) || dict_s[s[i]] != dict_t[s[i]]) return false;
        }
        return true;
    }
}