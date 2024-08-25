

namespace DSA
{
    /// <summary>
    /// https://www.geeksforgeeks.org/problems/n-queen-problem0315/1
    /// </summary>
    public partial class BackTracking
    {
        public static void NQueens()
        {
            int n = 4;
            var board = new List<List<int>>();

            // create a board of nxn using above board list
            for (int i = 0; i < n; i++)
            {
                var tempCol = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    tempCol.Add(0);
                }
                board.Add(tempCol);
            }

            var temp = new List<int>();
            var ans = new List<List<int>>();
            NQueens(0, board, temp, ans);

            foreach (var item in ans)
            {
                Console.WriteLine(string.Join(" ", item));
            } 
        }

        private static void NQueens(int col, List<List<int>> board, List<int> temp, List<List<int>> ans)
        {
            if (col == board.Count)
            {
                ans.Add(new List<int>(temp));
                return;
            }

            for (int rowIndex = 0; rowIndex < board.Count; rowIndex++)
            {
                if (IsSafe(board, rowIndex, col))
                {
                    board[rowIndex][col] = 1;
                    temp.Add(rowIndex + 1);
                    NQueens(col + 1, board, temp, ans);
                    board[rowIndex][col] = 0;
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }

        private static bool IsSafe(List<List<int>> board, int row, int colIndex)
        {
            // check row
            for (int col = 0; col < colIndex; col++)
            {
                if (board[row][col] == 1)
                {
                    return false;
                }
            }

            // check upper diagonal on left side
            for (int i = row, j = colIndex; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 1)
                {
                    return false;
                }
            }

            // check lower diagonal on left side
            for (int i = row, j = colIndex; i < board.Count && j >= 0; i++, j--)
            {
                if (board[i][j] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
