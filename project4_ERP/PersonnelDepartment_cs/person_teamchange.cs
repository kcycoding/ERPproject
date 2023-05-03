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

namespace project4_ERP.PersonnelDepartment_cs
{
    public partial class person_teamchange : UserControl
    {
        private static string user_name = "worker_member.txt";
        private static string file_path = @"C:\\ERP4\\PersonnelDepartment\\" + user_name;
        private static string folder = "div_pos_move_member.txt";
        private static string file_path2 = @"C:\\ERP4\\PersonnelDepartment\\" + folder;
        public string seach_name;
        public string seach_condition;
        public person_teamchange()
        {
            InitializeComponent();
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
            saveDialog.FileName = "div_pos_move_member.txt".ToString();

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
                    for (int i = 0; i < dgview.Columns.Count; i++)
                    {
                        demo.Add(Convert.ToString(row.Cells[i].Value));

                        if (i != dgview.Columns.Count - 1)
                        {
                            demo.Add(delimiter);
                        }
                    }
                }
                demo2 = demo.ToArray();
                list.Add(string.Join("", demo2));
            }

            list.RemoveAt(list.Count - 1); // 리스트의 마지막 인덱스가 띄어 쓰기 이기 때문에 삭제 하는 코드
            StreamWriter sw = new StreamWriter(aaa); // 해당 위치 텍스트에 리스트내용을 넣는 코드 
            for (int j = 0; j < list.Count; j++)
            {
                sw.WriteLine(list[j].ToArray());
            }
            sw.Close();
            sw.Dispose();
        }

       

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            seach_name = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            seach_condition = comboBox1.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            string[] liness = File.ReadAllLines(file_path2, Encoding.UTF8);
            DateTime dateTime = DateTime.Now;
            dataGridView1.Rows.Clear();
            foreach (var line in lines)
            {
                string[] number = line.Split(',');
                if (seach_condition == "사번")
                {
                    if (seach_name == number[0])
                    {

                        dataGridView1.Rows.Add(number[0], number[1], dateTime, number[3], "", number[2]);

                    }
                }
                else if (seach_condition == "이름")
                {
                    if (seach_name == number[1])
                    {

                        dataGridView1.Rows.Add(number[0], number[1], dateTime, number[3], "", number[2]);

                    }
                }
                else if (seach_condition == "이전부서")
                {
                    if (seach_name == number[2])
                    {

                        dataGridView1.Rows.Add(number[0], number[1], dateTime, number[3], "", number[2]);

                    }
                }
                else if (seach_condition == "이전직위")
                {
                    if (seach_name == number[3])
                    {

                        dataGridView1.Rows.Add(number[0], number[1], dateTime, number[3], "", number[2]);

                    }
                }
            }
            foreach (var line in liness)
            {
                string[] number = line.Split(',');
                if (seach_condition == "발령일자")
                {
                    if (seach_name == number[2])
                    {
                        dataGridView1.Rows.Add(number);
                    }
                }
                else if (seach_condition == "발령직위")
                {
                    if (seach_name == number[4])
                    {
                        dataGridView1.Rows.Add(number);
                    }
                }
                else if (seach_condition == "발령부서")
                {
                    if (seach_name == number[6])
                    {
                        dataGridView1.Rows.Add(number);
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (file_path== null)
            {
                MessageBox.Show("파일에 아무내용이 없습니다.");
            }
            else
            {
                string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
                dataGridView1.Rows.Clear();
                DateTime dateTime = DateTime.Now;
                foreach (var line in lines)
                {

                    string[] getdata = line.Split(',');
                    dataGridView1.Rows.Add(getdata[0], getdata[1], dateTime.ToString("yyyy/M/d"), getdata[3], "", getdata[2]);
                }
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            List<string> list = new List<string>(); // 리스트하나 만들기
            int selectedRowCount = dataGridView1.SelectedRows.Count;
            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            int index = selectedRows[0].Index;

            for (int i = 0; i < selectedRowCount; i++)
            {
                dataGridView1.Rows.Remove(selectedRows[i]); // 표에서 선택된 행 삭제
            }
            foreach (string line in lines)
            {
                list.Add(line);
                //if (line == changerow = Convert.string.selectedRows[0])
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(file_path)&& File.Exists(file_path2))
            {
                if (MessageBox.Show("선택하신 정보가 저장됩니다", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save_csv4(file_path2, dataGridView1, true);
                    MessageBox.Show("csv4");
                    change_string();
                    MessageBox.Show("change_string");

                    // text파일 내용만 가져와서 인덱스를 바꾸는 코드
                }
            }
            else
            {
                MessageBox.Show("선택하신 정보가 저장됩니다", "알림", MessageBoxButtons.YesNo);
                ExportToCSV();
                change_string();

                // text파일 내용만 가져와서 인덱스를 바꾸는 코드
            }
        }       

        private void change_string()
        {
            List<string> finellist = new List<string>();
            string[] line = File.ReadAllLines(file_path, Encoding.UTF8); // 파일패스에 인사부 부서변경 파일주소 넣기
            string[] line2 = File.ReadAllLines(file_path2, Encoding.UTF8); // 파일패스2에 사원정보 파일주소 넣기
            List<string> list = new List<string>(line);//인사부 리스트 담기
            List<string> list2 = new List<string>(line2);//부서이동 리스트 담기
            for (int i = 0; i < list.Count; i++)
            {
                string[] menu = list[i].Split(',');
                for (int k = 0; k < list2.Count; k++)
                {
                    string[] menu2 = list2[k].Split(',');
                    if (menu[0] == menu2[0])
                    {
                        if (menu2[4] != menu[3] && menu2[4] != "")
                        {
                            menu[3] = menu2[4];
                        }
                        if (menu2[6] != menu[2] && menu2[6] != "")
                        {
                            menu[2] = menu2[6];
                        }
                        list[i] = "";
                        for (int j = 0; j < menu.Length; j++)
                        {
                            
                            if (i != menu.Length - 2)
                            {
                               
                                list[i] = list[i] + menu[j] + ",";
                            }
                            else
                            {
                               
                                list[i] = list[i] + menu[j];
                            }
                        }
                    }               
                }

                
                StreamWriter sw = new StreamWriter(file_path); // 폴더 여는 위치를 인사사원정보위치로 지정
                foreach (string j in list)
                {
                    sw.WriteLine(j);
                }
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
