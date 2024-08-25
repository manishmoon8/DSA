

namespace DSA
{
    /// <summary>
    /// https://leetcode.com/problems/sudoku-solver/
    /// </summary>
    public partial class BackTracking
    {
        public static void SudokuSolver()
        {
            int n = 9;
            List<List<char>> board = new List<List<char>>
            {
                new List<char> {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new List<char> {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new List<char> {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new List<char> {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new List<char> {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new List<char> {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new List<char> {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new List<char> {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new List<char> {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            bool isSuccess = SudokuSolver(0, 0, board);

            if (isSuccess)
            {
                foreach (var row in board)
                {
                    foreach (var item in row)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No solution exists");
            }
        }

        private static bool SudokuSolver(int rowIndex, int colIndex, List<List<char>> board)
        {
            if (rowIndex == board.Count)
            {
                return true;
            }

            if (colIndex == board.Count)
            {
                return SudokuSolver(rowIndex + 1, 0, board);
            }

            if (board[rowIndex][colIndex] != '.')
            {
                return SudokuSolver(rowIndex, colIndex + 1, board);
            }

            for (char c = '1'; c <= '9'; c++)
            {
                if (IsValid(rowIndex, colIndex, c, board))
                {
                    board[rowIndex][colIndex] = c;
                    if (SudokuSolver(rowIndex, colIndex + 1, board))
                    {
                        return true;
                    }
                    board[rowIndex][colIndex] = '.';
                }
            }

            return false;
        }

        private static bool IsValid(int rowIndex, int colIndex, char c, List<List<char>> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (board[rowIndex][i] == c || board[i][colIndex] == c)
                {
                    return false;
                }
            }

            int startRow = 3 * (rowIndex / 3);
            int startCol = 3 * (colIndex / 3);
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (board[i][j] == c)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
