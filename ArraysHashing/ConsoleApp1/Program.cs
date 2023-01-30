//Input: s = "anagram", t = "nagaram"
//Output: true

//Input: s = "rat", t = "car"
//Output: false

Console.WriteLine(IsAnagram("anagram", "nagaram"));
bool IsAnagram(string s, string t)
{
       //easy approach
        //string s1 = new string (s.OrderBy(c => c).ToArray());
        //string s2 = new string (t.OrderBy(c => c).ToArray());

        //for(int i=0; i< s.Length; i++){
        //    if(s1[i] != s2[i])
        //    {
        //        return false;
        //    }
        //}

        //return true;


    if(s.Length != t.Length)
        return false;

    Dictionary<char, int> scounts= new Dictionary<char, int>();
    Dictionary<char, int> tcounts= new Dictionary<char, int>();

    for (int i = 0; i < s.Length; i++)
    {
        int val = 0;
        
        scounts.TryGetValue(s[i], out val);
        scounts[s[i]] = 1 + val;

        tcounts.TryGetValue(t[i], out val);
        tcounts[t[i]] = 1 + val;
    }

    foreach (var item in scounts)
    {
        int val = 0;
        if (scounts.TryGetValue(item.Key, out val) != tcounts.TryGetValue(item.Key, out val))
            return false;
    }

    return true;
}