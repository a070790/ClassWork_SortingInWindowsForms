using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shell_and_Bubble_Sorting
{
    public partial class SortingForm : Form
    {
        private int[] intArray;
        private Boolean markInsertionSort;
        private Boolean markBubbleSort;
        private Boolean markShellSort;
        private Boolean markQuickSort;
        private Boolean markMergeSort;

        public SortingForm()
        {
            InitializeComponent();

            markInsertionSort = false;
            markBubbleSort = false;
            markShellSort = false;
            markQuickSort = false;

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            radioButton1.Click += RadioButton1_Click;
            radioButton2.Click += RadioButton2_Click;
            radioButton3.Click += RadioButton3_Click;
            radioButton4.Click += RadioButton4_Click;
            radioButton5.Click += RadioButton5_Click;
        }

        // Событие - создание файла input.txt с записью значений массива, заполненного рандомно
        private void Button1_Click(object sender, EventArgs e)
        {
            CreateCustomArrayInTxtFile(20, 100);
        }

        // Событие - чтение файла input.txt
        private void Button2_Click(object sender, EventArgs e)
        {
            intArray = ReadFile();
        }

        // Событие - сортировка массива установленным методом
        private void Button3_Click(object sender, EventArgs e)
        {
            SortingHandler sortingHandler = new SortingHandler();

            if (markInsertionSort)
            {
                intArray = ReadFile();
                textBox2.Text = sortingHandler.InsertionSort(intArray, intArray.Length);
            }
            if (markBubbleSort)
            {
                intArray = ReadFile();
                textBox2.Text = sortingHandler.BubbleSort(intArray);
            }
            if (markShellSort)
            {
                intArray = ReadFile();
                textBox2.Text = sortingHandler.ShellSort(intArray);
            }
            if (markQuickSort)
            {
                intArray = ReadFile();
                textBox2.Text = sortingHandler.QuickSorting(intArray, 0, intArray.Length-1);
            }
            if (markMergeSort)
            {
                intArray = ReadFile();
                textBox2.Text = sortingHandler.MergeSort(intArray);
            }
        }

        // Событие - удаление файла input.txt и каталога, содержащего файл input.txt, из памяти
        private void Button4_Click(object sender, EventArgs e)
        {
            File.Delete("C:\\ClassWork\\input.txt");
            Directory.Delete("C:\\ClassWork");
        }

        // Событие - установлен метод сортировки вставками
        private void RadioButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            markBubbleSort = false;
            markShellSort = false;
            markQuickSort = false;
            markInsertionSort = true;
        }

        // Событие - установлен метод сортировки пузырьком
        private void RadioButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            markInsertionSort = false;
            markShellSort = false;
            markQuickSort = false;
            markMergeSort = false;
            markBubbleSort = true;
        }

        // Событие - установлен метод сортировки Шелла
        private void RadioButton3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            markInsertionSort = false;
            markBubbleSort = false;
            markQuickSort = false;
            markMergeSort = false;
            markShellSort = true; 
        }

        // Событие - установлен метод быстрой сортировки
        private void RadioButton4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            markInsertionSort = false;
            markBubbleSort = false;
            markShellSort = false;
            markMergeSort = false;
            markQuickSort = true;
        }

        // Событие - установлен метод сортировки слиянием
        private void RadioButton5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            markInsertionSort = false;
            markBubbleSort = false;
            markShellSort = false;
            markQuickSort = false;
            markMergeSort = true;
        }

        public static void CreateCustomArrayInTxtFile(int ArraySize, int MaxValue)
        {
            Random rand = new Random();

            Directory.CreateDirectory("C:\\ClassWork");
            String WritePath = @"C:\ClassWork\input.txt";
            System.IO.StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default);

            String Text = "";
            for (int i = 0; i < ArraySize; i++)
            {
                String spase = i == (ArraySize - 1) ? "" : " ";
                Text = Text + rand.Next(MaxValue).ToString() + spase;
            }

            sw.WriteLine(Text);

            sw.Close();
        }

        public int[] ReadFile()
        {
            string file = @"C:\ClassWork\input.txt";
            System.IO.StreamReader fw = new StreamReader(file);
            textBox1.Text = fw.ReadLine();

            fw.Close();

            string[] strArray = new string[20];
            int j = 0, startIndex, endIndex = -1, numLength = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                startIndex = ++endIndex;
                while ((endIndex < textBox1.Text.Length) && (textBox1.Text[endIndex] != ' '))
                {
                    ++endIndex;
                }
                numLength = endIndex - startIndex;
                strArray[i] = textBox1.Text.Substring(startIndex, numLength);
                numLength = 0;
            }

            int[] intArray = new int[20];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = Int32.Parse(strArray[i]);
            }

            return intArray;
        }
    }
}
