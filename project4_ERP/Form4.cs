using project4_ERP.QualityDepartment_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project4_ERP
{
    public partial class Form4 : Form
    {
        PurchasingDepartment_cs.purchasing_calinder Purchasing_calinder = new PurchasingDepartment_cs.purchasing_calinder();
        PurchasingDepartment_cs.purchased_add Purchased_Add = new PurchasingDepartment_cs.purchased_add();
        PurchasingDepartment_cs.purchasing_report Purchasing_Report = new PurchasingDepartment_cs.purchasing_report();
        PurchasingDepartment_cs.purchasing_suggestion Purchasing_Suggestion = new PurchasingDepartment_cs.purchasing_suggestion();
        PurchasingDepartment_cs.purchasing_inventory_status Purchasing_inventory_status = new PurchasingDepartment_cs.purchasing_inventory_status();

        public delegate void login_frame();
        public event login_frame lf;

        public Form4()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }        

       

        private void Form4_Load(object sender, EventArgs e)
        {
            panel2.Controls.Add(Purchasing_calinder);
            var start = new Thread(new ThreadStart(File_Check));
            start.Start();
        }

        private static string found = "quality_report.txt"; //텍스트 파일 제목
        private static string files = @"C:\\ERP4\\QualityDepartment\\" + found; //텍스트 파일 주소

        private static string check = "";
        //private static string check2 = "";
        public int a = 1;
        private void File_Check()
        {
            var file = new FileInfo(files); //파일 확인
            check = file.LastWriteTime.ToString(); //파일 마지막 수정시간(저장값) 

            //var file2 = new FileInfo(files2);
            //check2 = file2.LastWriteTime.ToString();

            while (a == 1)
            {
                try
                {
                    file = new FileInfo(files);  //파일 확인
                    label2.Text = file.LastWriteTime.ToString(); // 파일 마지막 수정시간(갱신)

                    //file2 = new FileInfo(files2);
                    //label3.Text = file2.LastWriteTime.ToString();

                    if (check.ToString() != label2.Text)
                    {
                        check = label2.Text;
                        ShowTime();   //크로스 에러 방지 메소드
                    }
                    //if (check2.ToString() != label3.Text)
                    //{
                    //    check2 = label3.Text;
                    //    ShowTime();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }

        }


        private void ShowTime()
        {
            // Don't do anything if the form's handle hasn't been created 
            // or the form has been disposed.
            if (!this.IsHandleCreated || this.IsDisposed) return;

            // Invoke an anonymous method on the thread of the form.
            this.Invoke((MethodInvoker)delegate
            {
                this.pictureBox1.Visible = true;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Purchasing_calinder);
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button9.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button9.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Purchased_Add);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.DimGray;
            button6.BackColor = Color.Gainsboro;
            button9.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.White;
            button6.ForeColor = Color.Black;
            button9.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
        }
                

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Purchasing_Report);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button6.BackColor = Color.DimGray;
            button9.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button6.ForeColor = Color.White;
            button9.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
        }

        private void button9_Click(object sender, EventArgs e) // 구매부 재고현황
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Purchasing_inventory_status);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button9.BackColor = Color.DimGray;
            button7.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button9.ForeColor = Color.White;
            button7.ForeColor = Color.Black;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Purchasing_Suggestion);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button9.BackColor = Color.Gainsboro;
            button7.BackColor = Color.DimGray;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button9.ForeColor = Color.Black;
            button7.ForeColor = Color.White;
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private static string user_log = "login_logout.txt";
        private static string log = @"C:\ERP4\PersonnelDepartment\\" + user_log;
        public static int work_time_H;
        public static int work_time_M;

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                a = 0;
                DateTime log_time = DateTime.Now;
                Form6 form1 = new Form6();
                string userID = Form6.ID;
                string go_work_time = Form6.go_to_work_time;//로그인시간
                
                StreamWriter writer = File.AppendText(log);
                TimeSpan work_time = Convert.ToDateTime(log_time) - Convert.ToDateTime(go_work_time);
                work_time_H = work_time.Hours;
                work_time_M = work_time.Minutes;
                writer.WriteLine("{0},{1}시{2}분\n", log_time.ToString("yyyy-MM-dd H:mm"), work_time_H, work_time_M);
                writer.Close();
                writer.Dispose();
                lf();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Location = new Point(795, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fontDialog1.ShowDialog(this))
            {
                panel2.Font = fontDialog1.Font;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
