using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = this.Decrypt(textBox1.Text, Int32.Parse(textBox3.Text));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = this.Encrypt(textBox1.Text, Int32.Parse(textBox3.Text));
        }

        public string Encrypt(string encryptString, int key)
        {
            char[] ArrayChar = encryptString.ToCharArray();
            long[] ArrayLong = new long[ArrayChar.Length];
            char[] ArrayCharNew = new char[ArrayChar.Length];
            for (int i = 0; i < ArrayChar.Length; i++)
            {
                ArrayLong[i] = ArrayChar[i] + key;
                ArrayCharNew[i] = (char)ArrayLong[i];
            }
            encryptString = new String(ArrayCharNew);
            return encryptString;
        }

        public string Decrypt(string decryptString, int key)
        {
            char[] ArrayChar = decryptString.ToCharArray();
            long[] ArrayLong = new long[ArrayChar.Length];
            char[] ArrayCharNew = new char[ArrayChar.Length];
            
            for (int i = 0; i < ArrayChar.Length; i++)
            {
                ArrayLong[i] = ArrayChar[i] - key;
                ArrayCharNew[i] = (char)ArrayLong[i];
            }
            decryptString = new String(ArrayCharNew);
            
            return decryptString;
        }
    }
}
