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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemView));
            this.Buffs_lbox = new System.Windows.Forms.ListBox();
            this.Description_tbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_tbox = new System.Windows.Forms.TextBox();
            this.Type_tbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Give_BTN = new System.Windows.Forms.Button();
            this.GPlayers_lbox = new System.Windows.Forms.ComboBox();
            this.Refresh_BTN = new System.Windows.Forms.Button();
            this.Equip_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Buffs_lbox
            // 
            this.Buffs_lbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Buffs_lbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Buffs_lbox.FormattingEnabled = true;
            this.Buffs_lbox.Location = new System.Drawing.Point(12, 154);
            this.Buffs_lbox.Name = "Buffs_lbox";
            this.Buffs_lbox.ScrollAlwaysVisible = true;
            this.Buffs_lbox.Size = new System.Drawing.Size(240, 82);
            this.Buffs_lbox.TabIndex = 0;
            // 
            // Description_tbox
            // 
            this.Description_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Description_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Description_tbox.Location = new System.Drawing.Point(12, 71);
            this.Description_tbox.Multiline = true;
            this.Description_tbox.Name = "Description_tbox";
            this.Description_tbox.ReadOnly = true;
            this.Description_tbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description_tbox.Size = new System.Drawing.Size(240, 75);
            this.Description_tbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
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
            this.Name_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Name_tbox.Location = new System.Drawing.Point(52, 6);
            this.Name_tbox.Name = "Name_tbox";
            this.Name_tbox.ReadOnly = true;
            this.Name_tbox.Size = new System.Drawing.Size(200, 20);
            this.Name_tbox.TabIndex = 6;
            // 
            // Type_tbox
            // 
            this.Type_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Type_tbox.Location = new System.Drawing.Point(52, 32);
            this.Type_tbox.Name = "Type_tbox";
            this.Type_tbox.ReadOnly = true;
            this.Type_tbox.Size = new System.Drawing.Size(200, 20);
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
            // Give_BTN
            // 
            this.Give_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Give_BTN.Location = new System.Drawing.Point(157, 305);
            this.Give_BTN.Name = "Give_BTN";
            this.Give_BTN.Size = new System.Drawing.Size(95, 23);
            this.Give_BTN.TabIndex = 9;
            this.Give_BTN.Text = "Give";
            this.Give_BTN.UseVisualStyleBackColor = true;
            this.Give_BTN.Click += new System.EventHandler(this.Give_btn_Click);
            // 
            // GPlayers_lbox
            // 
            this.GPlayers_lbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GPlayers_lbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GPlayers_lbox.FormattingEnabled = true;
            this.GPlayers_lbox.Location = new System.Drawing.Point(12, 307);
            this.GPlayers_lbox.Name = "GPlayers_lbox";
            this.GPlayers_lbox.Size = new System.Drawing.Size(139, 21);
            this.GPlayers_lbox.TabIndex = 10;
            // 
            // Refresh_BTN
            // 
            this.Refresh_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Refresh_BTN.Location = new System.Drawing.Point(12, 334);
            this.Refresh_BTN.Name = "Refresh_BTN";
            this.Refresh_BTN.Size = new System.Drawing.Size(240, 23);
            this.Refresh_BTN.TabIndex = 11;
            this.Refresh_BTN.Text = "Refresh";
            this.Refresh_BTN.UseVisualStyleBackColor = true;
            this.Refresh_BTN.Click += new System.EventHandler(this.Refresh_BTN_Click);
            // 
            // Equip_btn
            // 
            this.Equip_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Equip_btn.Location = new System.Drawing.Point(12, 278);
            this.Equip_btn.Name = "Equip_btn";
            this.Equip_btn.Size = new System.Drawing.Size(240, 23);
            this.Equip_btn.TabIndex = 12;
            this.Equip_btn.Text = "Equip";
            this.Equip_btn.UseVisualStyleBackColor = true;
            this.Equip_btn.Click += new System.EventHandler(this.Equip_btn_Click);
            // 
            // ItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(264, 361);
            this.Controls.Add(this.Equip_btn);
            this.Controls.Add(this.Refresh_BTN);
            this.Controls.Add(this.GPlayers_lbox);
            this.Controls.Add(this.Give_BTN);
            this.Controls.Add(this.Type_tbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Name_tbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Description_tbox);
            this.Controls.Add(this.Buffs_lbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 250);
            this.Name = "ItemView";
            this.Text = "Item";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Item_FormClosing);
            this.Load += new System.EventHandler(this.Item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Buffs_lbox;
        private System.Windows.Forms.TextBox Description_tbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Name_tbox;
        private System.Windows.Forms.TextBox Type_tbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Give_BTN;
        private System.Windows.Forms.ComboBox GPlayers_lbox;
        private System.Windows.Forms.Button Refresh_BTN;
        private System.Windows.Forms.Button Equip_btn;
    }
}