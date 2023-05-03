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
    public partial class person_pay : UserControl
    {
        private static string user_name = "worker_member.txt";
        private static string file_path = "c:\\ERP4\\PersonnelDepartment\\" + user_name;
        private static string user_name2 = "money_account.txt";
        private static string file_path2 = "c:\\ERP4\\PersonnelDepartment\\" + user_name2;

        public string search_name;
        public string search_condition;
        public person_pay()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) // 삭제 코드
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

        private void button5_Click(object sender, EventArgs e) // 저장
        {
            if (MessageBox.Show("선택하신 정보가 저장됩니다", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExportToCSV();
                // text파일 내용만 가져와서 인덱스를 바꾸는 코드
            }
        }

        private void button6_Click(object sender, EventArgs e) // 추가
        {
            if (File.Exists(file_path) && File.Exists(file_path))
            {
                Save_csv4(file_path, dataGridView1, true); // 파일이 있다면 그파일에 그리드 뷰의 내용만 넣기
                //Save_csv4(file_path2, dataGridView1, true); // 품질부도 같은 내용의 신규 내용을 넣기
                MessageBox.Show("11");
            }
            else
            {
                ExportToCSV();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search_name = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            search_condition = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)// 검색 버튼
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            dataGridView1.Rows.Clear();
            foreach (var line in lines)
            {
                string[] number = line.Split(',');
                if (search_condition == "사번")
                {
                    if (search_name == number[0])
                    {
                        dataGridView1.Rows.Add(number[0], number[1], "", number[3], number[2], "", number[5]);
                    }
                }
                else if (search_condition == "이름")
                {
                    if (search_name == number[1])
                    {
                        dataGridView1.Rows.Add(number[0], number[1], "", number[3], number[2], "", number[5]);
                    }
                }
                else if (search_condition == "직책")
                {
                    if (search_name == number[3])
                    {
                        dataGridView1.Rows.Add(number[0], number[1], "", number[3], number[2], "", number[5]);
                    }
                }
                else if (search_condition == "부서")
                {
                    if (search_name == number[2])
                    {
                        dataGridView1.Rows.Add(number[0], number[1], "", number[3], number[2], "", number[5]);
                    }
                }
                else if (search_condition == "입사일")
                {
                    if (search_name == number[5])
                    {
                        dataGridView1.Rows.Add(number[0], number[1], "", number[3], number[2], "", number[5]);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // 새로고침
        {
            try
            {
                bool key = true;
                while (key)
                {
                    //MessageBox.Show("111");
                    if (File.Exists(file_path) && File.Exists(file_path2))
                    {
                        //MessageBox.Show("222");
                        string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);//사원 멤버 텍스트 불러오기
                        string[] m = File.ReadAllLines(file_path2, Encoding.UTF8);//계좌 텍스트 파일 불러오기
                        dataGridView1.Rows.Clear();
                        foreach (var M in m)
                        {
                            //MessageBox.Show("333");
                            string[] mon = M.Split(',');//char
                            foreach (var line in lines)
                            {
                                string[] getdata = line.Split(',');
                                if (getdata[0] == mon[0])
                                {
                                    //MessageBox.Show("555");
                                    dataGridView1.Rows.Add(getdata[0], getdata[1], mon[2], getdata[3], getdata[2], mon[5], getdata[5]);
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        //MessageBox.Show("666");
                        if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\worker_member.txt"))
                        {
                            //MessageBox.Show("666-1");
                            File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\worker_member.txt", null);
                        }
                        if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\money_account.txt"))
                        {
                            //MessageBox.Show("666-2");
                            File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\money_account.txt", "1, 김아무개, 농협, 사원, xx,3000,2000-01-01");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            saveDialog.FileName = "money_account.txt".ToString();

            return saveDialog;
        } // 다이얼로그 기본 정의


        private void Save_csv(string fileName, DataGridView dgview, bool header) // 그리드뷰의 내용을 텍스트로 옮겨 적는 코드
        {
            string delimiter = ",";  // 구분자
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8); //UTF8로 엔코딩

            if (dgview.Rows.Count == 0) return;

            // header가 true면 헤더정보 출력
            //if (header)
            //{
            //    for (int i = 0; i < dgview.Columns.Count; i++)
            //    {
            //        csvExport.Write(dgview.Columns[i].HeaderText);
            //        if (i != dgview.Columns.Count - 1)
            //        {
            //            csvExport.Write(delimiter);
            //        }
            //    }
            //}

            //csvExport.Write(csvExport.NewLine); // add new line

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

        private void button7_Click(object sender, EventArgs e) // 상여금
        {
            string[] lines = File.ReadAllLines(file_path2, Encoding.UTF8);//불러오기
            foreach (var m in lines)
            {
                string[] M = m.Split(',');
                if (M[0] == matching || M[1] == matching)
                {
                    int result = (Convert.ToInt32(M[5]) / 12) * 2; //상여금 계산식
                    MessageBox.Show($"{M[1]}님의 상여금은 총 {result.ToString("#,##0")}만원입니다.");
                }
            }
        }
        private static string matching = "";
        private void button8_Click(object sender, EventArgs e) // 퇴직금
        {
            string[] Money = File.ReadAllLines(file_path2, Encoding.UTF8);//불러오기
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);//사원 멤버 텍스트 불러오기
            int work_day = 0;//근로연수
            string SP = "";
            int i = 0;
            try
            {
                foreach (var l in lines)
                {
                    string[] L = l.Split(',');
                    if (L[0] == matching || L[1] == matching)
                    {
                        DateTime dateTime = DateTime.Now;
                        TimeSpan result = dateTime - Convert.ToDateTime(L[5]);
                        work_day = (result.Days / 30) / 12; //근속연수           
                        foreach (var m in Money)
                        {
                            string[] M = m.Split(',');
                            int basic_salary = (Convert.ToInt32(M[5]) / 12); //평균임금
                            int severance_pay = basic_salary * work_day;
                            if (L[i] == M[i])
                            {
                                SP = severance_pay.ToString("#,##0");
                                MessageBox.Show($"{M[1]}님의 퇴직금은 총 {SP}만원입니다.");
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            matching = dataGridView1.SelectedCells[0].Value.ToString();
            MessageBox.Show($"matching : {matching}");
        }
    }
}
