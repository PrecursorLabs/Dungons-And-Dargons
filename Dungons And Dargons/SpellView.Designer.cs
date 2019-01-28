namespace Dungons_And_Dargons
{
    partial class SpellView
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
            this.Refresh_BTN = new System.Windows.Forms.Button();
            this.Name_tbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Description_tbox = new System.Windows.Forms.TextBox();
            this.Buffs_lbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Refresh_BTN
            // 
            this.Refresh_BTN.Location = new System.Drawing.Point(12, 355);
            this.Refresh_BTN.Name = "Refresh_BTN";
            this.Refresh_BTN.Size = new System.Drawing.Size(240, 23);
            this.Refresh_BTN.TabIndex = 16;
            this.Refresh_BTN.Text = "Refresh";
            this.Refresh_BTN.UseVisualStyleBackColor = true;
            this.Refresh_BTN.Click += new System.EventHandler(this.Refresh_BTN_Click);
            // 
            // Name_tbox
            // 
            this.Name_tbox.Location = new System.Drawing.Point(52, 6);
            this.Name_tbox.Name = "Name_tbox";
            this.Name_tbox.ReadOnly = true;
            this.Name_tbox.Size = new System.Drawing.Size(200, 20);
            this.Name_tbox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Description:";
            // 
            // Description_tbox
            // 
            this.Description_tbox.Location = new System.Drawing.Point(12, 45);
            this.Description_tbox.Multiline = true;
            this.Description_tbox.Name = "Description_tbox";
            this.Description_tbox.ReadOnly = true;
            this.Description_tbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description_tbox.Size = new System.Drawing.Size(240, 151);
            this.Description_tbox.TabIndex = 12;
            // 
            // Buffs_lbox
            // 
            this.Buffs_lbox.FormattingEnabled = true;
            this.Buffs_lbox.Location = new System.Drawing.Point(12, 202);
            this.Buffs_lbox.Name = "Buffs_lbox";
            this.Buffs_lbox.ScrollAlwaysVisible = true;
            this.Buffs_lbox.Size = new System.Drawing.Size(240, 147);
            this.Buffs_lbox.TabIndex = 17;
            // 
            // SpellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 384);
            this.Controls.Add(this.Buffs_lbox);
            this.Controls.Add(this.Refresh_BTN);
            this.Controls.Add(this.Name_tbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Description_tbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpellView";
            this.Text = "SpellView";
            this.Load += new System.EventHandler(this.SpellView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Refresh_BTN;
        private System.Windows.Forms.TextBox Name_tbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Description_tbox;
        private System.Windows.Forms.ListBox Buffs_lbox;
    }
}