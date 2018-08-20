namespace Dungons_And_Dargons
{
    partial class User
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
            this.components = new System.ComponentModel.Container();
            this.Log_lbox = new System.Windows.Forms.ListBox();
            this.HP_tbox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.XP_tbox = new System.Windows.Forms.TextBox();
            this.PERC_tbox = new System.Windows.Forms.TextBox();
            this.INT_tbox = new System.Windows.Forms.TextBox();
            this.STR_tbox = new System.Windows.Forms.TextBox();
            this.DEX_tbox = new System.Windows.Forms.TextBox();
            this.CHAR_tbox = new System.Windows.Forms.TextBox();
            this.SDEF_tbox = new System.Windows.Forms.TextBox();
            this.DEF_tbox = new System.Windows.Forms.TextBox();
            this.SATK_tbox = new System.Windows.Forms.TextBox();
            this.ATK_tbox = new System.Windows.Forms.TextBox();
            this.MMP_tbox = new System.Windows.Forms.TextBox();
            this.MHP_tbox = new System.Windows.Forms.TextBox();
            this.LVL_tbox = new System.Windows.Forms.TextBox();
            this.Name_tbox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.Update_timer = new System.Windows.Forms.Timer(this.components);
            this.Main_tabs = new System.Windows.Forms.TabControl();
            this.Events_tab = new System.Windows.Forms.TabPage();
            this.Equipment_tab = new System.Windows.Forms.TabPage();
            this.MP_tbox = new System.Windows.Forms.TextBox();
            this.Inventory_tab = new System.Windows.Forms.TabPage();
            this.Spells_tab = new System.Windows.Forms.TabPage();
            this.GameMaster_tab = new System.Windows.Forms.TabPage();
            this.Inventory_lbox = new System.Windows.Forms.ListBox();
            this.UPDATE_btn = new System.Windows.Forms.Button();
            this.Combat_tbox = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Main_tabs.SuspendLayout();
            this.Inventory_tab.SuspendLayout();
            this.GameMaster_tab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Log_lbox
            // 
            this.Log_lbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Log_lbox.FormattingEnabled = true;
            this.Log_lbox.Location = new System.Drawing.Point(12, 344);
            this.Log_lbox.Name = "Log_lbox";
            this.Log_lbox.Size = new System.Drawing.Size(166, 173);
            this.Log_lbox.TabIndex = 6;
            this.Log_lbox.SelectedIndexChanged += new System.EventHandler(this.Log_lbox_SelectedIndexChanged);
            // 
            // HP_tbox
            // 
            this.HP_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.HP_tbox.Enabled = false;
            this.HP_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HP_tbox.ForeColor = System.Drawing.Color.Black;
            this.HP_tbox.Location = new System.Drawing.Point(56, 54);
            this.HP_tbox.Name = "HP_tbox";
            this.HP_tbox.Size = new System.Drawing.Size(58, 22);
            this.HP_tbox.TabIndex = 106;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(354, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 13);
            this.label30.TabIndex = 105;
            this.label30.Text = "XP:";
            // 
            // XP_tbox
            // 
            this.XP_tbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.XP_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.XP_tbox.Enabled = false;
            this.XP_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XP_tbox.ForeColor = System.Drawing.Color.Black;
            this.XP_tbox.Location = new System.Drawing.Point(384, 6);
            this.XP_tbox.Name = "XP_tbox";
            this.XP_tbox.Size = new System.Drawing.Size(70, 22);
            this.XP_tbox.TabIndex = 104;
            // 
            // PERC_tbox
            // 
            this.PERC_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PERC_tbox.Enabled = false;
            this.PERC_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PERC_tbox.ForeColor = System.Drawing.Color.Black;
            this.PERC_tbox.Location = new System.Drawing.Point(56, 316);
            this.PERC_tbox.Name = "PERC_tbox";
            this.PERC_tbox.Size = new System.Drawing.Size(122, 22);
            this.PERC_tbox.TabIndex = 103;
            // 
            // INT_tbox
            // 
            this.INT_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.INT_tbox.Enabled = false;
            this.INT_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INT_tbox.ForeColor = System.Drawing.Color.Black;
            this.INT_tbox.Location = new System.Drawing.Point(56, 290);
            this.INT_tbox.Name = "INT_tbox";
            this.INT_tbox.Size = new System.Drawing.Size(122, 22);
            this.INT_tbox.TabIndex = 102;
            // 
            // STR_tbox
            // 
            this.STR_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.STR_tbox.Enabled = false;
            this.STR_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STR_tbox.ForeColor = System.Drawing.Color.Black;
            this.STR_tbox.Location = new System.Drawing.Point(56, 264);
            this.STR_tbox.Name = "STR_tbox";
            this.STR_tbox.Size = new System.Drawing.Size(122, 22);
            this.STR_tbox.TabIndex = 101;
            // 
            // DEX_tbox
            // 
            this.DEX_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DEX_tbox.Enabled = false;
            this.DEX_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEX_tbox.ForeColor = System.Drawing.Color.Black;
            this.DEX_tbox.Location = new System.Drawing.Point(56, 238);
            this.DEX_tbox.Name = "DEX_tbox";
            this.DEX_tbox.Size = new System.Drawing.Size(122, 22);
            this.DEX_tbox.TabIndex = 100;
            // 
            // CHAR_tbox
            // 
            this.CHAR_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CHAR_tbox.Enabled = false;
            this.CHAR_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHAR_tbox.ForeColor = System.Drawing.Color.Black;
            this.CHAR_tbox.Location = new System.Drawing.Point(56, 212);
            this.CHAR_tbox.Name = "CHAR_tbox";
            this.CHAR_tbox.Size = new System.Drawing.Size(122, 22);
            this.CHAR_tbox.TabIndex = 99;
            // 
            // SDEF_tbox
            // 
            this.SDEF_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SDEF_tbox.Enabled = false;
            this.SDEF_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDEF_tbox.ForeColor = System.Drawing.Color.Black;
            this.SDEF_tbox.Location = new System.Drawing.Point(56, 186);
            this.SDEF_tbox.Name = "SDEF_tbox";
            this.SDEF_tbox.Size = new System.Drawing.Size(122, 22);
            this.SDEF_tbox.TabIndex = 98;
            // 
            // DEF_tbox
            // 
            this.DEF_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DEF_tbox.Enabled = false;
            this.DEF_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEF_tbox.ForeColor = System.Drawing.Color.Black;
            this.DEF_tbox.Location = new System.Drawing.Point(56, 160);
            this.DEF_tbox.Name = "DEF_tbox";
            this.DEF_tbox.Size = new System.Drawing.Size(122, 22);
            this.DEF_tbox.TabIndex = 97;
            // 
            // SATK_tbox
            // 
            this.SATK_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SATK_tbox.Enabled = false;
            this.SATK_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SATK_tbox.ForeColor = System.Drawing.Color.Black;
            this.SATK_tbox.Location = new System.Drawing.Point(56, 134);
            this.SATK_tbox.Name = "SATK_tbox";
            this.SATK_tbox.Size = new System.Drawing.Size(122, 22);
            this.SATK_tbox.TabIndex = 96;
            // 
            // ATK_tbox
            // 
            this.ATK_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ATK_tbox.Enabled = false;
            this.ATK_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ATK_tbox.ForeColor = System.Drawing.Color.Black;
            this.ATK_tbox.Location = new System.Drawing.Point(56, 109);
            this.ATK_tbox.Name = "ATK_tbox";
            this.ATK_tbox.Size = new System.Drawing.Size(122, 22);
            this.ATK_tbox.TabIndex = 95;
            // 
            // MMP_tbox
            // 
            this.MMP_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MMP_tbox.Enabled = false;
            this.MMP_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MMP_tbox.ForeColor = System.Drawing.Color.Black;
            this.MMP_tbox.Location = new System.Drawing.Point(120, 82);
            this.MMP_tbox.Name = "MMP_tbox";
            this.MMP_tbox.Size = new System.Drawing.Size(58, 22);
            this.MMP_tbox.TabIndex = 94;
            // 
            // MHP_tbox
            // 
            this.MHP_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MHP_tbox.Enabled = false;
            this.MHP_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MHP_tbox.ForeColor = System.Drawing.Color.Black;
            this.MHP_tbox.Location = new System.Drawing.Point(120, 54);
            this.MHP_tbox.Name = "MHP_tbox";
            this.MHP_tbox.Size = new System.Drawing.Size(58, 22);
            this.MHP_tbox.TabIndex = 93;
            // 
            // LVL_tbox
            // 
            this.LVL_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LVL_tbox.Enabled = false;
            this.LVL_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVL_tbox.ForeColor = System.Drawing.Color.Black;
            this.LVL_tbox.Location = new System.Drawing.Point(56, 30);
            this.LVL_tbox.Name = "LVL_tbox";
            this.LVL_tbox.Size = new System.Drawing.Size(122, 22);
            this.LVL_tbox.TabIndex = 92;
            // 
            // Name_tbox
            // 
            this.Name_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name_tbox.Enabled = false;
            this.Name_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_tbox.ForeColor = System.Drawing.Color.Black;
            this.Name_tbox.Location = new System.Drawing.Point(56, 6);
            this.Name_tbox.Name = "Name_tbox";
            this.Name_tbox.Size = new System.Drawing.Size(122, 22);
            this.Name_tbox.TabIndex = 91;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 90;
            this.label16.Text = "LVL:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 319);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 89;
            this.label17.Text = "PERC:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 293);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 88;
            this.label18.Text = "INT:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 267);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 87;
            this.label19.Text = "STR:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 241);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 86;
            this.label20.Text = "DEX:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 215);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 85;
            this.label21.Text = "CHAR:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 189);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 84;
            this.label22.Text = "S-DEF:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 163);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 83;
            this.label23.Text = "DEF:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 137);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 82;
            this.label24.Text = "S-ATK:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(19, 111);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 13);
            this.label25.TabIndex = 81;
            this.label25.Text = "ATK:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(24, 85);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(26, 13);
            this.label26.TabIndex = 80;
            this.label26.Text = "MP:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(25, 59);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(25, 13);
            this.label27.TabIndex = 79;
            this.label27.Text = "HP:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 13);
            this.label28.TabIndex = 78;
            this.label28.Text = "Name:";
            // 
            // Update_timer
            // 
            this.Update_timer.Enabled = true;
            this.Update_timer.Interval = 6000;
            this.Update_timer.Tick += new System.EventHandler(this.Update_timer_Tick);
            // 
            // Main_tabs
            // 
            this.Main_tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_tabs.Controls.Add(this.Events_tab);
            this.Main_tabs.Controls.Add(this.Equipment_tab);
            this.Main_tabs.Controls.Add(this.Inventory_tab);
            this.Main_tabs.Controls.Add(this.Spells_tab);
            this.Main_tabs.Controls.Add(this.Combat_tbox);
            this.Main_tabs.Controls.Add(this.GameMaster_tab);
            this.Main_tabs.Location = new System.Drawing.Point(184, 34);
            this.Main_tabs.Name = "Main_tabs";
            this.Main_tabs.SelectedIndex = 0;
            this.Main_tabs.Size = new System.Drawing.Size(768, 517);
            this.Main_tabs.TabIndex = 107;
            // 
            // Events_tab
            // 
            this.Events_tab.Location = new System.Drawing.Point(4, 22);
            this.Events_tab.Name = "Events_tab";
            this.Events_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Events_tab.Size = new System.Drawing.Size(760, 491);
            this.Events_tab.TabIndex = 0;
            this.Events_tab.Text = "Events";
            this.Events_tab.UseVisualStyleBackColor = true;
            // 
            // Equipment_tab
            // 
            this.Equipment_tab.Location = new System.Drawing.Point(4, 22);
            this.Equipment_tab.Name = "Equipment_tab";
            this.Equipment_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Equipment_tab.Size = new System.Drawing.Size(760, 491);
            this.Equipment_tab.TabIndex = 1;
            this.Equipment_tab.Text = "Equipment";
            this.Equipment_tab.UseVisualStyleBackColor = true;
            // 
            // MP_tbox
            // 
            this.MP_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MP_tbox.Enabled = false;
            this.MP_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MP_tbox.ForeColor = System.Drawing.Color.Black;
            this.MP_tbox.Location = new System.Drawing.Point(56, 81);
            this.MP_tbox.Name = "MP_tbox";
            this.MP_tbox.Size = new System.Drawing.Size(58, 22);
            this.MP_tbox.TabIndex = 108;
            // 
            // Inventory_tab
            // 
            this.Inventory_tab.Controls.Add(this.Inventory_lbox);
            this.Inventory_tab.Location = new System.Drawing.Point(4, 22);
            this.Inventory_tab.Name = "Inventory_tab";
            this.Inventory_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Inventory_tab.Size = new System.Drawing.Size(760, 491);
            this.Inventory_tab.TabIndex = 2;
            this.Inventory_tab.Text = "Inventory";
            this.Inventory_tab.UseVisualStyleBackColor = true;
            // 
            // Spells_tab
            // 
            this.Spells_tab.Location = new System.Drawing.Point(4, 22);
            this.Spells_tab.Name = "Spells_tab";
            this.Spells_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Spells_tab.Size = new System.Drawing.Size(760, 491);
            this.Spells_tab.TabIndex = 3;
            this.Spells_tab.Text = "Spells";
            this.Spells_tab.UseVisualStyleBackColor = true;
            // 
            // GameMaster_tab
            // 
            this.GameMaster_tab.Controls.Add(this.tabControl1);
            this.GameMaster_tab.Location = new System.Drawing.Point(4, 22);
            this.GameMaster_tab.Name = "GameMaster_tab";
            this.GameMaster_tab.Padding = new System.Windows.Forms.Padding(3);
            this.GameMaster_tab.Size = new System.Drawing.Size(760, 491);
            this.GameMaster_tab.TabIndex = 4;
            this.GameMaster_tab.Text = "GameMaster";
            this.GameMaster_tab.UseVisualStyleBackColor = true;
            // 
            // Inventory_lbox
            // 
            this.Inventory_lbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inventory_lbox.FormattingEnabled = true;
            this.Inventory_lbox.Location = new System.Drawing.Point(3, 3);
            this.Inventory_lbox.Name = "Inventory_lbox";
            this.Inventory_lbox.Size = new System.Drawing.Size(754, 485);
            this.Inventory_lbox.TabIndex = 0;
            this.Inventory_lbox.SelectedIndexChanged += new System.EventHandler(this.Inventory_lbox_SelectedIndexChanged);
            // 
            // UPDATE_btn
            // 
            this.UPDATE_btn.Location = new System.Drawing.Point(12, 528);
            this.UPDATE_btn.Name = "UPDATE_btn";
            this.UPDATE_btn.Size = new System.Drawing.Size(75, 23);
            this.UPDATE_btn.TabIndex = 1;
            this.UPDATE_btn.Text = "Update";
            this.UPDATE_btn.UseVisualStyleBackColor = true;
            this.UPDATE_btn.Click += new System.EventHandler(this.UPDATE_btn_Click);
            // 
            // Combat_tbox
            // 
            this.Combat_tbox.Location = new System.Drawing.Point(4, 22);
            this.Combat_tbox.Name = "Combat_tbox";
            this.Combat_tbox.Padding = new System.Windows.Forms.Padding(3);
            this.Combat_tbox.Size = new System.Drawing.Size(760, 491);
            this.Combat_tbox.TabIndex = 5;
            this.Combat_tbox.Text = "Combat";
            this.Combat_tbox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(486, 119);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(8, 8);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // User
            // 
            this.AccessibleName = "UserForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 555);
            this.Controls.Add(this.UPDATE_btn);
            this.Controls.Add(this.MP_tbox);
            this.Controls.Add(this.Main_tabs);
            this.Controls.Add(this.HP_tbox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.XP_tbox);
            this.Controls.Add(this.PERC_tbox);
            this.Controls.Add(this.INT_tbox);
            this.Controls.Add(this.STR_tbox);
            this.Controls.Add(this.DEX_tbox);
            this.Controls.Add(this.CHAR_tbox);
            this.Controls.Add(this.SDEF_tbox);
            this.Controls.Add(this.DEF_tbox);
            this.Controls.Add(this.SATK_tbox);
            this.Controls.Add(this.ATK_tbox);
            this.Controls.Add(this.MMP_tbox);
            this.Controls.Add(this.MHP_tbox);
            this.Controls.Add(this.LVL_tbox);
            this.Controls.Add(this.Name_tbox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.Log_lbox);
            this.Name = "User";
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            this.Main_tabs.ResumeLayout(false);
            this.Inventory_tab.ResumeLayout(false);
            this.GameMaster_tab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Log_lbox;
        private System.Windows.Forms.TextBox HP_tbox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox XP_tbox;
        private System.Windows.Forms.TextBox PERC_tbox;
        private System.Windows.Forms.TextBox INT_tbox;
        private System.Windows.Forms.TextBox STR_tbox;
        private System.Windows.Forms.TextBox DEX_tbox;
        private System.Windows.Forms.TextBox CHAR_tbox;
        private System.Windows.Forms.TextBox SDEF_tbox;
        private System.Windows.Forms.TextBox DEF_tbox;
        private System.Windows.Forms.TextBox SATK_tbox;
        private System.Windows.Forms.TextBox ATK_tbox;
        private System.Windows.Forms.TextBox MMP_tbox;
        private System.Windows.Forms.TextBox MHP_tbox;
        private System.Windows.Forms.TextBox LVL_tbox;
        private System.Windows.Forms.TextBox Name_tbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Timer Update_timer;
        private System.Windows.Forms.TabControl Main_tabs;
        private System.Windows.Forms.TabPage Events_tab;
        private System.Windows.Forms.TabPage Equipment_tab;
        private System.Windows.Forms.TextBox MP_tbox;
        private System.Windows.Forms.TabPage Inventory_tab;
        private System.Windows.Forms.ListBox Inventory_lbox;
        private System.Windows.Forms.TabPage Spells_tab;
        private System.Windows.Forms.TabPage GameMaster_tab;
        private System.Windows.Forms.Button UPDATE_btn;
        private System.Windows.Forms.TabPage Combat_tbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}