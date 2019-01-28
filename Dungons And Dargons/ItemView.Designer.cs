namespace Dungons_And_Dargons
{
    partial class ItemView
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
            this.Buffs_lbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Description_tbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_tbox = new System.Windows.Forms.TextBox();
            this.Type_tbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Give_btn = new System.Windows.Forms.Button();
            this.GPlayers_lbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Buffs_lbox
            // 
            this.Buffs_lbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Buffs_lbox.FormattingEnabled = true;
            this.Buffs_lbox.Location = new System.Drawing.Point(12, 220);
            this.Buffs_lbox.Name = "Buffs_lbox";
            this.Buffs_lbox.Size = new System.Drawing.Size(207, 82);
            this.Buffs_lbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buffs:";
            // 
            // Description_tbox
            // 
            this.Description_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Description_tbox.Enabled = false;
            this.Description_tbox.Location = new System.Drawing.Point(12, 80);
            this.Description_tbox.Multiline = true;
            this.Description_tbox.Name = "Description_tbox";
            this.Description_tbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Description_tbox.Size = new System.Drawing.Size(207, 121);
            this.Description_tbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // Name_tbox
            // 
            this.Name_tbox.Enabled = false;
            this.Name_tbox.Location = new System.Drawing.Point(52, 6);
            this.Name_tbox.Name = "Name_tbox";
            this.Name_tbox.Size = new System.Drawing.Size(167, 20);
            this.Name_tbox.TabIndex = 6;
            // 
            // Type_tbox
            // 
            this.Type_tbox.Enabled = false;
            this.Type_tbox.Location = new System.Drawing.Point(52, 32);
            this.Type_tbox.Name = "Type_tbox";
            this.Type_tbox.Size = new System.Drawing.Size(167, 20);
            this.Type_tbox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type:";
            // 
            // Give_btn
            // 
            this.Give_btn.Location = new System.Drawing.Point(144, 308);
            this.Give_btn.Name = "Give_btn";
            this.Give_btn.Size = new System.Drawing.Size(75, 23);
            this.Give_btn.TabIndex = 9;
            this.Give_btn.Text = "Give";
            this.Give_btn.UseVisualStyleBackColor = true;
            this.Give_btn.Click += new System.EventHandler(this.Give_btn_Click);
            // 
            // GPlayers_lbox
            // 
            this.GPlayers_lbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GPlayers_lbox.FormattingEnabled = true;
            this.GPlayers_lbox.Location = new System.Drawing.Point(17, 310);
            this.GPlayers_lbox.Name = "GPlayers_lbox";
            this.GPlayers_lbox.Size = new System.Drawing.Size(121, 21);
            this.GPlayers_lbox.TabIndex = 10;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 340);
            this.Controls.Add(this.GPlayers_lbox);
            this.Controls.Add(this.Give_btn);
            this.Controls.Add(this.Type_tbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Name_tbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Description_tbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buffs_lbox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(247, 379);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(247, 379);
            this.Name = "Item";
            this.Text = "Item";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Item_FormClosing);
            this.Load += new System.EventHandler(this.Item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Buffs_lbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Description_tbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Name_tbox;
        private System.Windows.Forms.TextBox Type_tbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Give_btn;
        private System.Windows.Forms.ComboBox GPlayers_lbox;
    }
}