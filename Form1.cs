using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp39
{
    public partial class Form1 : Form
    {
        private Tmatr matrix;
        public Form1()
        {
            InitializeComponent();
        }
        class Tmatr
        {
            private int[,] matrix;  // матриця
            private int numRows;    // кількість рядків
            private int numCols;    // кількість стовпців

            // Конструктор класу
            public Tmatr(int numRows, int numCols)
            {
                this.numRows = numRows;
                this.numCols = numCols;
                matrix = new int[numRows, numCols];
            }

            // Метод для зміни розмірів матриці
            public void Resize(int numRows, int numCols)
            {
                // Збереження вмісту, якщо можливо
                int[,] tempMatrix = matrix;
                matrix = new int[numRows, numCols];

                // Копіювання елементів в нову матрицю
                for (int i = 0; i < Math.Min(numRows, this.numRows); i++)
                {
                    for (int j = 0; j < Math.Min(numCols, this.numCols); j++)
                    {
                        matrix[i, j] = tempMatrix[i, j];
                    }
                }

                this.numRows = numRows;
                this.numCols = numCols;
            }

            // Метод для отримання елементу матриці
            public int GetElement(int row, int col)
            {
                return matrix[row, col];
            }

            // Метод для задання елементу матриці
            public void SetElement(int row, int col, int value)
            {
                matrix[row, col] = value;
            }

            // Метод для виведення матриці на екран
            public void Print()
            {
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            // Метод для виведення підматриці на екран
            public void PrintSubmatrix(int startRow, int startCol, int numRows, int numCols)
            {
                for (int i = startRow; i < startRow + numRows; i++)
                {
                    for (int j = startCol; j < startCol + numCols; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int numRows = Convert.ToInt32(textBox1.Text);
            int numCols = Convert.ToInt32(textBox2.Text);
            matrix = new Tmatr(numRows, numCols);
            textBox3.Text = "Матриця створена";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numRows = Convert.ToInt32(textBox1.Text);
            int numCols = Convert.ToInt32(textBox2.Text);
            matrix.Resize(numRows, numCols);
            textBox3.Text = "Розмір матриці змінено";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(textBox4.Text);
            int col = Convert.ToInt32(textBox5.Text);
            int value = matrix.GetElement(row, col);
            textBox3.Text = "Елемент отримано";
            textBox6.Text = value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(textBox4.Text);
            int col = Convert.ToInt32(textBox5.Text);
            int value = Convert.ToInt32(textBox6.Text);
            matrix.SetElement(row, col, value);
            textBox3.Text = "Елемент змінено";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            matrix.Print();
            textBox3.Text = "Матриця виведена на екран";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int startRow = Convert.ToInt32(textBox7.Text);
            int startCol = Convert.ToInt32(textBox8.Text);
            int numRows = Convert.ToInt32(textBox7.Text);
            int numCols = Convert.ToInt32(textBox8.Text);
            matrix.PrintSubmatrix(startRow, startCol, numRows, numCols);
            textBox3.Text = "Підматриця виведена на екран";
        }
    }
}
