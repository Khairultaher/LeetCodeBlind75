using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Blind75
{
    public class DynamicProgramming
    {
        [Theory]
        [InlineData(5,8)]
        public void ClimbingStairs(int num, int expected)
        {
            int one = 1, two = 1;

            for (int i = 0; i < num-1; i++)
            {
                int temp = one;
                one = one + two;
                two = temp;
            }

            Assert.Equal(expected, one);
        }

        [Theory]
        [InlineData(new int[] { 1,2,3,1}, 4)]
        public void HouseRobber(int[] nums, int expected)
        {
            int rob1 = 0, rob2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            Assert.Equal(expected, rob2);
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
        public void HouseRobber2(int[] nums, int expected)
        {

            int actual = Math.Max(
                Helper(nums.Skip(1).Take(nums.Length -1).ToArray()), 
                Helper(nums.Take(nums.Length -1).ToArray()));

            Assert.Equal(expected, actual);

            int Helper(int[] nums)
            {
                int rob1 = 0, rob2 = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    int temp = Math.Max(rob1 + nums[i], rob2);
                    rob1 = rob2;
                    rob2 = temp;
                }

                return rob2;
            }           
        }        
        
        [Theory]
        [InlineData("babad", "bab")]
        public void LongestPalindromicSubstring(string s, string expected)
        {
            string actual = "";
            int actualLen = 0;
            for(int i = 0; i < s.Length; i++)
            {
                // odd length
                int l = i, r = i;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (r - l + 1 > actualLen)
                    {
                        actual = s.Substring(l, r + 1);
                        actualLen = r - l + 1;
                    }
                    l = l - 1;
                    r = r + 1;
                }
                // even length
                l = i; r = i + 1;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (r - l + 1 > actualLen)
                    {
                        actual = s.Substring(l, r + 1);
                        actualLen = r - l + 1;
                    }
                    l = l - 1;
                    r = r + 1;
                }

            }
            Assert.Equal(expected, actual);
                  
        }


        /// <summary>
        /// Given a string s, return the number of palindromic substrings in it.
        /// A string is a palindrome when it reads the same backward as forward.
        /// A substring is a contiguous sequence of characters within the string.
        /// </summary>
        [Theory]
        [InlineData("abc", 3)]
        [InlineData("aaa", 6)]
        public void PalindromicSubstrings(string s, int expected)
        {
            // arrange
            int CountPalindrom(string s, int l, int r)
            {
                int count = 0;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }
                return count;
            }

            // act 
            int actual = 0;
            for (int i = 0; i < s.Length; i++)
            {
                actual += CountPalindrom(s, i, i);
                actual += CountPalindrom(s, i, i + 1);
            }

            // asert
            Assert.Equal(expected, actual);


        }
    }
}