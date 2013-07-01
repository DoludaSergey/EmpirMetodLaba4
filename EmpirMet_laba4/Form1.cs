using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmpirMet_laba4
{
    public partial class Form1 : Form
    {

        //матрица первой системы   
        double[,] A = {
                            {3,2,2},
                            {1,-2,5},
                            {-2,-3,4}
                        };
        public static int n = 3;
        int r = 0, s = 0;
        //матрица для сохранения первой системы
        double[,] Save ={
                             {3,2,2},
                            {1,-2,5},
                            {-2,-3,4}
                        };
        //матрица для сохранения второй системы
        double[,] Save2 ={
                             {3,2,2,1},
                            {1,-2,5,5},
                            {-2,-3,4,3}
                        };
        //матрица второй системы
        double[,] A2 ={
                             {3,2,2,1},
                            {1,-2,5,5},
                            {-2,-3,4,3}
                        };

        
        public Form1()
        {                       
            InitializeComponent();
        }

        public void First(ref double[,] A, ref double rasr, ref int r, ref int s)
        {
            while (s != n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i != r) && (j != s))
                            A[i, j] = Save[i, j] - (Save[i, s] * Save[r, j]) / Save[r, s];
                        if (j == s)
                            A[i, j] = Save[i, j] / rasr;
                        if (i == r)
                            A[i, j] = Save[i, j] / (-rasr);
                    }
                }
                A[r, s] = 1 / rasr;
                SaveMatrix(ref A);
                r++; s++;
                if (r == n)
                    break;
                rasr = A[r, s];
            }

            double res1 = A[0, 0] * 1 + A[0, 1] * 5 + A[0, 2] * 3;
            double res2 = A[1, 0] * 1 + A[1, 1] * 5 + A[1, 2] * 3;
            double res3 = A[2, 0] * 1 + A[2, 1] * 5 + A[2, 2] * 3;
            textBox1.AppendText("Result 1= " + res1 + "\r\n" + "Result 2= " + res2 + "\r\n" + "Result 3= " + res3 + "\r\n");
        }

        public void Second(ref double[,] A2, ref double rasr, ref int r, ref int s)
        {
            while (s != n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i != r) && (j != s))
                            A2[i, j] = Save2[i, j] - (Save2[i, s] * Save2[r, j]) / Save2[r, s];
                        if (j == s)
                            A2[i, j] = Save2[i, j] / rasr;
                        if (i == r)
                            A2[i, j] = Save2[i, j] / (-rasr);
                    }
                }
                A2[r, s] = 1 / rasr;
                SaveMatrix2(ref A2);
                r++; s++;
                if (r == n)
                    break;
                rasr = A2[r, s];
            }
            double res21 = A2[0, 3];
            double res22 = A2[1, 3];
            double res23 = A2[2, 3];
            textBox2.AppendText("Result 1_sec= " + res21 + "\r\n" + "Result 2_sec= " + res22 + "\r\n" + "Result 3_sec= " + res23 + "\r\n");
        }
        //сохраняем матрицы для работы с текущей и предыдущей
        public void SaveMatrix(ref double[,] M)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Save[i, j] = M[i, j];
                }
            }
        }
        public void SaveMatrix2(ref double[,] M)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Save2[i, j] = M[i, j];
                }
            }
        }


        private void btn_DoIt_Click(object sender, EventArgs e)
        {
            double rasr = A[r, s];
            //считаем по первому методу
            First(ref A, ref rasr, ref r, ref s);
            r = 0; s = 0;
            rasr = A2[r, s];
            //считаем по второму методу
            Second(ref A2, ref rasr, ref r, ref s);

        }
    }
}
