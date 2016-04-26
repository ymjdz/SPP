using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinglePointPositioning
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        bool isButton1Complete, isButton2Complete;
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag;
            label4.Text = null;
            SPP spp = new SPP();
            flag = spp.Read_N_File();
            isButton1Complete = flag;
            if (flag == true)
            {
                label4.Text = "√";
                button2.Focus();
            }
            if (isButton1Complete==true&&isButton2Complete==true)
            {
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag;
            label5.Text = null;
            SPP spp = new SPP();
            flag = spp.Read_O_File();
            isButton2Complete = flag;
            if (isButton1Complete == true && isButton2Complete == true)
            {
                button3.ForeColor = Color.Black;
                button3.Text = "计算";
                button3.Enabled = true;
            }
            if (flag == true)
            {
                label5.Text = "√";
                button3.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            button3.ForeColor = Color.Red;
            button3.Text = "计算中...";
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SPP spp = new SPP();
            spp.Positioning();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Hide();
            button3.ForeColor = Color.Red;
            button3.Text = "计算完成";
            button3.Enabled = false;
            analyse.Enabled = true;
            textBox1.Text = Result.X.ToString();
            textBox2.Text = Result.Y.ToString();
            textBox3.Text = Result.Z.ToString();
            button4.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Result.X = 0;
            Result.Y = 0;
            Result.Z = 0;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            button3.ForeColor = Color.Black;
            button3.Text = "计算";
            button3.Enabled = true;
            button1.Focus();
            analyse.Enabled = false;
        }

        private void analyse_Click(object sender, EventArgs e)
        {
            Paint paint = new Paint();
            paint.Show();

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 1;
            progressBar1.Hide();
            button3.Enabled = false;
            analyse.Enabled = false;

            toolTip1.InitialDelay = 50;
            toolTip1.ReshowDelay = 0;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.SetToolTip(button1, "单击左键选择打开导航电文文件");
            toolTip1.SetToolTip(button2, "单击左键选择打开观测值文件");
            toolTip1.SetToolTip(button3, "单击左键开始解算");
            toolTip1.SetToolTip(button4, "单击左键清空");
            toolTip1.SetToolTip(analyse, "单击左键查看总体历元分析");
        }
    }
}
