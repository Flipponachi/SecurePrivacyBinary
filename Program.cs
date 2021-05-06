using System;
using System.Collections.Generic;
using System.Linq;

namespace SecurePrivacyBinary
{
    class Program
    {
        /*
         * We define the following:
            ● A binary string is a string consisting only of 0's and/or 1's.
            For example, 01011, 1111, and 00 are all binary strings.
            ● The prefix of a string is any substring of the string that
            includes the beginning of the string. For example, the
            prefixes of 11010 are 1, 11, 110, 1101, and 11010.
            We consider a non-empty binary string to be good if the following
            two conditions are true:
            1. The number of 0's is equal to the number of 1's.
            2. For every prefix of the binary string, the number of 1's should
            not be less than the number of 0's.
            For example, 11010 is not good because it doesn't have an equal
            number of 0's and 1's, but 110010 is good because it satisfies both
            of the above conditions.
            Create a function that takes as input a binary string and outputs
            whether it’s a a good binary string.
         */
        static bool IsValidBinaryString(string binaryString)
        {
            //count the number of 0's in the string
            if (!string.IsNullOrEmpty(binaryString))
            {

                int zeroCount = binaryString.Count(e => e == '0');
                int oneCount = binaryString.Length - zeroCount;
                if(zeroCount == oneCount)
                {
                    //proceed to calculate the substring
                    //create a list with all possible substring of the word and then loop to see if its valid
                    List<string> possibleSubStr = new List<string>();

                    for(int i = 0; i < binaryString.Length; i++)
                    {
                        string temp = binaryString.Substring(0, i + 1);
                        possibleSubStr.Add(temp);
                    }

                    foreach (var sub in possibleSubStr)
                    {
                        zeroCount = sub.Count(e => e == '0');
                        oneCount = sub.Length - zeroCount;
                        if(oneCount < zeroCount)
                        {
                            return false;
                        }
                        
                    }

                    return true;
                }

                return false;

            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsValidBinaryString("110010"));
            Console.ReadLine();
        }
    }
}
