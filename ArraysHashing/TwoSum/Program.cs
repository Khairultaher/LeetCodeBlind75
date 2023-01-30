//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.

//Example 1:
//Input: nums = [2, 7, 11, 15], target = 9
//Output: [0,1]
//Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].

using System.Threading.Tasks.Dataflow;

Console.WriteLine(string.Join(",", TwoSum(new int[] { 2, 7, 11, 15 }, 9)));

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


