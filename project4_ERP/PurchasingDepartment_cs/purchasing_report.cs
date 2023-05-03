﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace project4_ERP.PurchasingDepartment_cs
{
    public partial class purchasing_report : UserControl
    {
        public static string product_report = "product_report.txt";
        public static string purchas_report = "purchasing_report.txt";
        public static string Purchasing_inventory_status = "purchasing_inventory_status.txt";
        public static string Qulity_imported = "imported_inspection.txt";
        public static string file_path = @"C:\\ERP4\\PurchasingDepartment\\" + purchas_report;
        public static string file_path2 = @"C:\\ERP4\\ProductionDepartment\\" + product_report;        
        public static string file_path3 = @"C:\ERP4\PurchasingDepartment\\" + Purchasing_inventory_status; // 생산재고현황
        public static string file_path4 = @"C:\\ERP4\\QualityDepartment\\" + Qulity_imported; // 품질검사
        public static string file_path5 = @"C:\\ERP4\\PersonnelDepartment\\worker_member.txt";
        

        public string search_name;
        public string search_condition;
        public string nowlogin;
        public purchasing_report()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search_name = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            search_condition = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            dataGridView1.Rows.Clear();
            foreach (var line in lines)
            {
                string[] number = line.Split(',');
                if (search_condition == "품목코드")
                {
                    if (search_name == number[0])
                    {

                        dataGridView1.Rows.Add(number);
                        //MessageBox.Show("사번검색기록");

                    }
                }
                else if (search_condition == "품명")
                {
                    if (search_name == number[1])
                    {

                        dataGridView1.Rows.Add(number);
                        //MessageBox.Show("이름검색기록");

                    }
                }
                else if (search_condition == "날짜")
                {
                    if (search_name == number[2])
                    {

                        dataGridView1.Rows.Add(number);
                        //MessageBox.Show("부서검색기록");

                    }
                }
                else if (search_condition == "반입")
                {
                    if (search_name == number[5])
                    {

                        dataGridView1.Rows.Add(number);
                        //MessageBox.Show("직책검색기록");

                    }
                }
                else if (search_condition == "반출")
                {
                    if (search_name == number[6])
                    {

                        dataGridView1.Rows.Add(number);
                        //MessageBox.Show("직책검색기록");

                    }
                }
                else if (search_condition == "수불부서")
                {
                    if (search_name == number[7])
                    {

                        dataGridView1.Rows.Add(number);
                        //MessageBox.Show("직책검색기록");

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 조건 : 로그인한 아이디를 워크맴버에서 검색해서 직책이 과장 이상일때는 true,false 다 보여주기
            // 조건 : 마지막 인덱스 값이 false일때는 직책이 사원 대리 일때는 안보여줌, true일때는 보여줌
            if (File.Exists(file_path))
            {
                string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
                dataGridView1.Rows.Clear();
                if (nowlogin == "과장" || nowlogin == "이사" || nowlogin == "사장")
                {
                    foreach (var line in lines)
                    {
                        string[] getdata = line.Split(',');
                        if (getdata[8] == "true" || getdata[8] == "false")
                        {
                            dataGridView1.Rows.Add(getdata);
                        }
                    }
                }
                else if (nowlogin == "사원" || nowlogin == "대리")
                {
                    foreach (var line in lines)
                    {
                        string[] getdata = line.Split(',');
                        if (getdata[8] == "true")
                        {
                            dataGridView1.Rows.Add(getdata);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("출력할 파일이 없습니다.");
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 정보가 저장됩니다", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExportToCSV();
                // text파일 내용만 가져와서 인덱스를 바꾸는 코드
                change_csv(file_path, file_path2);
                numberzero(file_path3);
                change_csv_calcular(file_path, file_path3);
                change_csv_inventory(file_path, file_path4);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists(file_path) && File.Exists(file_path2))
            {
                Save_csv4(file_path, dataGridView1, true);
                change_csv(file_path, file_path2);
                change_csv_calcular(file_path, file_path3);
                change_csv_inventory(file_path, file_path4);
            }
            else
            {
                ExportToCSV();
                StreamWriter sw = new StreamWriter(file_path2);
                StreamWriter sw2 = new StreamWriter(file_path2);
                StreamWriter sw3 = new StreamWriter(file_path2);
                sw.Close();
                sw.Dispose();
                sw2.Close();
                sw2.Dispose();
                sw3.Close();
                sw3.Dispose();
                change_csv(file_path, file_path2);
                change_csv_calcular(file_path, file_path3);
                change_csv_inventory(file_path, file_path4);

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
            saveDialog.FileName = "purchasing_report.txt".ToString();

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
                        if (i == dgview.Columns.Count - 1)
                        {
                            if (row.Cells[i].Value == null)
                            {
                                row.Cells[i].Value = "false";
                            }

                        }
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
                        if (i == dgview.Columns.Count - 1)
                        {
                            if (row.Cells[i].Value == null)
                            {
                                row.Cells[i].Value = "false";
                            }
                        }
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

        private void change_csv(string aaa, string bbb)  // 수불장부 변경 내용
        {
            string[] line = File.ReadAllLines(aaa, Encoding.UTF8); // 생산 : PR, 품질 : QU 구매 : PU
            List<string> list = new List<string>(line);
            for (int j = 0; j < list.Count; j++)
            {
                string[] name = list[j].Split(',');
                if (name[7] == "PR")
                {
                    name[6] = name[6].Replace("1", "0");
                    name[5] = name[5].Replace("0", "1");
                    name[7] = name[7].Replace("PR", "PU");
                    name[8] = "false";
                    list[j] = "";
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (i != name.Length - 1)
                        {
                            list[j] = list[j] + name[i] + ",";
                        }
                        else
                        {
                            list[j] = list[j] + name[i];
                        }
                    }
                }
                else
                {
                    list.RemoveAt(j);
                    j -= 1;
                }
            }
            StreamWriter sw = new StreamWriter(bbb);
            foreach (string j in list)
            {
                sw.WriteLine(j);
            }
            sw.Close();
            sw.Dispose();
        }

        private void change_csv_inventory(string aaa, string bbb)  // 파일이 있을 경우 들어가 있는 파일에서 부서에 따라서 옮기는 내용.
        {
            string[] line = File.ReadAllLines(aaa, Encoding.UTF8); // 생산 : PR, 품질 : QU 구매 : PU
            List<string> list = new List<string>(line);
            for (int j = 0; j < list.Count; j++)
            {
                string[] name = list[j].Split(',');
                if (name[7] == "EX")
                {                    
                    //MessageBox.Show("if");
                    list[j] = "";
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (i != name.Length - 1)
                        {
                            list[j] = list[j] + name[i] + ",";
                        }
                        else
                        {
                            list[j] = list[j] + name[i];
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("else");
                    list.RemoveAt(j);
                    j -= 1;
                }
            }

            string[] line2 = File.ReadAllLines(bbb, Encoding.UTF8);
            List<string> list2 = new List<string>(line2);

            for (int j = 0; j < list.Count; j++)
            {
                string[] name = list[j].Split(',');
                list[j] = "";
                for (int i = 0; i < 5; i++)
                {
                    if (i != name.Length - 1)
                    {
                        list[j] = list[j] + name[i] + ",";
                    }
                    else
                    {
                        list[j] = list[j] + name[i];
                    }
                }
                list2.Add(list[j]);
            }
            list2 = list2.Distinct().ToList();
            StreamWriter sw = new StreamWriter(bbb);
            foreach (string j in list2)
            {
                sw.WriteLine(j);
            }
            sw.Close();
            sw.Dispose();
        }

        private void purchasing_report_Load(object sender, EventArgs e)
        {
            string Nlogin = Form6.ID;
            string[] memberline = File.ReadAllLines(file_path5, Encoding.UTF8);
            foreach (var mline in memberline)
            {
                string[] memberdata = mline.Split(',');
                if (Nlogin == memberdata[0])
                {
                    nowlogin = memberdata[3];
                }
            }
        }

        private void change_csv_calcular(string aaa, string bbb) // 수불대장 정보를 재고현황에 띄우는 코드
        {
            string[] line = File.ReadAllLines(aaa, Encoding.UTF8); // 생산 : PR, 품질 : QU 구매 : PU
            List<string> list = new List<string>(line);
            

            string[] line2 = File.ReadAllLines(bbb, Encoding.UTF8);
            List<string> list2 = new List<string>(line2);
            //int countplus = 0;
            //int countminus = 0;
            for (int i = 0; i < list2.Count;i++)
            {
                string [] names = list2[i].Split(',');
                for (int j = 0; j < list.Count; j++)
                {
                    string[] name2 = list[j].Split(',');
                    if (name2[7] == "EX")
                    {
                        if (names[0] == name2[0])
                        {
                            list2[i] = "";
                            int PU_IN = Convert.ToInt32(names[3]);
                            int PU_RE = Convert.ToInt32(name2[3]);
                            //countplus += PU_RE;
                            names[3] = Convert.ToString(PU_IN + PU_RE);
                            //names[3] = Convert.ToString(countplus);
                            for (int k = 0; k < names.Length; k++)
                            {
                                if (i != names.Length - 1)
                                {
                                    list2[i] = list2[i] + names[k] + ",";
                                }
                                else
                                {
                                    list2[i] = list2[i] + names[k];
                                }
                            }
                        }
                    }
                    else if (name2[7] == "PR")
                    {
                        if (names[0] == name2[0])
                        {
                            list2[i] = "";
                            int PU_IN = Convert.ToInt32(names[3]);
                            int PU_RE = Convert.ToInt32(name2[3]);
                            //countminus += PU_RE;
                            names[3] = Convert.ToString(PU_IN - PU_RE);

                            for (int k = 0; k < names.Length; k++)
                            {
                                if (i != names.Length - 1)
                                {
                                    list2[i] = list2[i] + names[k] + ",";
                                }
                                else
                                {
                                    list2[i] = list2[i] + names[k];
                                }
                            }
                        }
                    }
                        
                }                
                
            }
            list2 = list2.Distinct().ToList();
            StreamWriter sw = new StreamWriter(bbb);
            foreach (string j in list2)
            {
                sw.WriteLine(j);
            }
            sw.Close();
            sw.Dispose();

        }

        private void numberzero(string aaa)
        {
            string[] line2 = File.ReadAllLines(aaa, Encoding.UTF8);
            List<string> list2 = new List<string>(line2);
            for (int i = 0; i < list2.Count; i++)
            {
                string[] name = list2[i].Split(',');
                list2[i] = "";
                name[3] = "0";
                for (int j = 0; j < name.Length; j++)
                {
                    if (i != name.Length - 1)
                    {
                        list2[i] = list2[i] + name[j] + ",";
                    }
                    else
                    {
                        list2[i] = list2[i] + name[j];
                    }
                }

            }
            list2 = list2.Distinct().ToList();
            StreamWriter sw = new StreamWriter(aaa);
            foreach (string j in list2)
            {
                sw.WriteLine(j);
            }
            sw.Close();
            sw.Dispose();
        }

    }
}
