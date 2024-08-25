namespace DSA
{
    /// <summary>
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    /// </summary>
    public partial class BackTracking
    {
        public static void LetterCombination()
        {
            var result = new List<string>();

            var digits = "23";

            if (digits.Length == 0)
            {
                return;
            }

            var dict = new Dictionary<char, string>();
            dict.Add('2', "abc");
            dict.Add('3', "def");
            dict.Add('4', "ghi");
            dict.Add('5', "jkl");
            dict.Add('6', "mno");
            dict.Add('7', "pqrs");
            dict.Add('8', "tuv");
            dict.Add('9', "wxyz");

            var temp = string.Empty;
            LetterCombination(digits, 0, ref temp, dict, result);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void LetterCombination(string digits, int index, ref string temp, Dictionary<char, string> dict, List<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(temp);
                return;
            }

            var letters = dict[digits[index]];

            for (int i = 0; i < letters.Length; i++)
            {
                temp += letters[i];
                LetterCombination(digits, index + 1, ref temp, dict, result);
                temp = temp.Remove(temp.Length - 1);
            }
        }
    }
}
