using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SudokuSover
{
    public partial class Form1 : Form
    {
        string[] board = { ".........",
                           ".........",
                           ".........",
                           ".........",
                           ".........",
                           ".........",
                           ".........",
                           ".........",
                           "........." };


        int test = 0;

        int progress = 0;
        int ProgressDone;

        Calculations calc = new Calculations();
        public delegate bool invokeBoardPointer();
        public delegate void invokePrint();

        public Form1()
        {
            InitializeComponent();

            
        }
       
        private void printBoard()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
            {

                board = calc.board2;

                richTextBox1.Text = Convert.ToString(board[0][0]);
                richTextBox2.Text = Convert.ToString(board[0][1]);
                richTextBox3.Text = Convert.ToString(board[0][2]);
                richTextBox4.Text = Convert.ToString(board[0][3]);
                richTextBox5.Text = Convert.ToString(board[0][4]);
                richTextBox6.Text = Convert.ToString(board[0][5]);
                richTextBox7.Text = Convert.ToString(board[0][6]);
                richTextBox8.Text = Convert.ToString(board[0][7]);
                richTextBox9.Text = Convert.ToString(board[0][8]);

                richTextBox18.Text = Convert.ToString(board[1][0]);
                richTextBox17.Text = Convert.ToString(board[1][1]);
                richTextBox16.Text = Convert.ToString(board[1][2]);
                richTextBox15.Text = Convert.ToString(board[1][3]);
                richTextBox14.Text = Convert.ToString(board[1][4]);
                richTextBox13.Text = Convert.ToString(board[1][5]);
                richTextBox12.Text = Convert.ToString(board[1][6]);
                richTextBox11.Text = Convert.ToString(board[1][7]);
                richTextBox10.Text = Convert.ToString(board[1][8]);

                richTextBox27.Text = Convert.ToString(board[2][0]);
                richTextBox26.Text = Convert.ToString(board[2][1]);
                richTextBox25.Text = Convert.ToString(board[2][2]);
                richTextBox24.Text = Convert.ToString(board[2][3]);
                richTextBox23.Text = Convert.ToString(board[2][4]);
                richTextBox22.Text = Convert.ToString(board[2][5]);
                richTextBox21.Text = Convert.ToString(board[2][6]);
                richTextBox20.Text = Convert.ToString(board[2][7]);
                richTextBox19.Text = Convert.ToString(board[2][8]);


                richTextBox36.Text = Convert.ToString(board[3][0]);
                richTextBox35.Text = Convert.ToString(board[3][1]);
                richTextBox34.Text = Convert.ToString(board[3][2]);
                richTextBox33.Text = Convert.ToString(board[3][3]);
                richTextBox32.Text = Convert.ToString(board[3][4]);
                richTextBox31.Text = Convert.ToString(board[3][5]);
                richTextBox30.Text = Convert.ToString(board[3][6]);
                richTextBox29.Text = Convert.ToString(board[3][7]);
                richTextBox28.Text = Convert.ToString(board[3][8]);

                richTextBox45.Text = Convert.ToString(board[4][0]);
                richTextBox44.Text = Convert.ToString(board[4][1]);
                richTextBox43.Text = Convert.ToString(board[4][2]);
                richTextBox42.Text = Convert.ToString(board[4][3]);
                richTextBox41.Text = Convert.ToString(board[4][4]);
                richTextBox40.Text = Convert.ToString(board[4][5]);
                richTextBox39.Text = Convert.ToString(board[4][6]);
                richTextBox38.Text = Convert.ToString(board[4][7]);
                richTextBox37.Text = Convert.ToString(board[4][8]);


                richTextBox54.Text = Convert.ToString(board[5][0]);
                richTextBox53.Text = Convert.ToString(board[5][1]);
                richTextBox52.Text = Convert.ToString(board[5][2]);
                richTextBox51.Text = Convert.ToString(board[5][3]);
                richTextBox50.Text = Convert.ToString(board[5][4]);
                richTextBox49.Text = Convert.ToString(board[5][5]);
                richTextBox48.Text = Convert.ToString(board[5][6]);
                richTextBox47.Text = Convert.ToString(board[5][7]);
                richTextBox46.Text = Convert.ToString(board[5][8]);

                richTextBox63.Text = Convert.ToString(board[6][0]);
                richTextBox62.Text = Convert.ToString(board[6][1]);
                richTextBox61.Text = Convert.ToString(board[6][2]);
                richTextBox60.Text = Convert.ToString(board[6][3]);
                richTextBox59.Text = Convert.ToString(board[6][4]);
                richTextBox58.Text = Convert.ToString(board[6][5]);
                richTextBox57.Text = Convert.ToString(board[6][6]);
                richTextBox56.Text = Convert.ToString(board[6][7]);
                richTextBox55.Text = Convert.ToString(board[6][8]);


                richTextBox72.Text = Convert.ToString(board[7][0]);
                richTextBox71.Text = Convert.ToString(board[7][1]);
                richTextBox70.Text = Convert.ToString(board[7][2]);
                richTextBox69.Text = Convert.ToString(board[7][3]);
                richTextBox68.Text = Convert.ToString(board[7][4]);
                richTextBox67.Text = Convert.ToString(board[7][5]);
                richTextBox66.Text = Convert.ToString(board[7][6]);
                richTextBox65.Text = Convert.ToString(board[7][7]);
                richTextBox64.Text = Convert.ToString(board[7][8]);

                richTextBox81.Text = Convert.ToString(board[8][0]);
                richTextBox80.Text = Convert.ToString(board[8][1]);
                richTextBox79.Text = Convert.ToString(board[8][2]);
                richTextBox78.Text = Convert.ToString(board[8][3]);
                richTextBox77.Text = Convert.ToString(board[8][4]);
                richTextBox76.Text = Convert.ToString(board[8][5]);
                richTextBox75.Text = Convert.ToString(board[8][6]);
                richTextBox74.Text = Convert.ToString(board[8][7]);
                richTextBox73.Text = Convert.ToString(board[8][8]);

                
            });
            }
            catch (Exception) { }

            //timer1.Stop();
        }      

        private void LoadSudoku_Click(object sender, EventArgs e)
        {
            LoadSudoku.Enabled = false;
            
            //// Inserting the number in string array board.
            setBoard();

            //// Gets the progrssBar to update.
            
            progressBar1.Maximum = 81;
            progressBar1.Minimum = 0;

            
            //Thread DoSudoku = new Thread(new ThreadStart(calc.CalcMain()));
            invokeBoardPointer objPointer = new invokeBoardPointer(calc.CalcMain);
            invokePrint printPointer = new invokePrint(printBoard);

            new Thread(() =>
            {
                if (objPointer.Invoke() == true)
                {
                    printBoard();
                }
                else
                {
                    MessageBox.Show("No Sulution");
                }
            }).Start();
            timer1.Start();
        }
        private void check_numbers(RichTextBox text, int row, int col)
        {
            if (text.Text.Length == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (text.Text == i.ToString())
                    {
                        sb_board(row, col, i.ToString());
                    }
                }
            }
            else if (text.Text.Length >= 1)
            {
                MessageBox.Show("Only One Number Can be Inputed");
            }
        }
        private void sb_board(int row, int index, string number)
        {
            StringBuilder sb_Change_Baord = new StringBuilder(calc.board2[row]);
            sb_Change_Baord.Remove(index, 1);
            sb_Change_Baord.Insert(index, number);
            calc.board2[row] = sb_Change_Baord.ToString();
        }

        private void Clera_button_Click(object sender, EventArgs e)
        {
            // Clears the richTextBoxes.
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();

            richTextBox18.Clear();
            richTextBox17.Clear();
            richTextBox16.Clear();
            richTextBox15.Clear();
            richTextBox14.Clear();
            richTextBox13.Clear();
            richTextBox12.Clear();
            richTextBox11.Clear();
            richTextBox10.Clear();
                      
            richTextBox27.Clear();
            richTextBox26.Clear();
            richTextBox25.Clear();
            richTextBox24.Clear();
            richTextBox23.Clear();
            richTextBox22.Clear();
            richTextBox21.Clear();
            richTextBox20.Clear();
            richTextBox19.Clear();
                        
            richTextBox36.Clear();
            richTextBox35.Clear();
            richTextBox34.Clear();
            richTextBox33.Clear();
            richTextBox32.Clear();
            richTextBox31.Clear();
            richTextBox30.Clear();
            richTextBox29.Clear();
            richTextBox28.Clear();
                    
            richTextBox45.Clear();
            richTextBox44.Clear();
            richTextBox43.Clear();
            richTextBox42.Clear();
            richTextBox41.Clear();
            richTextBox40.Clear();
            richTextBox39.Clear();
            richTextBox38.Clear();
            richTextBox37.Clear();
                       
            richTextBox54.Clear();
            richTextBox53.Clear();
            richTextBox52.Clear();
            richTextBox51.Clear();
            richTextBox50.Clear();
            richTextBox49.Clear();
            richTextBox48.Clear();
            richTextBox47.Clear();
            richTextBox46.Clear();
                       
            richTextBox63.Clear();
            richTextBox62.Clear();
            richTextBox61.Clear();
            richTextBox60.Clear();
            richTextBox59.Clear();
            richTextBox58.Clear();
            richTextBox57.Clear();
            richTextBox56.Clear();
            richTextBox55.Clear();
                         
            richTextBox72.Clear();
            richTextBox71.Clear();
            richTextBox70.Clear();
            richTextBox69.Clear();
            richTextBox68.Clear();
            richTextBox67.Clear();
            richTextBox66.Clear();
            richTextBox65.Clear();
            richTextBox64.Clear();

            richTextBox81.Clear();
            richTextBox80.Clear();
            richTextBox79.Clear();
            richTextBox78.Clear();
            richTextBox77.Clear();
            richTextBox76.Clear();
            richTextBox75.Clear();
            richTextBox74.Clear();
            richTextBox73.Clear();

            // Resets the boards.
            for (int i = 0; i < 9; i++)
            {
                calc.board2[i] = ".........";
                board[i] = ".........";
            }
            progressBar1.Value = 0;

            // Lets you start the suduko solver again.
            LoadSudoku.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Increment(ProgressDone);
            //progressBar1.Value = ProgressDone;
        }
        private void setBoard()
        {
            check_numbers(richTextBox1, 0, 0);
            check_numbers(richTextBox2, 0, 1);
            check_numbers(richTextBox3, 0, 2);
            check_numbers(richTextBox4, 0, 3);
            check_numbers(richTextBox5, 0, 4);
            check_numbers(richTextBox6, 0, 5);
            check_numbers(richTextBox7, 0, 6);
            check_numbers(richTextBox8, 0, 7);
            check_numbers(richTextBox9, 0, 8);

            check_numbers(richTextBox18, 1, 0);
            check_numbers(richTextBox17, 1, 1);
            check_numbers(richTextBox16, 1, 2);
            check_numbers(richTextBox15, 1, 3);
            check_numbers(richTextBox14, 1, 4);
            check_numbers(richTextBox13, 1, 5);
            check_numbers(richTextBox12, 1, 6);
            check_numbers(richTextBox11, 1, 7);
            check_numbers(richTextBox10, 1, 8);

            check_numbers(richTextBox27, 2, 0);
            check_numbers(richTextBox26, 2, 1);
            check_numbers(richTextBox25, 2, 2);
            check_numbers(richTextBox24, 2, 3);
            check_numbers(richTextBox23, 2, 4);
            check_numbers(richTextBox22, 2, 5);
            check_numbers(richTextBox21, 2, 6);
            check_numbers(richTextBox20, 2, 7);
            check_numbers(richTextBox19, 2, 8);



            check_numbers(richTextBox36, 3, 0);
            check_numbers(richTextBox35, 3, 1);
            check_numbers(richTextBox34, 3, 2);
            check_numbers(richTextBox33, 3, 3);
            check_numbers(richTextBox32, 3, 4);
            check_numbers(richTextBox31, 3, 5);
            check_numbers(richTextBox30, 3, 6);
            check_numbers(richTextBox29, 3, 7);
            check_numbers(richTextBox28, 3, 8);

            check_numbers(richTextBox45, 4, 0);
            check_numbers(richTextBox44, 4, 1);
            check_numbers(richTextBox43, 4, 2);
            check_numbers(richTextBox42, 4, 3);
            check_numbers(richTextBox41, 4, 4);
            check_numbers(richTextBox40, 4, 5);
            check_numbers(richTextBox39, 4, 6);
            check_numbers(richTextBox38, 4, 7);
            check_numbers(richTextBox37, 4, 8);

            check_numbers(richTextBox54, 5, 0);
            check_numbers(richTextBox53, 5, 1);
            check_numbers(richTextBox52, 5, 2);
            check_numbers(richTextBox51, 5, 3);
            check_numbers(richTextBox50, 5, 4);
            check_numbers(richTextBox49, 5, 5);
            check_numbers(richTextBox48, 5, 6);
            check_numbers(richTextBox47, 5, 7);
            check_numbers(richTextBox46, 5, 8);



            check_numbers(richTextBox63, 6, 0);
            check_numbers(richTextBox62, 6, 1);
            check_numbers(richTextBox61, 6, 2);
            check_numbers(richTextBox60, 6, 3);
            check_numbers(richTextBox59, 6, 4);
            check_numbers(richTextBox58, 6, 5);
            check_numbers(richTextBox57, 6, 6);
            check_numbers(richTextBox56, 6, 7);
            check_numbers(richTextBox55, 6, 8);

            check_numbers(richTextBox72, 7, 0);
            check_numbers(richTextBox71, 7, 1);
            check_numbers(richTextBox70, 7, 2);
            check_numbers(richTextBox69, 7, 3);
            check_numbers(richTextBox68, 7, 4);
            check_numbers(richTextBox67, 7, 5);
            check_numbers(richTextBox66, 7, 6);
            check_numbers(richTextBox65, 7, 7);
            check_numbers(richTextBox64, 7, 8);

            check_numbers(richTextBox81, 8, 0);
            check_numbers(richTextBox80, 8, 1);
            check_numbers(richTextBox79, 8, 2);
            check_numbers(richTextBox78, 8, 3);
            check_numbers(richTextBox77, 8, 4);
            check_numbers(richTextBox76, 8, 5);
            check_numbers(richTextBox75, 8, 6);
            check_numbers(richTextBox74, 8, 7);
            check_numbers(richTextBox73, 8, 8);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync(ProgressDone);
            progress = 0;
            for (int progress1 = 0; progress1 < 9; progress1++)
            {
                for (int progress2 = 0; progress2 < 9; progress2++)
                {
                    if (calc.board2[progress1][progress2] == '.')
                    {
                        progress++;
                    }
                }
            }

            switch (progress)
            {
                case 0:
                    progressBar1.Value = 81;
                    break;
                case 9:
                    progressBar1.Value = 81;
                    break;
                case 18:
                    progressBar1.Value = 72;
                    break;
                case 27:
                    progressBar1.Value = 63;
                    break;
                case 36:
                    progressBar1.Value = 54;
                    break;
                case 45:
                    progressBar1.Value = 45;
                    break;
                case 54:
                    progressBar1.Value = 36;
                    break;
                case 63:
                    progressBar1.Value = 27;
                    break;
                case 72:
                    progressBar1.Value = 18;
                    break;
                case 81:
                    progressBar1.Value = 9;
                    break;
            }
               if (progressBar1.Value == 81)
                timer1.Stop();
        }
    }
}