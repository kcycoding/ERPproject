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

namespace project4_ERP.ProductionDepartment_cs
{
    public partial class production_calinder : UserControl
    {
        public string date;
        public production_calinder()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.SelectionRange.Start == monthCalendar1.SelectionRange.End)
            {
                textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                if (File.Exists($"C:\\ERP4\\ProductionDepartment\\{date}.txt"))
                {
                    textBox2.Clear(); // 다른날짜 클릭시 
                    StreamReader sr = new StreamReader($"C:\\ERP4\\ProductionDepartment\\{date}.txt");
                    textBox2.Text = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                }
                else
                {
                    textBox2.Clear();
                    //MessageBox.Show("해당날짜에는 일정이 없습니다.");
                }
            }


            else
            {
                textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd") + "~" + monthCalendar1.SelectionRange.End.ToString("yyyy-MM-dd");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            date = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists($"C:\\ERP4\\ProductionDepartment\\{date}.txt"))
            {
                File.Delete($"C:\\ERP4\\ProductionDepartment\\{date}.txt");
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("해당날짜 파일을 찾을수 없습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\ERP4\\ProductionDepartment"))
            {
                StreamWriter sw = new StreamWriter($"C:\\ERP4\\ProductionDepartment\\{date}.txt");
                // sw.WriteLine(date);
                sw.WriteLine(textBox2.Text);
                sw.Close();
                sw.Dispose();
            }
            else
            {
                DirectoryInfo personnel = new DirectoryInfo("C:\\ERP4\\ProductionDepartment");
                personnel.Create();
            }
        }
    }
}
