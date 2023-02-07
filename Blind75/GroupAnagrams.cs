//Given an array of strings strs, group the anagrams together. You can return the answer in any order.
//An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
//typically using all the original letters exactly once.

//Example 1:
//Input: strs = ["eat", "tea", "tan", "ate", "nat", "bat"]
//Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

using System.Collections;
using System.Collections.Generic;
using System.Text;

foreach (var items in GroupAnagrams3(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }))
{
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}



 IList<IList> GroupAnagrams(string[] strs)
{
    var dict = new Dictionary<string, List<string>>();

    foreach (var str in strs)
    {
        var strsorted = new string(str.OrderBy(c => c).ToArray());
        if (dict.ContainsKey(strsorted))
        {
            dict[strsorted].Add(str);
        }
        else
        {
            dict.Add(strsorted, new List<string>() { str });
        }
    }

    return dict.Select(one => one.Value).Cast<IList>().ToList();
}


IList<IList<string>> GroupAnagrams2(string[] strs)
{
    Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

    for (int iterator = 0; iterator < strs.Length; iterator++)
    {
        string word = String.Concat(strs[iterator].OrderBy(x => x));

        if (!dict.ContainsKey(word))
            dict.Add(word, new List<string>() { strs[iterator] });
        else
            dict[word].Add(strs[iterator]);
    }
    var result = dict.Values.ToList();

    return result;
}


IList<IList<string>> GroupAnagrams3(string[] strs)
{

    IList<IList<string>> result = new List<IList<string>>();
    Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

    foreach (string str in strs)
    {
        string key = GenerateKey(str);

        if (!map.ContainsKey(key))
            map[key] = new List<string>();

        map[key].Add(str);
    }

    foreach (var entry in map)
    {
        result.Add(new List<string>(entry.Value));
    }

    return result;
}

// Function to generate keys
static String GenerateKey(String message)
{
    int[] keyArr = new int[26];

    foreach (char c in message)
    {
        int index = c - 'a';
        keyArr[index] = keyArr[index] + 1;
    }

    StringBuilder s = new StringBuilder();
    foreach (var num in keyArr)
    {
        s.Append('#' + num);
    }
    String key = s.ToString();

    return key;
}
