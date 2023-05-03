using project4_ERP.PersonnelDepartment_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace project4_ERP
{
    public partial class Form1 : Form
    {
        PersonnelDepartment_cs.person_calinder Calinder = new PersonnelDepartment_cs.person_calinder();
        PersonnelDepartment_cs.person_add_del Person_add_del = new PersonnelDepartment_cs.person_add_del();
        PersonnelDepartment_cs.person_pay Person_pay = new PersonnelDepartment_cs.person_pay();
        PersonnelDepartment_cs.person_teamchange Person_teamchange = new PersonnelDepartment_cs.person_teamchange();
        PersonnelDepartment_cs.person_suggestion Person_suggestion = new PersonnelDepartment_cs.person_suggestion();
        PersonnelDepartment_cs.person_management Person_management = new PersonnelDepartment_cs.person_management();


        public delegate void login_frame();
        public event login_frame lf;
        

        public Form1()
        {
            InitializeComponent();
            //label3.Visible = false;
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Calinder);
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Person_add_del);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.DimGray;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Person_teamchange);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.DimGray;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Person_management);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.DimGray;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            panel2.Controls.Add(Person_pay);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.DimGray;
            button6.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.White;
            button6.ForeColor = Color.Black;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Person_suggestion);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.DimGray;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.White;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            panel2.Controls.Add(Calinder);

        }

        private static string found = "11111.txt"; //텍스트 파일 제목
        private static string files = @"c:\ERP4\Sign\\" + found; //텍스트 파일 주소
        private static string check = "";

       private static string user_log = "login_logout.txt";
        private static string log = @"C:\ERP4\PersonnelDepartment\\" + user_log;
        public static int work_time_H;
        public static int work_time_M;

        
        
        private void button7_Click(object sender, EventArgs e) // 로그인으로 가는 X버튼
        {
            
            try
            {

                DateTime log_time = DateTime.Now;                
                string go_work_time = Form6.go_to_work_time;//로그인시간
                
                StreamWriter writer = File.AppendText(log);
                TimeSpan work_time = Convert.ToDateTime(log_time) - Convert.ToDateTime(go_work_time);
                work_time_H = work_time.Hours;
                work_time_M = work_time.Minutes;
                writer.WriteLine("{0},{1}시{2}분\n", log_time.ToString("yyyy-MM-dd H:mm"), work_time_H, work_time_M);
                writer.Close();
                writer.Dispose();               
                this.Close();               
                lf();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Location = new Point(795, 1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }


        private void Form1_FontChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                int size = (int)c.Font.Size;
                c.Font = new Font("Microsoft Sans Serif", --size);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                int size = (int)c.Font.Size;
                c.Font = new Font("Microsoft Sans Serif", ++size);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fontDialog1.ShowDialog(this))
            {
                panel2.Font = fontDialog1.Font;
            }
        }
    }
}
