namespace Dungons_And_Dargons
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Name_tbox = new System.Windows.Forms.TextBox();
            this.Pass_tbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Login_btn = new System.Windows.Forms.Button();
            this.Log_lbox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbpassword_tbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ip_tbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Name_tbox
            // 
            this.Name_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Name_tbox.Location = new System.Drawing.Point(89, 64);
            this.Name_tbox.Name = "Name_tbox";
            this.Name_tbox.Size = new System.Drawing.Size(107, 20);
            this.Name_tbox.TabIndex = 2;
            this.Name_tbox.TextChanged += new System.EventHandler(this.Name_tbox_TextChanged);
            // 
            // Pass_tbox
            // 
            this.Pass_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pass_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Pass_tbox.Location = new System.Drawing.Point(89, 90);
            this.Pass_tbox.Name = "Pass_tbox";
            this.Pass_tbox.Size = new System.Drawing.Size(107, 20);
            this.Pass_tbox.TabIndex = 3;
            this.Pass_tbox.UseSystemPasswordChar = true;
            this.Pass_tbox.TextChanged += new System.EventHandler(this.Pass_tbox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Login_btn
            // 
            this.Login_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Login_btn.Location = new System.Drawing.Point(0, 138);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(434, 23);
            this.Login_btn.TabIndex = 4;
            this.Login_btn.Text = "Login";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // Log_lbox
            // 
            this.Log_lbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Log_lbox.FormattingEnabled = true;
            this.Log_lbox.Location = new System.Drawing.Point(202, 5);
            this.Log_lbox.Name = "Log_lbox";
            this.Log_lbox.Size = new System.Drawing.Size(232, 121);
            this.Log_lbox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "DB password:";
            // 
            // dbpassword_tbox
            // 
            this.dbpassword_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbpassword_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dbpassword_tbox.Location = new System.Drawing.Point(89, 38);
            this.dbpassword_tbox.Name = "dbpassword_tbox";
            this.dbpassword_tbox.Size = new System.Drawing.Size(107, 20);
            this.dbpassword_tbox.TabIndex = 1;
            this.dbpassword_tbox.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "IP:";
            // 
            // ip_tbox
            // 
            this.ip_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ip_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ip_tbox.Location = new System.Drawing.Point(89, 12);
            this.ip_tbox.Name = "ip_tbox";
            this.ip_tbox.Size = new System.Drawing.Size(107, 20);
            this.ip_tbox.TabIndex = 0;
            // 
            // Main
            // 
            this.AcceptButton = this.Login_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ip_tbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dbpassword_tbox);
            this.Controls.Add(this.Log_lbox);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pass_tbox);
            this.Controls.Add(this.Name_tbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "Main";
            this.Text = "Dungons And Dargons";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_tbox;
        private System.Windows.Forms.TextBox Pass_tbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.ListBox Log_lbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dbpassword_tbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ip_tbox;
    }
}

