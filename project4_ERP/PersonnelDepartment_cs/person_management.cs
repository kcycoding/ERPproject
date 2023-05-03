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
    public partial class person_management : UserControl
    {
        public static int Year = DateTime.Now.Year;
        public static int Month = DateTime.Now.Month;
        public static int Day = DateTime.Now.Day;
        public string seach_name;
        public string seach_condition;
        public string date;
        private static string user_name = "worker_member.txt";         //사원멤버 텍스트
        private static string file_path = @"C:\\ERP4\\PersonnelDepartment\\" + user_name;
        private static string manage = $".{Year}-{Month}-{Day}.txt";    //근태관리 텍스트
        private static string file_path2 = @"C:\\ERP4\\PersonnelDepartment\\managements\\" + manage;
        private static string user_id = "login_logout.txt";            //로그이력 텍스트
        private static string log = @"C:\\ERP4\\PersonnelDepartment\\" + user_id;

        public static string e_mail;
        public person_management()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // 검색창
        {
            seach_name = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // 조건 콤보박스
        {
            seach_condition = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e) // 검색 버튼
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            dataGridView1.Rows.Clear();
            foreach (var line in lines)
            {
                string[] number = line.Split(',');
                if (seach_condition == "사번")
                {
                    if (seach_name == number[0])
                    {

                        dataGridView1.Rows.Add(number);
                        e_mail = number[4];

                    }
                }
                else if (seach_condition == "이름")
                {
                    if (seach_name == number[1])
                    {

                        dataGridView1.Rows.Add(number);
                        e_mail = number[4];

                    }
                }
                else if (seach_condition == "부서")
                {
                    if (seach_name == number[2])
                    {

                        dataGridView1.Rows.Add(number);
                        e_mail = number[4];

                    }
                }
                else if (seach_condition == "직책")
                {
                    if (seach_name == number[3])
                    {

                        dataGridView1.Rows.Add(number);
                        e_mail = number[4];
                        //MessageBox.Show("직책검색기록");

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // 새로고침버튼
        {
            if (File.Exists(file_path))
            {
                string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
                dataGridView1.Rows.Clear();
                e_mail = "";
                foreach (var line in lines)
                {

                    string[] getdata = line.Split(',');
                    dataGridView1.Rows.Add(getdata);

                }
            }
            else
            {
                MessageBox.Show("출력할 파일이 없습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e) //뷰초기화 버튼
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // 사원리스트 보이는 표
        {
            var go_to_work = "09:00:00"; //출근시간
            var leave_work = "18:00:00"; //퇴근시간

            string[] lines = File.ReadAllLines(log, Encoding.UTF8);//불러오기
            dataGridView2.Rows.Clear();

            foreach (var line in lines)
            {
                string[] getdata = line.Split(',');
                dataGridView2.Rows.Add(getdata);
            }

            string[] liness = File.ReadAllLines(log, Encoding.UTF8);//출력
            dataGridView2.Rows.Clear();

            Form1 form2 = new Form1();
            int work_timeH = Form1.work_time_H; //현재시간 - 출근시간 (시 차이)
            int work_timeM = Form1.work_time_M; //현재시간 - 출근시간 (분 차이)

            try
            {
                foreach (var line in lines)
                {
                    string[] number = line.Split(',');
                    if (e_mail == number[0])
                    {
                        if (work_timeH < 9)//근무시간이 9시간 미만이면
                        {
                            if (Convert.ToDateTime(go_to_work) < Convert.ToDateTime(number[1]))//9시 보다 출근시간이 크면
                            {
                                dataGridView2.Rows.Add("지각", number[1]);//number[1]는 로그인(출근) 시간
                            }
                            if (number[2] != "")
                            {
                                if (Convert.ToDateTime(leave_work) > Convert.ToDateTime(number[2]))//18시 보다 퇴근시간이 작으면
                                {
                                    dataGridView2.Rows.Add("조퇴", number[2]);//number[2]는 로그아웃(퇴근) 시간
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (number[2] != "")
                            {
                                dataGridView2.Rows.Add("야근", number[2]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("사원검색 후 눌러주세요"); }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // 근태관리 보이는 표
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) // 날짜선택 피커
        {
            textBox2.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // 선택한 날짜 들어가는 텍스트창
        {
            date = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e) // 삭제
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            List<string> list = new List<string>(); // 리스트하나 만들기
            int selectedRowCount = dataGridView2.SelectedRows.Count;
            DataGridViewSelectedRowCollection selectedRows = dataGridView2.SelectedRows;
            int index = selectedRows[0].Index;

            for (int i = 0; i < selectedRowCount; i++)
            {
                dataGridView2.Rows.Remove(selectedRows[i]); // 표에서 선택된 행 삭제
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
            string[] work_member = File.ReadAllLines(file_path, Encoding.UTF8);//사원멤버 텍스트 불러오기
            string[] logs = File.ReadAllLines(log, Encoding.UTF8);//로그이력 텍스트 불러오기
            if (MessageBox.Show("선택하신 정보가 저장됩니다", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExportToCSV();
            }
            foreach (var i in logs)
            {
                string[] Log = i.Split(',');
                foreach (var j in work_member)
                {
                    string[] Member = j.Split(',');
                    if (Member[4] != Log[0])//로그이력에 이메일이 존재하지 않으면
                    {
                        if (Log[0] == "")
                        {
                            continue;
                        }
                        else
                        {
                            //근태관리 텍스트에 해당 이메일 삽입 + 결근 값 주기
                            File.AppendAllText(file_path2, $"{Member[0]},{Member[1]},{Member[2]},{Member[3]}{Environment.NewLine}결근,{Year}-{Month}-{Day}{Environment.NewLine}");
                        }
                    }
                }
                break;
            }
        }

        private void button6_Click(object sender, EventArgs e) // 신규추가
        {
            if (File.Exists(file_path) && File.Exists(file_path))
            {
                Save_csv4(file_path, dataGridView2, true); // 파일이 있다면 그파일에 그리드 뷰의 내용만 넣기
                //Save_csv4(file_path2, dataGridView1, true); // 품질부도 같은 내용의 신규 내용을 넣기
                MessageBox.Show("11");
            }
            else
            {
                ExportToCSV();
            }
        }
        private static string file = @"c:\\managements\\"; //파일 폴더 불러오기
        private static string manage_1 = "";
        private void button7_Click(object sender, EventArgs e)// 불러오기
        {
            bool key = true;
            bool key_2 = false;
            dataGridView2.Rows.Clear();
            string[] work_member = File.ReadAllLines(file_path, Encoding.UTF8);//사원멤버 텍스트 불러오기
            while (key)
            {
                try
                {
                    manage_1 = file + $".{date}.txt";
                    string[] mange_2 = File.ReadAllLines(manage_1, Encoding.UTF8);
                    int kill = 0;
                    foreach (var l in mange_2)
                    {
                        string[] date = l.Split(',');//근태이력
                        if (seach_condition == "사번")
                        {
                            if (key_2 == true)
                            {
                                if (!int.TryParse(date[0], out kill))
                                {
                                    dataGridView2.Rows.Add(date);
                                }
                                else
                                {
                                    key_2 = false;
                                    break;
                                }
                            }
                            if (seach_name == date[0])
                            {
                                key_2 = true;
                                continue;
                            }
                        }
                        else if (seach_condition == "이름")
                        {
                            if (key_2 == true)
                            {
                                if (!int.TryParse(date[0], out kill))
                                {
                                    dataGridView2.Rows.Add(date);
                                }
                                else
                                {
                                    key_2 = false;
                                    break;
                                }
                            }
                            if (seach_name == date[1])
                            {
                                key_2 = true;
                                continue;
                            }
                        }
                        else if (seach_condition == "부서")
                        {
                            if (key_2 == true)
                            {
                                if (!int.TryParse(date[0], out kill))
                                {
                                    dataGridView2.Rows.Add(date);
                                }
                                else
                                {
                                    key_2 = false;
                                    break;
                                }
                            }
                            if (seach_name == date[2])
                            {
                                key_2 = true;
                                continue;
                            }
                        }
                        else if (seach_condition == "직책")
                        {
                            if (key_2 == true)
                            {
                                if (!int.TryParse(date[0], out kill))
                                {
                                    dataGridView2.Rows.Add(date);
                                }
                                else
                                {
                                    key_2 = false;
                                    break;
                                }
                            }
                            if (seach_name == date[3])
                            {
                                key_2 = true;
                                continue;
                            }
                        }
                    }
                    key = false;
                }
                catch (FileNotFoundException f)
                {
                    MessageBox.Show("파일이 존재하지 않습니다.");
                    break;
                }
                catch (Exception ex) { MessageBox.Show(ex.StackTrace); }
            }
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
            saveDialog.FileName = $"{Year}-{Month}-{Day}.txt".ToString();

            return saveDialog;
        } // 다이얼로그 기본 정의

        private void Save_csv(string fileName, DataGridView dgview, bool header) // 그리드뷰의 내용을 텍스트로 옮겨 적는 코드
        {
            string delimiter = ",";  // 구분자
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8); //UTF8로 엔코딩

            if (dgview.Rows.Count == 0) return;

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
