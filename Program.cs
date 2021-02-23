using System;
using System.Collections.Generic;
using System.Linq;

namespace permutation_palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestIsPalindrome());
        }

        // a makeshift test function checking (hopefully) most of IsPalindrome's edge cases
        private static bool TestIsPalindrome()
        {
            if (!IsPalindrome("kajak"))
            {
                return false;
            }
            if (!IsPalindrome("halal"))
            {
                return false;
            }
            if (IsPalindrome("haram"))
            {
                return false;
            }
            if (IsPalindrome(""))
            {
                return false;
            }
            if (IsPalindrome(null))
            {
                return false;
            }
            if (!IsPalindrome("Elf układał kufle"))
            {
                return false;
            }
            if (!IsPalindrome("ualłfa fłkduEk el"))
            {
                return false;
            }
            if (!IsPalindrome("kule ma Mameluk"))
            {
                return false;
            }
            if (!IsPalindrome("amk Meel mul ka u"))
            {
                return false;
            }
            if (IsPalindrome("zagwiżdz i w gaz"))
            {
                return false;
            }
            if (!IsPalindrome("||"))
            {
                return false;
            }
            return true;
        }

        private static bool IsPalindrome(string input)
        {
            // if a string is empty or null, it's not a palindrome
            if (input == null)
            {
                return false;
            }
            else if (input == "")
            {
                return false;
            }

            // if a string's length is even and each of its individual letter occurences is divisible by two,
            // or it's length is odd and exactly one of those occurences in not divisible by two,
            // then it can be rearranged into a palindrome

            // using a dictionary to hold letter occurences
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            // if a letter is already indexed, increase it's occurences by one, otherwise add it's first occurence to the dictionary
            // ignoring whitespaces and letter capitalization
            string candidate = new string(input.Where(ch => !char.IsWhiteSpace(ch)).ToArray());

            foreach (char character in candidate)
            {
                char charLowercase = char.ToLower(character);
                if (occurences.ContainsKey(charLowercase))
                {
                    occurences[charLowercase] += 1;
                }
                else
                {
                    occurences.Add(charLowercase, 1);
                }
            }

            if (candidate.Length % 2 == 0)
            {
                foreach (int occurence in occurences.Values)
                {
                    // if any odd occurences are found, the candidate is not a palindrome
                    if (occurence % 2 != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                // a flag checking whether the one odd occurence is found
                bool foundFirstOdd = false;
                foreach (int occurence in occurences.Values)
                {
                    if (occurence % 2 != 0)
                    {
                        if (!foundFirstOdd)
                        {
                            foundFirstOdd = true;
                        }
                        // more than one odd occurence - not a palindrome
                        else
                        {
                            return false;
                        }
                    }
                }
                // exactly one odd occurence
                if (foundFirstOdd)
                {
                    return true;
                }
                // no odd occurences - not a palindrome
            }
            return false;
        }
    }
}
