using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project4_ERP.ProductionDepartment_cs
{
    public partial class work_manual : UserControl
    {
        public work_manual()
        {
            InitializeComponent();
            this.button9.Click += button9_Click;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            button1.BackColor = Color.DimGray;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.DimGray;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.DimGray;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.DimGray;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.Black;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.DimGray;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.White;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.Black;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.DimGray;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.White;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.Black;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = true;
            pictureBox8.Visible = false;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.DimGray;
            button8.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.White;
            button8.ForeColor = Color.Black;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = true;
            button1.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
            button3.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button6.BackColor = Color.Gainsboro;
            button7.BackColor = Color.Gainsboro;
            button8.BackColor = Color.DimGray;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
            button6.ForeColor = Color.Black;
            button7.ForeColor = Color.Black;
            button8.ForeColor = Color.White;
        }
        private void button9_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void button9_MouseClick(object sender, MouseEventArgs e) //이미지 저장
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "이미지 파일|*.png";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Visible == true)
                {
                    if (pictureBox1.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox1.Tag = openFileDialog.FileName;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox2.Visible == true)
                {
                    if (pictureBox2.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox2.Tag = openFileDialog.FileName;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox3.Visible == true)
                {
                    if (pictureBox3.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox3.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox3.Tag = openFileDialog.FileName;
                            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox4.Visible == true)
                {
                    if (pictureBox4.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox4.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox4.Tag = openFileDialog.FileName;
                            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox5.Visible == true)
                {
                    if (pictureBox5.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox5.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox5.Tag = openFileDialog.FileName;
                            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox6.Visible == true)
                {
                    if (pictureBox6.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox6.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox6.Tag = openFileDialog.FileName;
                            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox7.Visible == true)
                {
                    if (pictureBox7.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox7.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox7.Tag = openFileDialog.FileName;
                            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }
                else if (pictureBox8.Visible == true)
                {
                    if (pictureBox8.Image == null)
                    {
                        if (MessageBox.Show("작업지시서를 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pictureBox8.Image = new Bitmap(openFileDialog.FileName);
                            pictureBox8.Tag = openFileDialog.FileName;
                            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show("아니요 클릭");
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당버튼의 작업지시서가 존재합니다.");
                    }
                }

            }
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)  //이미지 삭제
        {
            if (MessageBox.Show("작업지시서를 삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (pictureBox1.Visible == true)
                {
                    if(pictureBox1.Image != null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox2.Visible == true)
                {
                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox3.Visible == true)
                {
                    if (pictureBox3.Image != null)
                    {
                        pictureBox3.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox4.Visible == true)
                {
                    if (pictureBox4.Image != null)
                    {
                        pictureBox4.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox5.Visible == true)
                {
                    if (pictureBox5.Image != null)
                    {
                        pictureBox5.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox6.Visible == true)
                {
                    if (pictureBox6.Image != null)
                    {
                        pictureBox6.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox7.Visible == true)
                {
                    if (pictureBox7.Image != null)
                    {
                        pictureBox7.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
                else if (pictureBox8.Visible == true)
                {
                    if (pictureBox8.Image != null)
                    {
                        pictureBox8.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("작업지시서가 존재하지 않습니다.");
                    }
                }
            }
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
