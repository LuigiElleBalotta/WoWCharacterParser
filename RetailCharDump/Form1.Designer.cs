namespace RetailCharDump
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SniffFileName = new System.Windows.Forms.TextBox();
            this.CharInfoRTB = new System.Windows.Forms.RichTextBox();
            this.ScanBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLBL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SqlOutRTB = new System.Windows.Forms.RichTextBox();
            this.GenSqlBTN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CharGuidTXT = new System.Windows.Forms.TextBox();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sniff Name:";
            // 
            // SniffFileName
            // 
            this.SniffFileName.Location = new System.Drawing.Point(74, 9);
            this.SniffFileName.Name = "SniffFileName";
            this.SniffFileName.Size = new System.Drawing.Size(137, 20);
            this.SniffFileName.TabIndex = 1;
            // 
            // CharInfoRTB
            // 
            this.CharInfoRTB.Location = new System.Drawing.Point(9, 79);
            this.CharInfoRTB.Name = "CharInfoRTB";
            this.CharInfoRTB.ReadOnly = true;
            this.CharInfoRTB.Size = new System.Drawing.Size(256, 169);
            this.CharInfoRTB.TabIndex = 2;
            this.CharInfoRTB.Text = "";
            // 
            // ScanBTN
            // 
            this.ScanBTN.Location = new System.Drawing.Point(217, 7);
            this.ScanBTN.Name = "ScanBTN";
            this.ScanBTN.Size = new System.Drawing.Size(48, 23);
            this.ScanBTN.TabIndex = 3;
            this.ScanBTN.Text = "SCAN";
            this.ScanBTN.UseVisualStyleBackColor = true;
            this.ScanBTN.Click += new System.EventHandler(this.ScanBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status:";
            // 
            // statusLBL
            // 
            this.statusLBL.AutoSize = true;
            this.statusLBL.Location = new System.Drawing.Point(52, 255);
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Size = new System.Drawing.Size(69, 13);
            this.statusLBL.TabIndex = 5;
            this.statusLBL.Text = "NO STATUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sniff Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "SCAN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ScanBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "NO STATUS";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(12, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(279, 304);
            this.tabControl2.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CharGuidTXT);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.SniffFileName);
            this.tabPage3.Controls.Add(this.statusLBL);
            this.tabPage3.Controls.Add(this.CharInfoRTB);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.ScanBTN);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(271, 278);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Input";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.GenSqlBTN);
            this.tabPage4.Controls.Add(this.SqlOutRTB);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(271, 278);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "SQL";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SqlOutRTB
            // 
            this.SqlOutRTB.Location = new System.Drawing.Point(7, 7);
            this.SqlOutRTB.Name = "SqlOutRTB";
            this.SqlOutRTB.Size = new System.Drawing.Size(258, 222);
            this.SqlOutRTB.TabIndex = 0;
            this.SqlOutRTB.Text = "";
            // 
            // GenSqlBTN
            // 
            this.GenSqlBTN.Location = new System.Drawing.Point(7, 236);
            this.GenSqlBTN.Name = "GenSqlBTN";
            this.GenSqlBTN.Size = new System.Drawing.Size(258, 36);
            this.GenSqlBTN.TabIndex = 1;
            this.GenSqlBTN.Text = "Create SQL File";
            this.GenSqlBTN.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Character GUID:";
            // 
            // CharGuidTXT
            // 
            this.CharGuidTXT.Location = new System.Drawing.Point(101, 43);
            this.CharGuidTXT.Name = "CharGuidTXT";
            this.CharGuidTXT.Size = new System.Drawing.Size(43, 20);
            this.CharGuidTXT.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 324);
            this.Controls.Add(this.tabControl2);
            this.Name = "Form1";
            this.Text = "RetailCharDump";
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SniffFileName;
        private System.Windows.Forms.RichTextBox CharInfoRTB;
        private System.Windows.Forms.Button ScanBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusLBL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button GenSqlBTN;
        private System.Windows.Forms.RichTextBox SqlOutRTB;
        private System.Windows.Forms.TextBox CharGuidTXT;
        private System.Windows.Forms.Label label6;
    }
}

