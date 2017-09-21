namespace GPSSampler
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStriplbelStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCont = new System.Windows.Forms.Label();
            this.cBoxAqType = new System.Windows.Forms.ComboBox();
            this.btonAcquisition = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tboxReadData = new System.Windows.Forms.TextBox();
            this.tmerGeneral = new System.Windows.Forms.Timer(this.components);
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.timerWatch = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriplbelStatus1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(687, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStriplbelStatus1
            // 
            this.toolStriplbelStatus1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStriplbelStatus1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStriplbelStatus1.Name = "toolStriplbelStatus1";
            this.toolStriplbelStatus1.Size = new System.Drawing.Size(119, 17);
            this.toolStriplbelStatus1.Text = "USB : Desconectado";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 467);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelCont);
            this.groupBox1.Controls.Add(this.cBoxAqType);
            this.groupBox1.Controls.Add(this.btonAcquisition);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 461);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelTM
            // 
            this.labelTM.AutoSize = true;
            this.labelTM.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTM.Location = new System.Drawing.Point(233, 124);
            this.labelTM.Name = "labelTM";
            this.labelTM.Size = new System.Drawing.Size(30, 33);
            this.labelTM.TabIndex = 6;
            this.labelTM.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cont pct:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cronômetro (s):";
            // 
            // labelCont
            // 
            this.labelCont.AutoSize = true;
            this.labelCont.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCont.Location = new System.Drawing.Point(125, 181);
            this.labelCont.Name = "labelCont";
            this.labelCont.Size = new System.Drawing.Size(30, 33);
            this.labelCont.TabIndex = 3;
            this.labelCont.Text = "0";
            // 
            // cBoxAqType
            // 
            this.cBoxAqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAqType.FormattingEnabled = true;
            this.cBoxAqType.Items.AddRange(new object[] {
            "Analógico",
            "MAXIM"});
            this.cBoxAqType.Location = new System.Drawing.Point(121, 20);
            this.cBoxAqType.Name = "cBoxAqType";
            this.cBoxAqType.Size = new System.Drawing.Size(109, 21);
            this.cBoxAqType.TabIndex = 1;
            this.cBoxAqType.SelectedIndexChanged += new System.EventHandler(this.cBoxAqType_SelectedIndexChanged);
            // 
            // btonAcquisition
            // 
            this.btonAcquisition.Enabled = false;
            this.btonAcquisition.Location = new System.Drawing.Point(9, 19);
            this.btonAcquisition.Name = "btonAcquisition";
            this.btonAcquisition.Size = new System.Drawing.Size(75, 23);
            this.btonAcquisition.TabIndex = 0;
            this.btonAcquisition.Text = "START";
            this.btonAcquisition.UseVisualStyleBackColor = true;
            this.btonAcquisition.Click += new System.EventHandler(this.btonAcquisition_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tboxReadData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(346, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 461);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tboxReadData
            // 
            this.tboxReadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxReadData.Location = new System.Drawing.Point(3, 16);
            this.tboxReadData.Multiline = true;
            this.tboxReadData.Name = "tboxReadData";
            this.tboxReadData.ReadOnly = true;
            this.tboxReadData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxReadData.Size = new System.Drawing.Size(332, 442);
            this.tboxReadData.TabIndex = 0;
            // 
            // tmerGeneral
            // 
            this.tmerGeneral.Interval = 300;
            this.tmerGeneral.Tick += new System.EventHandler(this.tmerGeneral_Tick);
            // 
            // timerRead
            // 
            this.timerRead.Interval = 1;
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // timerWatch
            // 
            this.timerWatch.Interval = 1000;
            this.timerWatch.Tick += new System.EventHandler(this.timerWatch_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 513);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "GPS Sampler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btonAcquisition;
        private System.Windows.Forms.TextBox tboxReadData;
        private System.Windows.Forms.ComboBox cBoxAqType;
        private System.Windows.Forms.Timer tmerGeneral;
        private System.Windows.Forms.ToolStripStatusLabel toolStriplbelStatus1;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCont;
        private System.Windows.Forms.Timer timerWatch;
        private System.Windows.Forms.Label labelTM;
    }
}

