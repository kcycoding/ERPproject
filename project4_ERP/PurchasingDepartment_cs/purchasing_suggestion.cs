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

namespace project4_ERP.PurchasingDepartment_cs
{
    public partial class purchasing_suggestion : UserControl
    {
        public purchasing_suggestion()
        {
            InitializeComponent();
        }

        public string suggestion;
        public string sugg_condition;
        private static string suggestion_ad = "suggestion_ad.txt";
        private static string file_path = @"C:\\ERP4\\PersonnelDepartment\\" + suggestion_ad;
        private static string title;
        private static string department;
        DateTime date_write = DateTime.Now;
        private static string content;
        private static string writer;
        public string processing_status;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            suggestion = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sugg_condition = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            dataGridView1.Rows.Clear();
            foreach (var line in lines)
            {
                string[] number = line.Split(',');
                if (sugg_condition == "제목")
                {
                    if (suggestion == number[0])
                    {

                        dataGridView1.Rows.Add(number);

                    }
                }
                else if (sugg_condition == "작성부서")
                {
                    if (suggestion == number[1])
                    {

                        dataGridView1.Rows.Add(number);

                    }
                }
                else if (sugg_condition == "등록일자")
                {
                    if (suggestion == number[2])
                    {

                        dataGridView1.Rows.Add(number);

                    }
                }
                else if (sugg_condition == "처리상태")
                {
                    if (suggestion == number[3])
                    {

                        dataGridView1.Rows.Add(number);

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            dataGridView1.Rows.Clear();
            foreach (var line in lines)
            {
                string[] number = line.Split(',');
                if (number[4] == textBox2.Text)
                {
                    string[] getdata = line.Split(',');
                    dataGridView1.Rows.Add(getdata);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            panel3.Visible = true;
            panel3.Location = new Point(52, 26);
            panel3.Size = new Size(459, 385);

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            button7.Visible = false;

            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // 제목
            
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // 내용
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // 작성자
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // 처리상태
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
                List<string> list = new List<string>(); // 리스트하나 만들기
                int selectedRowCount = dataGridView1.SelectedRows.Count;
                DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
                int index = selectedRows[0].Index;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    dataGridView1.Rows.Remove(selectedRows[i]);
                }
                foreach (string line in lines)
                {
                    list.Add(line);
                }
                list.RemoveAt(index); // i번째 줄 삭제
                StreamWriter sw = new StreamWriter(file_path);
                for (int j = 0; j < list.Count; j++)
                {
                    sw.WriteLine(list[j].ToArray());
                }
                sw.Close();
                sw.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("삭제할 내용을 설정하지 않았습니다.", "오류");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox5.Clear();
            panel3.Visible = true;
            panel3.Location = new Point(52, 26);
            panel3.Size = new Size(459, 385);

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = false; 
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = true;
            button7.Visible = true;
        }

        public void ExportToCSV() // 저장파일을 고정위치에 넣어 파일을 저장하는 소스코드
        {

            SaveFileDialog saveFileDialog = GetCsvSave();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Save_csv(saveFileDialog.FileName, dataGridView1, true); // dataGridView의 데이터를 텍스트저장하는 메서드를 호출
            }


        } // 버튼 생성 및 버튼기능 코드


        private SaveFileDialog GetCsvSave() // 저장위치찾는 다이얼로그를 열어서 저장 하는 기능
        {

            //Getting the location and file name of the excel to save from user.
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.CheckPathExists = true;
            saveDialog.AddExtension = true;
            saveDialog.ValidateNames = true;

            string path = file_path;
            string filepath = Path.GetDirectoryName(path);


            saveDialog.InitialDirectory = filepath;// Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            saveDialog.DefaultExt = ".txt";
            saveDialog.Filter = "txt (*.txt) | *.txt";
            saveDialog.FileName = "suggestion_ad.txt".ToString();

            return saveDialog;
        } // 다이얼로그 기본 정의


        private void Save_csv(string fileName, DataGridView dgview, bool header) // 그리드뷰의 내용을 텍스트로 옮겨 적는 코드
        {
            string delimiter = ",";  // 구분자
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8); //UTF8로 엔코딩

            if (dgview.Rows.Count == 0) return;
            // 데이터 출력
            foreach (DataGridViewRow row in dgview.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgview.Columns.Count; i++)
                    {
                        csvExport.Write(row.Cells[i].Value);
                        if (i != dgview.Columns.Count - 1)
                        {
                            csvExport.Write(delimiter);
                        }
                    }
                    csvExport.Write(csvExport.NewLine); // write new line
                }
            }

            csvExport.Flush();
            csvExport.Close();

            fs.Close();

            MessageBox.Show("txt 파일 저장 완료！");
        } // 저장버튼

        private void Save_csv4(string aaa, DataGridView dgview, bool header) // 그리드뷰의 내용을 신규추가로 텍스트로 옮겨 적는 코드
        {   // 매개변수로 (폴더의위치, 그리드뷰, 불값을 true로 넣기)
            string delimiter = ",";
            List<string> list = new List<string>();
            string[] lines = File.ReadAllLines(aaa, Encoding.UTF8);
            foreach (string line in lines)
            {
                list.Add(line);
            }
            if (dgview.Rows.Count == 0) return;
            List<string> demo = new List<string>();
            foreach (DataGridViewRow row in dgview.Rows)
            {
                demo.Clear();
                string[] demo2 = new string[1];
                if (!row.IsNewRow)
                {
                    //if (dgview.Rows[dgview.Rows.Count - 2].ToString() == row.ToString())
                    //{
                    MessageBox.Show("11");
                    for (int i = 0; i < dgview.Columns.Count; i++)
                    {
                        demo.Add(Convert.ToString(row.Cells[i].Value));

                        if (i != dgview.Columns.Count - 1)
                        {
                            demo.Add(delimiter);
                        }
                    }
                    //}

                }
                demo2 = demo.ToArray();
                list.Add(string.Join("", demo2));
            }
            list.RemoveAt(list.Count - 1); // 리스트의 마지막 인덱스가 띄어 쓰기 이기 때문에 삭제 하는 코드
            List<string> list2 = list.Distinct().ToList();
            StreamWriter sw = new StreamWriter(aaa); // 해당 위치 텍스트에 리스트내용을 넣는 코드 
            for (int j = 0; j < list2.Count; j++)
            {
                sw.WriteLine(list2[j].ToArray());
            }
            sw.Close();
            sw.Dispose();
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            writer = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            title = textBox3.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            processing_status = textBox6.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            content = textBox5.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(title, "구매부", date_write.ToString("yyyy-MM-dd"), content, writer, "미처리");
            if (File.Exists(file_path))
            {
                // 파일이 있다면 그파일에 그리드 뷰의 내용만 넣기
                Save_csv4(file_path, dataGridView1, true);
            }
            else
            {
                ExportToCSV();
            }
            panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void purchasing_suggestion_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form6.ID.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            department = label1.Text;
        }
    }
}
