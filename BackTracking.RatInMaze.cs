
namespace DSA
{
    /// <summary>
    /// https://www.geeksforgeeks.org/problems/rat-in-a-maze-problem/1
    /// </summary>
    public partial class BackTracking
    {
        public struct Choice
        {
            public char Direction;
            public int X;
            public int Y;
        }

        public static void FindAllPossiblePaths()
        {
            var maze = new List<List<int>>();
            maze.Add(new List<int> { 1, 0, 0, 0 });
            maze.Add(new List<int> { 1, 1, 0, 1 });
            maze.Add(new List<int> { 1, 1, 0, 0 });
            maze.Add(new List<int> { 0, 1, 1, 1 });

            var choices = new List<Choice>
            {
                new Choice { Direction = 'D', X = 1, Y = 0 },
                new Choice { Direction = 'R', X = 0, Y = 1 },
                new Choice { Direction = 'U', X = -1, Y = 0 },
                new Choice { Direction = 'L', X = 0, Y = -1 }
            };

            var result = new List<string>();
            var path = string.Empty;
            FindAllPossiblePaths(0, 0, result, ref path, maze, choices);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void FindAllPossiblePaths(int x, int y, List<string> result, ref string path, List<List<int>> maze, List<Choice> choices)
        {
            if (x == maze.Count - 1 && y == maze[0].Count - 1)
            {
                result.Add(path);
                return;
            }
           
            foreach (var choice in choices)
            {
                var newX = x + choice.X;
                var newY = y + choice.Y;
                if (IsValid(newX, newY, maze))
                {
                    maze[x][y] = 0;
                    path += choice.Direction;
                    FindAllPossiblePaths(newX, newY, result, ref path, maze, choices);
                    maze[x][y] = 1;
                    path = path.Substring(0, path.Length - 1);
                }   
            }
        }

        private static bool IsValid(int x, int y, List<List<int>> maze)
        {
            return x >= 0 && y >= 0 && x < maze.Count && y < maze[0].Count && maze[x][y] == 1;
        }
    }
}
