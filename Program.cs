using System;
using System.Collections.Generic;
using System.Linq;

namespace SecurePrivacyBinary
{
    class Program
    {
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
