namespace Dungons_And_Dargons
{
    partial class PlayerView
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
            this.Refresh_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Inventory_lbox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Equipment_lbox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Spells_lbox = new System.Windows.Forms.ListBox();
            this.MP_pbar = new System.Windows.Forms.ProgressBar();
            this.HP_pbar = new System.Windows.Forms.ProgressBar();
            this.XP_pbar = new System.Windows.Forms.ProgressBar();
            this.label57 = new System.Windows.Forms.Label();
            this.Gold_tbox = new System.Windows.Forms.TextBox();
            this.Satiety_tbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.XP_lbl = new System.Windows.Forms.Label();
            this.PERC_tbox = new System.Windows.Forms.TextBox();
            this.INT_tbox = new System.Windows.Forms.TextBox();
            this.STR_tbox = new System.Windows.Forms.TextBox();
            this.DEX_tbox = new System.Windows.Forms.TextBox();
            this.CHAR_tbox = new System.Windows.Forms.TextBox();
            this.SDEF_tbox = new System.Windows.Forms.TextBox();
            this.DEF_tbox = new System.Windows.Forms.TextBox();
            this.SATK_tbox = new System.Windows.Forms.TextBox();
            this.ATK_tbox = new System.Windows.Forms.TextBox();
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
            this.MP_lbl = new System.Windows.Forms.Label();
            this.HP_lbl = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.Gold_UD = new System.Windows.Forms.NumericUpDown();
            this.XP_UD = new System.Windows.Forms.NumericUpDown();
            this.HP_UD = new System.Windows.Forms.NumericUpDown();
            this.MP_UD = new System.Windows.Forms.NumericUpDown();
            this.Plus_BTN = new System.Windows.Forms.Button();
            this.Minus_BTN = new System.Windows.Forms.Button();
            this.SET_BTN = new System.Windows.Forms.Button();
            this.M_PERC_tbox = new System.Windows.Forms.TextBox();
            this.M_INT_tbox = new System.Windows.Forms.TextBox();
            this.M_STR_tbox = new System.Windows.Forms.TextBox();
            this.M_DEX_tbox = new System.Windows.Forms.TextBox();
            this.M_CHAR_tbox = new System.Windows.Forms.TextBox();
            this.M_SDEF_tbox = new System.Windows.Forms.TextBox();
            this.M_DEF_tbox = new System.Windows.Forms.TextBox();
            this.M_SATK_tbox = new System.Windows.Forms.TextBox();
            this.M_ATK_tbox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gold_UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XP_UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP_UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MP_UD)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.Location = new System.Drawing.Point(4, 516);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(75, 23);
            this.Refresh_btn.TabIndex = 193;
            this.Refresh_btn.Text = "Refresh";
            this.Refresh_btn.UseVisualStyleBackColor = true;
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Inventory_lbox);
            this.groupBox1.Location = new System.Drawing.Point(287, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 338);
            this.groupBox1.TabIndex = 194;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory";
            // 
            // Inventory_lbox
            // 
            this.Inventory_lbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inventory_lbox.FormattingEnabled = true;
            this.Inventory_lbox.Location = new System.Drawing.Point(3, 16);
            this.Inventory_lbox.Name = "Inventory_lbox";
            this.Inventory_lbox.Size = new System.Drawing.Size(216, 319);
            this.Inventory_lbox.Sorted = true;
            this.Inventory_lbox.TabIndex = 1;
            this.Inventory_lbox.SelectedIndexChanged += new System.EventHandler(this.Inventory_lbox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Equipment_lbox);
            this.groupBox2.Location = new System.Drawing.Point(515, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 338);
            this.groupBox2.TabIndex = 195;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equiped";
            // 
            // Equipment_lbox
            // 
            this.Equipment_lbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Equipment_lbox.FormattingEnabled = true;
            this.Equipment_lbox.Location = new System.Drawing.Point(3, 16);
            this.Equipment_lbox.Name = "Equipment_lbox";
            this.Equipment_lbox.Size = new System.Drawing.Size(218, 319);
            this.Equipment_lbox.Sorted = true;
            this.Equipment_lbox.TabIndex = 2;
            this.Equipment_lbox.SelectedIndexChanged += new System.EventHandler(this.Equipment_lbox_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Spells_lbox);
            this.groupBox3.Location = new System.Drawing.Point(287, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 183);
            this.groupBox3.TabIndex = 195;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Spells";
            // 
            // Spells_lbox
            // 
            this.Spells_lbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spells_lbox.FormattingEnabled = true;
            this.Spells_lbox.Location = new System.Drawing.Point(3, 16);
            this.Spells_lbox.Name = "Spells_lbox";
            this.Spells_lbox.Size = new System.Drawing.Size(446, 164);
            this.Spells_lbox.Sorted = true;
            this.Spells_lbox.TabIndex = 2;
            this.Spells_lbox.SelectedIndexChanged += new System.EventHandler(this.Spells_lbox_SelectedIndexChanged);
            // 
            // MP_pbar
            // 
            this.MP_pbar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MP_pbar.ForeColor = System.Drawing.Color.SteelBlue;
            this.MP_pbar.Location = new System.Drawing.Point(8, 188);
            this.MP_pbar.Name = "MP_pbar";
            this.MP_pbar.Size = new System.Drawing.Size(164, 23);
            this.MP_pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MP_pbar.TabIndex = 248;
            // 
            // HP_pbar
            // 
            this.HP_pbar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.HP_pbar.ForeColor = System.Drawing.Color.LawnGreen;
            this.HP_pbar.Location = new System.Drawing.Point(8, 146);
            this.HP_pbar.Name = "HP_pbar";
            this.HP_pbar.Size = new System.Drawing.Size(164, 23);
            this.HP_pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.HP_pbar.TabIndex = 247;
            // 
            // XP_pbar
            // 
            this.XP_pbar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.XP_pbar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.XP_pbar.Location = new System.Drawing.Point(6, 104);
            this.XP_pbar.Name = "XP_pbar";
            this.XP_pbar.Size = new System.Drawing.Size(166, 23);
            this.XP_pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.XP_pbar.TabIndex = 246;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(12, 68);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(32, 13);
            this.label57.TabIndex = 245;
            this.label57.Text = "Gold:";
            // 
            // Gold_tbox
            // 
            this.Gold_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Gold_tbox.Enabled = false;
            this.Gold_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gold_tbox.ForeColor = System.Drawing.Color.Black;
            this.Gold_tbox.Location = new System.Drawing.Point(50, 63);
            this.Gold_tbox.Name = "Gold_tbox";
            this.Gold_tbox.Size = new System.Drawing.Size(122, 22);
            this.Gold_tbox.TabIndex = 244;
            // 
            // Satiety_tbox
            // 
            this.Satiety_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Satiety_tbox.Enabled = false;
            this.Satiety_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Satiety_tbox.ForeColor = System.Drawing.Color.Black;
            this.Satiety_tbox.Location = new System.Drawing.Point(50, 482);
            this.Satiety_tbox.Name = "Satiety_tbox";
            this.Satiety_tbox.Size = new System.Drawing.Size(122, 22);
            this.Satiety_tbox.TabIndex = 243;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 242;
            this.label7.Text = "SAT:";
            // 
            // XP_lbl
            // 
            this.XP_lbl.AutoSize = true;
            this.XP_lbl.BackColor = System.Drawing.SystemColors.Control;
            this.XP_lbl.Location = new System.Drawing.Point(6, 88);
            this.XP_lbl.Name = "XP_lbl";
            this.XP_lbl.Size = new System.Drawing.Size(24, 13);
            this.XP_lbl.TabIndex = 241;
            this.XP_lbl.Text = "XP:";
            this.XP_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PERC_tbox
            // 
            this.PERC_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PERC_tbox.Enabled = false;
            this.PERC_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PERC_tbox.ForeColor = System.Drawing.Color.Black;
            this.PERC_tbox.Location = new System.Drawing.Point(50, 454);
            this.PERC_tbox.Name = "PERC_tbox";
            this.PERC_tbox.Size = new System.Drawing.Size(61, 22);
            this.PERC_tbox.TabIndex = 240;
            // 
            // INT_tbox
            // 
            this.INT_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.INT_tbox.Enabled = false;
            this.INT_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INT_tbox.ForeColor = System.Drawing.Color.Black;
            this.INT_tbox.Location = new System.Drawing.Point(50, 426);
            this.INT_tbox.Name = "INT_tbox";
            this.INT_tbox.Size = new System.Drawing.Size(61, 22);
            this.INT_tbox.TabIndex = 239;
            // 
            // STR_tbox
            // 
            this.STR_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.STR_tbox.Enabled = false;
            this.STR_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STR_tbox.ForeColor = System.Drawing.Color.Black;
            this.STR_tbox.Location = new System.Drawing.Point(50, 398);
            this.STR_tbox.Name = "STR_tbox";
            this.STR_tbox.Size = new System.Drawing.Size(61, 22);
            this.STR_tbox.TabIndex = 238;
            // 
            // DEX_tbox
            // 
            this.DEX_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DEX_tbox.Enabled = false;
            this.DEX_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEX_tbox.ForeColor = System.Drawing.Color.Black;
            this.DEX_tbox.Location = new System.Drawing.Point(50, 370);
            this.DEX_tbox.Name = "DEX_tbox";
            this.DEX_tbox.Size = new System.Drawing.Size(61, 22);
            this.DEX_tbox.TabIndex = 237;
            // 
            // CHAR_tbox
            // 
            this.CHAR_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CHAR_tbox.Enabled = false;
            this.CHAR_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHAR_tbox.ForeColor = System.Drawing.Color.Black;
            this.CHAR_tbox.Location = new System.Drawing.Point(50, 342);
            this.CHAR_tbox.Name = "CHAR_tbox";
            this.CHAR_tbox.Size = new System.Drawing.Size(61, 22);
            this.CHAR_tbox.TabIndex = 236;
            // 
            // SDEF_tbox
            // 
            this.SDEF_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SDEF_tbox.Enabled = false;
            this.SDEF_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDEF_tbox.ForeColor = System.Drawing.Color.Black;
            this.SDEF_tbox.Location = new System.Drawing.Point(50, 314);
            this.SDEF_tbox.Name = "SDEF_tbox";
            this.SDEF_tbox.Size = new System.Drawing.Size(61, 22);
            this.SDEF_tbox.TabIndex = 235;
            // 
            // DEF_tbox
            // 
            this.DEF_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DEF_tbox.Enabled = false;
            this.DEF_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEF_tbox.ForeColor = System.Drawing.Color.Black;
            this.DEF_tbox.Location = new System.Drawing.Point(50, 286);
            this.DEF_tbox.Name = "DEF_tbox";
            this.DEF_tbox.Size = new System.Drawing.Size(61, 22);
            this.DEF_tbox.TabIndex = 234;
            // 
            // SATK_tbox
            // 
            this.SATK_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SATK_tbox.Enabled = false;
            this.SATK_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SATK_tbox.ForeColor = System.Drawing.Color.Black;
            this.SATK_tbox.Location = new System.Drawing.Point(50, 258);
            this.SATK_tbox.Name = "SATK_tbox";
            this.SATK_tbox.Size = new System.Drawing.Size(61, 22);
            this.SATK_tbox.TabIndex = 233;
            // 
            // ATK_tbox
            // 
            this.ATK_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ATK_tbox.Enabled = false;
            this.ATK_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ATK_tbox.ForeColor = System.Drawing.Color.Black;
            this.ATK_tbox.Location = new System.Drawing.Point(50, 230);
            this.ATK_tbox.Name = "ATK_tbox";
            this.ATK_tbox.Size = new System.Drawing.Size(61, 22);
            this.ATK_tbox.TabIndex = 232;
            // 
            // LVL_tbox
            // 
            this.LVL_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LVL_tbox.Enabled = false;
            this.LVL_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVL_tbox.ForeColor = System.Drawing.Color.Black;
            this.LVL_tbox.Location = new System.Drawing.Point(50, 35);
            this.LVL_tbox.Name = "LVL_tbox";
            this.LVL_tbox.Size = new System.Drawing.Size(122, 22);
            this.LVL_tbox.TabIndex = 231;
            // 
            // Name_tbox
            // 
            this.Name_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name_tbox.Enabled = false;
            this.Name_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_tbox.ForeColor = System.Drawing.Color.Black;
            this.Name_tbox.Location = new System.Drawing.Point(50, 7);
            this.Name_tbox.Name = "Name_tbox";
            this.Name_tbox.Size = new System.Drawing.Size(122, 22);
            this.Name_tbox.TabIndex = 230;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 229;
            this.label16.Text = "LVL:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 459);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 228;
            this.label17.Text = "PERC:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 431);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 227;
            this.label18.Text = "INT:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 403);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 226;
            this.label19.Text = "STR:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 375);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 225;
            this.label20.Text = "DEX:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 347);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 224;
            this.label21.Text = "CHAR:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 319);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 223;
            this.label22.Text = "S-DEF:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 291);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 222;
            this.label23.Text = "DEF:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 263);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 221;
            this.label24.Text = "S-ATK:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 235);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 13);
            this.label25.TabIndex = 220;
            this.label25.Text = "ATK:";
            // 
            // MP_lbl
            // 
            this.MP_lbl.AutoEllipsis = true;
            this.MP_lbl.AutoSize = true;
            this.MP_lbl.Location = new System.Drawing.Point(6, 172);
            this.MP_lbl.Name = "MP_lbl";
            this.MP_lbl.Size = new System.Drawing.Size(26, 13);
            this.MP_lbl.TabIndex = 219;
            this.MP_lbl.Text = "MP:";
            this.MP_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HP_lbl
            // 
            this.HP_lbl.AutoSize = true;
            this.HP_lbl.Location = new System.Drawing.Point(6, 130);
            this.HP_lbl.Name = "HP_lbl";
            this.HP_lbl.Size = new System.Drawing.Size(25, 13);
            this.HP_lbl.TabIndex = 218;
            this.HP_lbl.Text = "HP:";
            this.HP_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 12);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 13);
            this.label28.TabIndex = 217;
            this.label28.Text = "Name:";
            // 
            // Gold_UD
            // 
            this.Gold_UD.Location = new System.Drawing.Point(178, 66);
            this.Gold_UD.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.Gold_UD.Name = "Gold_UD";
            this.Gold_UD.Size = new System.Drawing.Size(103, 20);
            this.Gold_UD.TabIndex = 259;
            // 
            // XP_UD
            // 
            this.XP_UD.Location = new System.Drawing.Point(178, 107);
            this.XP_UD.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.XP_UD.Name = "XP_UD";
            this.XP_UD.Size = new System.Drawing.Size(100, 20);
            this.XP_UD.TabIndex = 260;
            // 
            // HP_UD
            // 
            this.HP_UD.Location = new System.Drawing.Point(178, 146);
            this.HP_UD.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.HP_UD.Name = "HP_UD";
            this.HP_UD.Size = new System.Drawing.Size(100, 20);
            this.HP_UD.TabIndex = 261;
            // 
            // MP_UD
            // 
            this.MP_UD.Location = new System.Drawing.Point(178, 188);
            this.MP_UD.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
            this.MP_UD.Name = "MP_UD";
            this.MP_UD.Size = new System.Drawing.Size(100, 20);
            this.MP_UD.TabIndex = 262;
            // 
            // Plus_BTN
            // 
            this.Plus_BTN.Location = new System.Drawing.Point(178, 214);
            this.Plus_BTN.Name = "Plus_BTN";
            this.Plus_BTN.Size = new System.Drawing.Size(25, 23);
            this.Plus_BTN.TabIndex = 263;
            this.Plus_BTN.Text = "+";
            this.Plus_BTN.UseVisualStyleBackColor = true;
            this.Plus_BTN.Click += new System.EventHandler(this.Plus_BTN_Click);
            // 
            // Minus_BTN
            // 
            this.Minus_BTN.Location = new System.Drawing.Point(209, 214);
            this.Minus_BTN.Name = "Minus_BTN";
            this.Minus_BTN.Size = new System.Drawing.Size(25, 23);
            this.Minus_BTN.TabIndex = 264;
            this.Minus_BTN.Text = "-";
            this.Minus_BTN.UseVisualStyleBackColor = true;
            this.Minus_BTN.Click += new System.EventHandler(this.Minus_BTN_Click);
            // 
            // SET_BTN
            // 
            this.SET_BTN.Location = new System.Drawing.Point(240, 214);
            this.SET_BTN.Name = "SET_BTN";
            this.SET_BTN.Size = new System.Drawing.Size(25, 23);
            this.SET_BTN.TabIndex = 265;
            this.SET_BTN.Text = "S";
            this.SET_BTN.UseVisualStyleBackColor = true;
            this.SET_BTN.Click += new System.EventHandler(this.SET_BTN_Click);
            // 
            // M_PERC_tbox
            // 
            this.M_PERC_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_PERC_tbox.Enabled = false;
            this.M_PERC_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_PERC_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_PERC_tbox.Location = new System.Drawing.Point(117, 454);
            this.M_PERC_tbox.Name = "M_PERC_tbox";
            this.M_PERC_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_PERC_tbox.TabIndex = 274;
            // 
            // M_INT_tbox
            // 
            this.M_INT_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_INT_tbox.Enabled = false;
            this.M_INT_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_INT_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_INT_tbox.Location = new System.Drawing.Point(117, 426);
            this.M_INT_tbox.Name = "M_INT_tbox";
            this.M_INT_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_INT_tbox.TabIndex = 273;
            // 
            // M_STR_tbox
            // 
            this.M_STR_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_STR_tbox.Enabled = false;
            this.M_STR_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_STR_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_STR_tbox.Location = new System.Drawing.Point(117, 398);
            this.M_STR_tbox.Name = "M_STR_tbox";
            this.M_STR_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_STR_tbox.TabIndex = 272;
            // 
            // M_DEX_tbox
            // 
            this.M_DEX_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_DEX_tbox.Enabled = false;
            this.M_DEX_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_DEX_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_DEX_tbox.Location = new System.Drawing.Point(117, 370);
            this.M_DEX_tbox.Name = "M_DEX_tbox";
            this.M_DEX_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_DEX_tbox.TabIndex = 271;
            // 
            // M_CHAR_tbox
            // 
            this.M_CHAR_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_CHAR_tbox.Enabled = false;
            this.M_CHAR_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_CHAR_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_CHAR_tbox.Location = new System.Drawing.Point(117, 342);
            this.M_CHAR_tbox.Name = "M_CHAR_tbox";
            this.M_CHAR_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_CHAR_tbox.TabIndex = 270;
            // 
            // M_SDEF_tbox
            // 
            this.M_SDEF_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_SDEF_tbox.Enabled = false;
            this.M_SDEF_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_SDEF_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_SDEF_tbox.Location = new System.Drawing.Point(117, 314);
            this.M_SDEF_tbox.Name = "M_SDEF_tbox";
            this.M_SDEF_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_SDEF_tbox.TabIndex = 269;
            // 
            // M_DEF_tbox
            // 
            this.M_DEF_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_DEF_tbox.Enabled = false;
            this.M_DEF_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_DEF_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_DEF_tbox.Location = new System.Drawing.Point(117, 286);
            this.M_DEF_tbox.Name = "M_DEF_tbox";
            this.M_DEF_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_DEF_tbox.TabIndex = 268;
            // 
            // M_SATK_tbox
            // 
            this.M_SATK_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_SATK_tbox.Enabled = false;
            this.M_SATK_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_SATK_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_SATK_tbox.Location = new System.Drawing.Point(117, 258);
            this.M_SATK_tbox.Name = "M_SATK_tbox";
            this.M_SATK_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_SATK_tbox.TabIndex = 267;
            // 
            // M_ATK_tbox
            // 
            this.M_ATK_tbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.M_ATK_tbox.Enabled = false;
            this.M_ATK_tbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_ATK_tbox.ForeColor = System.Drawing.Color.Black;
            this.M_ATK_tbox.Location = new System.Drawing.Point(117, 230);
            this.M_ATK_tbox.Name = "M_ATK_tbox";
            this.M_ATK_tbox.Size = new System.Drawing.Size(55, 22);
            this.M_ATK_tbox.TabIndex = 266;
            // 
            // PlayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 551);
            this.Controls.Add(this.M_PERC_tbox);
            this.Controls.Add(this.M_INT_tbox);
            this.Controls.Add(this.M_STR_tbox);
            this.Controls.Add(this.M_DEX_tbox);
            this.Controls.Add(this.M_CHAR_tbox);
            this.Controls.Add(this.M_SDEF_tbox);
            this.Controls.Add(this.M_DEF_tbox);
            this.Controls.Add(this.M_SATK_tbox);
            this.Controls.Add(this.M_ATK_tbox);
            this.Controls.Add(this.SET_BTN);
            this.Controls.Add(this.Minus_BTN);
            this.Controls.Add(this.Plus_BTN);
            this.Controls.Add(this.MP_UD);
            this.Controls.Add(this.HP_UD);
            this.Controls.Add(this.XP_UD);
            this.Controls.Add(this.Gold_UD);
            this.Controls.Add(this.MP_pbar);
            this.Controls.Add(this.HP_pbar);
            this.Controls.Add(this.XP_pbar);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.Gold_tbox);
            this.Controls.Add(this.Satiety_tbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.XP_lbl);
            this.Controls.Add(this.PERC_tbox);
            this.Controls.Add(this.INT_tbox);
            this.Controls.Add(this.STR_tbox);
            this.Controls.Add(this.DEX_tbox);
            this.Controls.Add(this.CHAR_tbox);
            this.Controls.Add(this.SDEF_tbox);
            this.Controls.Add(this.DEF_tbox);
            this.Controls.Add(this.SATK_tbox);
            this.Controls.Add(this.ATK_tbox);
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
            this.Controls.Add(this.MP_lbl);
            this.Controls.Add(this.HP_lbl);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Refresh_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerView";
            this.Text = "THING";
            this.Load += new System.EventHandler(this.Player_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gold_UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XP_UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HP_UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MP_UD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Refresh_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox Inventory_lbox;
        private System.Windows.Forms.ListBox Equipment_lbox;
        private System.Windows.Forms.ListBox Spells_lbox;
        private System.Windows.Forms.ProgressBar MP_pbar;
        private System.Windows.Forms.ProgressBar HP_pbar;
        private System.Windows.Forms.ProgressBar XP_pbar;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox Gold_tbox;
        private System.Windows.Forms.TextBox Satiety_tbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label XP_lbl;
        private System.Windows.Forms.TextBox PERC_tbox;
        private System.Windows.Forms.TextBox INT_tbox;
        private System.Windows.Forms.TextBox STR_tbox;
        private System.Windows.Forms.TextBox DEX_tbox;
        private System.Windows.Forms.TextBox CHAR_tbox;
        private System.Windows.Forms.TextBox SDEF_tbox;
        private System.Windows.Forms.TextBox DEF_tbox;
        private System.Windows.Forms.TextBox SATK_tbox;
        private System.Windows.Forms.TextBox ATK_tbox;
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
        private System.Windows.Forms.Label MP_lbl;
        private System.Windows.Forms.Label HP_lbl;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown Gold_UD;
        private System.Windows.Forms.NumericUpDown XP_UD;
        private System.Windows.Forms.NumericUpDown HP_UD;
        private System.Windows.Forms.NumericUpDown MP_UD;
        private System.Windows.Forms.Button Plus_BTN;
        private System.Windows.Forms.Button Minus_BTN;
        private System.Windows.Forms.Button SET_BTN;
        private System.Windows.Forms.TextBox M_PERC_tbox;
        private System.Windows.Forms.TextBox M_INT_tbox;
        private System.Windows.Forms.TextBox M_STR_tbox;
        private System.Windows.Forms.TextBox M_DEX_tbox;
        private System.Windows.Forms.TextBox M_CHAR_tbox;
        private System.Windows.Forms.TextBox M_SDEF_tbox;
        private System.Windows.Forms.TextBox M_DEF_tbox;
        private System.Windows.Forms.TextBox M_SATK_tbox;
        private System.Windows.Forms.TextBox M_ATK_tbox;
    }
}