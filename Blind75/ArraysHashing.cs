//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.

//Example 1:
//Input: nums = [2, 7, 11, 15], target = 9
//Output: [0,1]
//Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].

using System.Threading.Tasks.Dataflow;

int[] TwoSum(int[] ints, int v)
{
    Dictionary<int, int> keyValues= new Dictionary<int, int>();

    foreach (var item in ints.Select((value, index) => new { value, index })){
        int diff = v - item.value;

        if (keyValues.ContainsKey(diff)){
            return new[] { keyValues[diff], item.index };
        }
        else {
            keyValues.Add(item.value, item.index);
        }
    }

    return new[] {0,0};
}


//Input: s = "anagram", t = "nagaram"
//Output: true

//Input: s = "rat", t = "car"
//Output: false

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


    if (s.Length != t.Length)
        return false;

    Dictionary<char, int> scounts = new Dictionary<char, int>();
    Dictionary<char, int> tcounts = new Dictionary<char, int>();

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


