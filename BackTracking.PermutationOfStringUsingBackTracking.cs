namespace DSA
{
    public partial class BackTracking
    {
        public static void PermutationOfStringUsingBackTracking()
        {
            var result = new List<string>();
            PermutationOfStringUsingBackTracking("ABC", 0, result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void PermutationOfStringUsingBackTracking(string s, int start, List<string> result)
        {
            if (start == s.Length -1)
            {
                result.Add(s);
                return;
            }

            var map = new HashSet<char>();
            for (int i = start; i < s.Length; i++)
            {
                if (!map.Contains(s[i]))
                {
                    map.Add(s[i]);
                    s = Swap(s, start, i);
                    PermutationOfStringUsingBackTracking(s, start + 1, result);
                    s = Swap(s, start, i);
                }
            }
        }
    }
}
