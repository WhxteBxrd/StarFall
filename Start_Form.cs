using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starfall_Screensaver_Win98_
{
    public partial class Start_Form : Form
    {
        public Start_Form()
        {
            InitializeComponent();
        }

        private void Start_Form_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 form1 = new Form1();

            form1.PeredanSpeed = this._MyTextBox.Text;

            form1.Show();            
        }

        //Подписка на TextBox, событие KeyPress 
        private void _MyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar; //Для хранения нажатой клаваши

            //Если нажата клав. с буквой, ввод запрещён
            //Искл. только для Backspace!!!
            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true; 
            }
        }
    }
}
