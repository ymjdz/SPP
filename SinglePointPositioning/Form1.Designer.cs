namespace SinglePointPositioning
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.name = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.reset = new System.Windows.Forms.Button();
            this.logIn = new System.Windows.Forms.Button();
            this.nameWrong = new System.Windows.Forms.Label();
            this.passWrong = new System.Windows.Forms.Label();
            this.linkLab = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(106, 85);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(82, 24);
            this.name.TabIndex = 0;
            this.name.Text = "用户名";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(130, 181);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(58, 24);
            this.password.TabIndex = 1;
            this.password.Text = "密码";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(194, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 35);
            this.txtName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(194, 178);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(270, 35);
            this.txtPassword.TabIndex = 3;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(150, 266);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(130, 50);
            this.reset.TabIndex = 4;
            this.reset.Text = "重新输入";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // logIn
            // 
            this.logIn.Location = new System.Drawing.Point(348, 266);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(110, 50);
            this.logIn.TabIndex = 5;
            this.logIn.Text = "登录";
            this.logIn.UseVisualStyleBackColor = true;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // nameWrong
            // 
            this.nameWrong.AutoSize = true;
            this.nameWrong.ForeColor = System.Drawing.Color.Red;
            this.nameWrong.Location = new System.Drawing.Point(470, 93);
            this.nameWrong.Name = "nameWrong";
            this.nameWrong.Size = new System.Drawing.Size(0, 24);
            this.nameWrong.TabIndex = 6;
            // 
            // passWrong
            // 
            this.passWrong.AutoSize = true;
            this.passWrong.ForeColor = System.Drawing.Color.Red;
            this.passWrong.Location = new System.Drawing.Point(470, 189);
            this.passWrong.Name = "passWrong";
            this.passWrong.Size = new System.Drawing.Size(0, 24);
            this.passWrong.TabIndex = 7;
            // 
            // linkLab
            // 
            this.linkLab.AutoSize = true;
            this.linkLab.Location = new System.Drawing.Point(564, 384);
            this.linkLab.Name = "linkLab";
            this.linkLab.Size = new System.Drawing.Size(58, 24);
            this.linkLab.TabIndex = 8;
            this.linkLab.TabStop = true;
            this.linkLab.Text = "帮助";
            this.linkLab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLab_LinkClicked);
            // 
            // Form1
            // 
            this.AcceptButton = this.logIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 417);
            this.Controls.Add(this.linkLab);
            this.Controls.Add(this.passWrong);
            this.Controls.Add(this.nameWrong);
            this.Controls.Add(this.logIn);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.password);
            this.Controls.Add(this.name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button logIn;
        private System.Windows.Forms.Label nameWrong;
        private System.Windows.Forms.Label passWrong;
        private System.Windows.Forms.LinkLabel linkLab;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

