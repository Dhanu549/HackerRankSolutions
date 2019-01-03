using System;

namespace HackerRank
{
    public static class AlternatingCharacters
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = alternatingCharacters(s);

                Console.WriteLine(result);
            }
        }

        private static int alternatingCharacters(string s)
        {
            char charToCheck = s[0] == 'A' ? 'B' : 'A';
            int countChars = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != charToCheck)
                    countChars++;
                else
                    charToCheck = charToCheck == 'A' ? 'B' : 'A';
            }
            
            return countChars;
        }
    }
}
