using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project4_ERP
{
    public partial class Form7 : Form
    {

        public delegate void login_frame();
        public event login_frame lf;

        const int STEP_SLIDING = 80;
        int _posSliding = 200;
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 50;
        public Form7()
        {
            InitializeComponent();
        }
        Form1 form1 = new Form1();
        Form2 form2 = new Form2();
        Form3 Form3 = new Form3();
        Form4 Form4 = new Form4();
        

        private void button1_Click(object sender, EventArgs e)//인사부
        {
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.DimGray;
            button3.BackColor = Color.DimGray;
            button4.BackColor = Color.DimGray;
            
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            
            panel2.Controls.Clear();
            form2.a = 0;
            Form4.a = 0;
            Form3.a = 0;
            form1.button7.Visible = false;
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            panel2.Controls.Add(form1);
            form1.FormBorderStyle= FormBorderStyle.None;
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)//생산부
        {
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.DimGray;
            button4.BackColor = Color.DimGray;
            
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            
            panel2.Controls.Clear();
            form2.a = 0;
            Form4.a = 0;
            Form3.a = 0;
            form2.button7.Visible = false;
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            panel2.Controls.Add(form2);
            form2.FormBorderStyle= FormBorderStyle.None;
            form2.Show();
        }
        

        private void button4_Click_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.DimGray;
            button3.BackColor = Color.DimGray;
            button4.BackColor = Color.Gainsboro;
            
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.Black;
            
            panel2.Controls.Clear();
            form2.a = 0;
            Form4.a = 0;
            Form3.a = 0;
            Form4.TopLevel = false;
            Form4.button8.Visible = false;
            Form4.Dock = DockStyle.Fill;
            panel2.Controls.Add(Form4);
            Form4.FormBorderStyle = FormBorderStyle.None;
            Form4.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.DimGray;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.DimGray;
            
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.White;
            
            panel2.Controls.Clear();
            form2.a = 0;
            Form4.a = 0;
            Form3.a = 0;
            Form3.TopLevel = false;
            Form3.button6.Visible = false;
            Form3.Dock = DockStyle.Fill;
            panel2.Controls.Add(Form3);
            Form3.FormBorderStyle = FormBorderStyle.None;
            Form3.Show();
        }
                

        private void button6_Click_1(object sender, EventArgs e)//종료
        {
            try
            {
                
                lf();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

       
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //슬라이딩 메뉴가 접혔을 때, 메뉴 버튼의 표시
                checkBox1.Text = ">";
                panel2.Size = new Size(1240, 70);
            }
            else
            {
                //슬라이딩 메뉴가 보였을 때, 메뉴 버튼의 표시
                checkBox1.Text = "<";
                panel2.Size = new Size(1103, 661);
            }

            //타이머 시작
            timer1.Start();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //슬라이딩 메뉴를 숨기는 동작
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    timer1.Stop();
            }
            else
            {
                //슬라이딩 메뉴를 보이는 동작
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    timer1.Stop();
            }

            panel1.Width = _posSliding;
        }
    }
}
