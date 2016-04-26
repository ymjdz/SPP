using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinglePointPositioning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NameAndPassword namAndPass = new NameAndPassword();
        private void Form1_Load(object sender, EventArgs e)
        {
            namAndPass.LogIn();
            toolTip1.InitialDelay = 50;
            toolTip1.ReshowDelay = 0;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.SetToolTip(txtName, "单击<帮助>可获得用户名和密码");
            toolTip1.SetToolTip(txtPassword, "单击<帮助>可获得用户名和密码");
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            bool flag=false;
            string logName = txtName.Text;
            string logPass = txtPassword.Text;
            for (int i = 0; i < namAndPass.name.Length; i++)
            {
                if (logName==namAndPass.name[i]&&logPass==namAndPass.password[i])
                {
                    flag = true;
                    break;
                }
                else
                {
                    
                }//if
            }//for
            if (flag==true)
            {
                MessageBox.Show("登陆成功");
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                for (int i = 0; i < namAndPass.name.Length; i++)
                {
                    flag = logName == namAndPass.name[i];
                    if (flag==true)
                    {
                        break;
                    }
                }//for
                if (flag==true)
                {
                    passWrong.Text = "密码错误";
                }
                else
                {
                    nameWrong.Text = "用户名不存在";
                }//if
            }//if
        }

        private void reset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();
            nameWrong.Text = null;
            passWrong.Text = null;
            txtName.Focus();
        }

        private void linkLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
