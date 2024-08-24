
namespace DSA
{
    public partial class BackTracking
    {
        public static void NDigitsNumberInIncreasingOrder()
        {
            int n = 2;
            var result = new List<int>();

            if (n == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    result.Add(i);
                }

                return;
            }

            var temp = new List<int>();
            NDigitsNumberInIncreasingOrder(result, temp, n, 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void NDigitsNumberInIncreasingOrder(List<int> result, List<int> temp, int n, int start)
        {
            if (n == 0)
            {
                int ans = 0;
                for (int i = 0; i < temp.Count; i++)
                {
                    ans = ans * 10 + temp[i];
                }

                result.Add(ans);

                return;
            }

            for (int i = start + 1; i < 10; i++)
            {
                temp.Add(i);
                NDigitsNumberInIncreasingOrder(result, temp, n - 1, i);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
