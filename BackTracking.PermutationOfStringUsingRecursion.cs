namespace DSA
{
    public partial class BackTracking
    {
        /// <summary>
        /// Complexity: Number of nodes * work done at each node
        ///  n! * n
        /// </summary>
        public static void PermutationOfStringUsingRecusrion()
        {
            var result = new List<string>();

            PermutationOfStringUsingRecusrion("ABC", "", result);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void PermutationOfStringUsingRecusrion(string input, string output, List<string> result)
        {
            if (input.Length == 0)
            {
                result.Add(output);
                return;
            }

            var map = new HashSet<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!map.Contains(input[i]))
                {
                    map.Add(input[i]);

                    var newInput = input.Substring(0, i) + input.Substring(i + 1);
                    var newOutput = output + input[i];

                    PermutationOfStringUsingRecusrion(newInput, newOutput, result);
                }
                
            }
        }
    }
}
