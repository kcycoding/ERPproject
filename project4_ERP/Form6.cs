using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project4_ERP
{

    public partial class Form6 : Form
    {

        private static string user_name = "worker_member.txt";     //사원 텍스트파일
        private static string file_path = @"C:\ERP4\PersonnelDepartment\\" + user_name;
        private static string user_log = "login_logout.txt";       //로그이력 텍스트파일
        private static string log = @"C:\ERP4\PersonnelDepartment\\" + user_log;

        public static string ID; //로그아웃 시 받을 전역변수
        public static string go_to_work_time;
        public Form6()
        {
            InitializeComponent();
            openFolder();
        }



        private void open()
        {
            textBox1.Clear();
            textBox2.Clear();
            this.Visible = true;

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            for (var line = 0; line < lines.Length; line++)
            {
                string[] number = lines[line].Split(',');
                comboBox1.Items.Add(number[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e) // 나가기버튼
        {
           
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // 아이디 텍스트 박스
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // 비밀번호 텍스트 박스
        {
            

        }

        private void button1_Click(object sender, EventArgs e) // 로그인버튼
        {
            
            string userID = textBox1.Text;          //ID창
            string userPassword = textBox2.Text;    //Password창
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8); //사원 텍스트파일 불러오기
            DateTime log_time = DateTime.Now;       //로그인 시 텍스트에 남길 시간
            try
            {
                if (userID == "0000")
                {
                    if (userPassword == "0000")
                    {
                        openFolder();
                        this.Visible = false;
                        Form7 form = new Form7();
                        form.lf += open;
                        form.ShowDialog();
                        return;
                    }
                }
                for (var line = 0; line < lines.Length; line++)
                {
                    string[] number = lines[line].Split(',');
                    if (number[0] == userID)//사번이 아이디
                    {
                        if (number[7] == "")
                        {
                            if (number[4] == userPassword)//이메일이 비밀번호
                            {
                                StreamWriter writer = File.AppendText(log);
                                ID = userPassword;
                                writer.Write("{0},{1},", userPassword, log_time.ToString("yyyy-MM-dd H:mm"));
                                go_to_work_time = log_time.ToString("yyyy-MM-dd H:mm");
                                writer.Close();
                                writer.Dispose();
                                if (number[2] == "인사")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form1 form = new Form1();
                                    form.lf += open;
                                    form.ShowDialog();
                                    break;
                                }
                                else if (number[2] == "생산")
                                {
                                    
                                    openFolder();
                                    this.Visible = false;
                                    Form2 form = new Form2();
                                    form.lf += open;
                                    form.ShowDialog();
                                    break;
                                }
                                else if (number[2] == "품질")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form3 form = new Form3();
                                    form.lf += open;
                                    form.ShowDialog();
                                    break;
                                }
                                else if (number[2] == "구매")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form4 form = new Form4();
                                    form.lf += open;
                                    form.ShowDialog();
                                    break;
                                }
                                
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (userPassword == "")
                                {
                                    MessageBox.Show("비밀번호를 입력해주세요.");
                                    break;
                                }
                                else if (userPassword != number[1])
                                {
                                    MessageBox.Show("비밀번호가 맞지 않습니다.");
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            if (number[7] == userPassword)//이메일이 비밀번호
                            {
                                StreamWriter writer = File.AppendText(log);
                                ID = userPassword;
                                writer.Write("{0},{1},", userPassword, log_time.ToString("yyyy-MM-dd H:mm"));
                                go_to_work_time = log_time.ToString("yyyy-MM-dd H:mm");
                                writer.Close();
                                writer.Dispose();
                                if (number[2] == "인사")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form1 form = new Form1();
                                    form.lf += open;
                                    form.ShowDialog();
                                    break;
                                }
                                else if (number[2] == "생산")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form2 form = new Form2();
                                    form.lf += open;
                                    
                                    form.ShowDialog();
                                    break;
                                }
                                else if (number[2] == "품질")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form3 form = new Form3();
                                    form.lf += open;
                                    form.Show();
                                    form.ShowDialog();
                                    break;
                                }
                                else if (number[2] == "구매")
                                {
                                    openFolder();
                                    this.Visible = false;
                                    Form4 form = new Form4();
                                    form.lf += open;
                                    form.ShowDialog();
                                    break;
                                }                                
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (userPassword == "")
                                {
                                    MessageBox.Show("비밀번호를 입력해주세요.");
                                    break;
                                }
                                else if (userPassword != number[1])
                                {
                                    MessageBox.Show("비밀번호가 맞지 않습니다.");
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (userID == "")
                        {
                            MessageBox.Show("아이디를 입력해주세요.");
                            break;
                        }
                        else if (userID != number[0])
                        {                            
                            continue;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_lf()
        {
            throw new NotImplementedException();
        }

        private static void openFolder()
        {

            if (!File.Exists("C:\\ERP4"))
            {
                DirectoryInfo ERP4 = new DirectoryInfo("C:\\ERP4");
                ERP4.Create();
                if (!File.Exists("C:\\ERP4\\PersonnelDepartment"))
                {
                    DirectoryInfo a = new DirectoryInfo("C:\\ERP4\\PersonnelDepartment");
                    a.Create();
                    if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\worker_member.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\worker_member.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\login_logout.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\login_logout.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\div_pos_move_member.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\div_pos_move_member.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\money_account.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\money_account.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\PersonnelDepartment\\suggestion_ad.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PersonnelDepartment\\suggestion_ad.txt", null);
                    }
                }
                if (!File.Exists("C:\\ERP4\\ProductionDepartment"))
                {
                    DirectoryInfo b = new DirectoryInfo("C:\\ERP4\\ProductionDepartment");
                    b.Create();
                    if (!File.Exists("C:\\ERP4\\ProductionDepartment\\inventory_status.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\ProductionDepartment\\inventory_status.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\ProductionDepartment\\product_report.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\ProductionDepartment\\product_report.txt", null);
                    }
                }
                if (!File.Exists("C:\\ERP4\\PurchasingDepartment"))
                {
                    DirectoryInfo c = new DirectoryInfo("C:\\ERP4\\PurchasingDepartment");
                    c.Create();
                    if (!File.Exists("C:\\ERP4\\PurchasingDepartment\\purchasing_date.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PurchasingDepartment\\purchasing_date.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\PurchasingDepartment\\purchasing_inventory_status.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PurchasingDepartment\\purchasing_inventory_status.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\PurchasingDepartment\\purchasing_report.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\PurchasingDepartment\\purchasing_report.txt", null);
                    }
                }
                if (!File.Exists("C:\\ERP4\\QualityDepartment"))
                {
                    DirectoryInfo d = new DirectoryInfo("C:\\ERP4\\QualityDepartment");
                    d.Create();
                    if (!File.Exists("C:\\ERP4\\QualityDepartment\\imported_inspection.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\QualityDepartment\\imported_inspection.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\QualityDepartment\\lot_report.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\QualityDepartment\\lot_report.txt", null);
                    }
                    if (!File.Exists("C:\\ERP4\\QualityDepartment\\quality_report.txt"))
                    {
                        File.WriteAllText("C:\\ERP4\\QualityDepartment\\quality_report.txt", null);
                    }
                }
            }
        }

        public static string input_id;  //아이디 입력(아이디 찾기)
        public static string find_password;  //비밀번호 찾기
        public static string now_password;  //현재 비밀번호
        public static string change_password;  //비밀번호 변경
        public static string check_password;  //비밀번호 확인
        public static int password_length;
        public static string notice1;
        public static string notice2;

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // 비밀번호찾기 버튼
        {
            textBox3.Clear();
            textBox4.Clear();
            panel5.Visible = true;
            panel5.Location = new Point(75, 200);
            panel5.Size = new Size(320, 240);
        }

        private void button4_Click(object sender, EventArgs e) // 비밀번호변경 버튼
        {
            textBox3.Clear();
            textBox4.Clear();
            panel7.Visible = true;
            panel7.Location = new Point(75, 110);
            panel7.Size = new Size(300, 320);
        }

        private void button5_Click(object sender, EventArgs e) // 비밀번호찾기 패널 닫기 버튼
        {
            panel5.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e) // 비밀번호 찾기 패널
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // 비밀번호찾기 아이디 텍스트박스
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            input_id = textBox3.Text;
            for (var line = 0; line < lines.Length; line++)
            {
                string[] number = lines[line].Split(',');
                if (number[0] == input_id)
                {
                    if (number[7] != "")
                    {
                        label13.Visible = false;
                        textBox4.Text = number[7];
                        break;
                    }
                    else
                    {
                        label13.Visible = false;
                        textBox4.Text = number[4];
                        break;
                    }
                }
                else
                {
                    label13.Visible = true;
                    label13.ForeColor = Color.Red;
                    label13.Text = "존재하지 않는 아이디";
                    textBox4.Text = "";
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // 비밀번호찾기 비밀번호 텍스트박스
        {
            find_password = textBox4.Text;
        }

        private void button6_Click(object sender, EventArgs e) //비밀번호 변경 닫기버튼
        {
            panel7.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //비밀번호변경 콤보박스
        {
            input_id = comboBox1.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e) // 비밀번호 변경 현재아이디텍스트박스
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            input_id = comboBox1.Text;
            now_password = textBox5.Text;
            for (var line = 0; line < lines.Length; line++)
            {
                string[] number = lines[line].Split(',');
                if (number[0] == input_id)
                {
                    if (number[7] == "")
                    {
                        if (number[4] == now_password)
                        {
                            textBox6.ReadOnly = false;
                            textBox7.ReadOnly = false;
                            button7.Visible = true;
                            break;
                        }
                        else
                        {
                            textBox6.ReadOnly = true;
                            textBox7.ReadOnly = true;
                            button7.Visible= false;
                            break;
                        }
                    }
                    else
                    {
                        if (number[7] == now_password)
                        {
                            textBox6.ReadOnly = false;
                            textBox7.ReadOnly = false;
                            break; 
                        }
                        else
                        {
                            textBox6.ReadOnly = true;
                            textBox7.ReadOnly = true;
                            break;
                        }
                    }

                }


            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e) // 비밀번호변경 비밀번호변경텍스트박스
        {
            change_password = textBox6.Text;
            password_length = change_password.Length;

            if (now_password == change_password)
            {
                label11.Visible = true;
                label11.ForeColor = Color.Red;
                label11.Text = "현재 비밀번호와 일치합니다.";
                textBox7.ReadOnly = true;
                button7.Visible = false;

            }
            else
            {
                label11.Visible = false;
                if (password_length > 4)
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Green;
                    label11.Text = "비밀번호 확인 입력";
                    if (label11.Text == "비밀번호 확인 입력")
                    {
                        textBox7.ReadOnly = false;
                    }

                }
                else
                {
                    label11.Visible = true;
                    label11.ForeColor = Color.Red;
                    label11.Text = "5글자 이상 가능";
                    if (label11.Text == "5글자 이상 가능")
                    {
                        label12.ForeColor = Color.Red;
                        label12.Text = "변경 불가능";
                        button7.Visible = false;
                    }
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e) // 비밀번호변경 비밀번호확인텍스트박스
        {
            check_password = textBox7.Text;
            label12.Visible = true;
            if (change_password == check_password)
            {
                if (label11.Text == "5글자 이상 가능")
                {
                    textBox7.ReadOnly = true;
                    label12.ForeColor = Color.Red;
                    label12.Text = "변경 불가능";
                    button7.Visible = false;
                }
                else
                {
                    label12.ForeColor = Color.Green;
                    label12.Text = "변경 가능";
                    if (label12.Text == "변경 가능")
                    {
                        button7.Visible = true;
                    }
                    else
                    {
                        button7.Visible = false;
                    }
                }
            }
            else
            {
                label12.ForeColor = Color.Red;
                label12.Text = "변경 불가능";
                button7.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e) // 비밀번호변경 변경버튼
        {
            string[] lines = File.ReadAllLines(file_path, Encoding.UTF8);
            List<string> list = new List<string>(lines);
            List<string> list2 = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                string[] name = list[i].Split(',');
                if (name[0] == input_id)
                {
                    for (int j = 0; j < name.Length; j++)
                    {
                        if (name.Length == 8)
                        {
                            list2.Add(list[i] + change_password + ",");
                            break;
                        }
                        else
                        {
                            //list.RemoveAt(list.Count - 1);
                            list2.Add(list[i] + change_password + ",");
                            break;
                        }
                    }
                }
                else
                {
                    list2.Add(list[i]);
                }
            }
            StreamWriter sw = new StreamWriter(file_path);
            foreach (string j in list2)
            {
                sw.WriteLine(j);
            }
            sw.Close();
            sw.Dispose();
            panel7.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private Point point = new Point();
        

        

        private void Form6_MouseMove_1(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }

        private void Form6_MouseDown_1(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font("Calibri", 11, FontStyle.Regular);
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.Font = new Font("Calibri", 11, FontStyle.Underline);
            button3.ForeColor = Color.Blue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Font = new Font("Calibri", 11, FontStyle.Regular);
            button4.ForeColor = Color.Black;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.Font = new Font("Calibri", 11, FontStyle.Underline);
            button4.ForeColor = Color.Blue;
        }
    }
    
}
