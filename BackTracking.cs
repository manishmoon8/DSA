namespace DSA
{
    public partial class BackTracking
    {
        private static string Swap(string s, int start, int i)
        {
            var arr = s.ToCharArray();
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
            return new string(arr);
        }
    }
}
