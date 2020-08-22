using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SudokuSover
{
    public class Calculations
    {
        public string[] board2 = { ".........",
                                   ".........",
                                   ".........",
                                   ".........",
                                   ".........",
                                   ".........",
                                   ".........",
                                   ".........",
                                   "........." };

        const int boardWidth = 9;
        const int amountOfNums = 9;
        List<string> possibilities;
        int manyTimes = 0;
        public bool result;

        public bool CalcMain()
        {
            if (solve() == true)
                return true;

            else
                return false; 
        }
        private bool solve()
        {
            try
            {
                fillAllObvious();
            }
            catch (Exception)
            {
                return false;
            }
            // Get the possitsion for the dot.
            if (isComlete() == true) { return true; }

            // Finds a dot and get the location.
            int i = 0, j = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board2[row][col] == '.')
                    {
                        i = row;
                        j = col;
                    }
                }
            }
            possibilities = getPossibilitis(i, j);

            foreach (var value in possibilities)
            {
                // Makes a copy of the board for backtracking.
                string[] FisrtCopy = new string[board2.Length];
                Array.Copy(board2, FisrtCopy, board2.Length);

                // Inserting the possibility
                string change0 = board2[i];
                StringBuilder change = new StringBuilder(change0);
                change.Remove(j, 1);
                change.Insert(j, value);
                board2[i] = change.ToString();

                bool result = solve();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    // board = copy
                    board2 = FisrtCopy;
                }
            }
            return false;
        }
        private void fillAllObvious()
        {
            for (int row = 0; row < 9; row++)
                {
                    for (int line = 0; line < 9; line++)
                    {
                        // If where's only one possibity, insert.
                        List<string> Possibilitis = getPossibilitis(row, line);
                        if (board2[Convert.ToInt32(row)][line] == '.')
                        {
                            if (Possibilitis.Count == 1)
                            {
                                string changeLine = board2[row];
                                StringBuilder changeIndex = new StringBuilder(changeLine);
                                changeIndex.Remove(line, 1);
                                changeIndex.Insert(line, Possibilitis[0]);
                                board2[row] = changeIndex.ToString();
                            }
                        }
                    }
                }
            
        }
        private List<string> getPossibilitis(int row, int num_in_poss)
        {
            // If the possition is a number; return a list with 0 in it.
            for (int aNumber = 1; aNumber < 10; aNumber++)
            {
                if (Convert.ToString(board2[row][num_in_poss]) == Convert.ToString(aNumber))
                {
                    List<string> takenNumber = new List<string>(amountOfNums);
                    return takenNumber;
                }
            }

            // Check for the x axis.
            // Creats the list to hold the numbers.
            List<string> listOfNums = new List<string>(9);

            // Clears the list from used numbers.
            listOfNums.Clear();

            // Add numbers 1 to 9 in a dictionary.
            for (int add = 1; add <= 9; add++) { listOfNums.Add(Convert.ToString(add)); }

            // Check for the numbers in a line.
            string poss;
            for (int j = 0; j < amountOfNums; j++)
            {
                poss = Convert.ToString(j);
                for (int i = 0; i < boardWidth; i++)
                {
                    if (Convert.ToString(board2[row][i]) == poss) { listOfNums.Remove(poss); }
                }
            }

            // Removes numbers from the y axis.
            List<string> yPoss = new List<string>(amountOfNums);

            string poss2;
            for (int add_y = 1; add_y <= amountOfNums; add_y++) { yPoss.Add(Convert.ToString(add_y)); }
            for (int numOfTimes = 0; numOfTimes <= amountOfNums; numOfTimes++)
            {
                poss2 = Convert.ToString(numOfTimes);
                for (int possibilitys_y = 0; possibilitys_y < amountOfNums; possibilitys_y++)
                {
                    if (Convert.ToString(board2[possibilitys_y][num_in_poss]) == poss2) { listOfNums.Remove(poss2); }
                }
            }

            // Detects witch block the possition is in and removes the numbers.            
            int iStart = (row / 3) * 3;
            int jStart = (num_in_poss / 3) * 3;

            for (int rowNum = iStart; rowNum <= iStart + 2; rowNum++)
            {
                for (int lineNum = jStart; lineNum <= jStart + 2; lineNum++)
                {
                    for (int blockNum = 1; blockNum < 10; blockNum++)
                    {
                        if (Convert.ToString(board2[rowNum][lineNum]) == Convert.ToString(blockNum))
                        {
                            listOfNums.Remove(Convert.ToString(blockNum));
                        }
                    }
                }
            }
            return listOfNums;
        }

        private bool isComlete()
        {
            // Looks through the board, to see if it's done.
            foreach (var row in board2)
            {
                foreach (var col in row)
                {
                    if (col == '.') { return false; }
                }
            }
            return true;
        }
    }
}
