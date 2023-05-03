using project4_ERP.ProductionDepartment_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.WebRequestMethods;

namespace project4_ERP
{
    public partial class Form3 : Form
    {
        QualityDepartment_cs.quality_calinder Quality_calinder = new QualityDepartment_cs.quality_calinder();
        QualityDepartment_cs.quality_reports Quality_Report = new QualityDepartment_cs.quality_reports();
        QualityDepartment_cs.lot_report Lot_report = new QualityDepartment_cs.lot_report();
        QualityDepartment_cs.imported_inspection Imported_inspection = new QualityDepartment_cs.imported_inspection();
        QualityDepartment_cs.quality_suggestion Quality_suggestion = new QualityDepartment_cs.quality_suggestion();

        public delegate void login_frame();
        public event login_frame lf;
        public Form3()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel2.Controls.Add(Quality_calinder);
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
            panel2.Controls.Add(Quality_calinder);
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Imported_inspection);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.DimGray;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Lot_report);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.DimGray;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Quality_Report);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.DimGray;
            button5.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.Black;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(Quality_suggestion);
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.DimGray;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.White;
        }

        private static string user_log = "login_logout.txt";
        private static string log = @"C:\ERP4\PersonnelDepartment\\" + user_log;
        public static int work_time_H;
        public static int work_time_M;
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                a = 0;
                DateTime log_time = DateTime.Now;
                //Form6 form1 = new Form6();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Location = new Point(795, 1);
        }

        private void button8_Click(object sender, EventArgs e)
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
    }
}
