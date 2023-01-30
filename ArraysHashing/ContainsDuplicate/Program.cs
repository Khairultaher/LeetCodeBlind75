
int[] tnums = new int[] { 1, 2, 3, 1 };
//Output: true

int[] fnums = new int[] { 1, 2, 3, 4 };
//Output: false

Console.WriteLine(ContainsDuplicate(tnums));


bool ContainsDuplicate(int[] nums)
{
    HashSet<int> ints= new HashSet<int>();

	foreach (var num in nums)
	{
		if (ints.Contains(num))
			return true;
		else
			ints.Add(num);
	}
	return false;
}
