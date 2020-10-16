namespace FontWorx
{
    partial class ByteGenerator
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.doubleArrayRadio = new System.Windows.Forms.RadioButton();
            this.singleArrayRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveToFileRadio = new System.Windows.Forms.RadioButton();
            this.copyToClipboardRadio = new System.Windows.Forms.RadioButton();
            this.variableName = new System.Windows.Forms.TextBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.doubleArrayRadio);
            this.groupBox1.Controls.Add(this.singleArrayRadio);
            this.groupBox1.Location = new System.Drawing.Point(155, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Array Style";
            // 
            // doubleArrayRadio
            // 
            this.doubleArrayRadio.AutoSize = true;
            this.doubleArrayRadio.Checked = true;
            this.doubleArrayRadio.Location = new System.Drawing.Point(12, 42);
            this.doubleArrayRadio.Name = "doubleArrayRadio";
            this.doubleArrayRadio.Size = new System.Drawing.Size(86, 17);
            this.doubleArrayRadio.TabIndex = 1;
            this.doubleArrayRadio.TabStop = true;
            this.doubleArrayRadio.Text = "Double Array";
            this.doubleArrayRadio.UseVisualStyleBackColor = true;
            // 
            // singleArrayRadio
            // 
            this.singleArrayRadio.AutoSize = true;
            this.singleArrayRadio.Location = new System.Drawing.Point(12, 19);
            this.singleArrayRadio.Name = "singleArrayRadio";
            this.singleArrayRadio.Size = new System.Drawing.Size(81, 17);
            this.singleArrayRadio.TabIndex = 0;
            this.singleArrayRadio.Text = "Single Array";
            this.singleArrayRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveToFileRadio);
            this.groupBox2.Controls.Add(this.copyToClipboardRadio);
            this.groupBox2.Location = new System.Drawing.Point(15, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Method";
            // 
            // saveToFileRadio
            // 
            this.saveToFileRadio.AutoSize = true;
            this.saveToFileRadio.Enabled = false;
            this.saveToFileRadio.Location = new System.Drawing.Point(12, 42);
            this.saveToFileRadio.Name = "saveToFileRadio";
            this.saveToFileRadio.Size = new System.Drawing.Size(86, 17);
            this.saveToFileRadio.TabIndex = 1;
            this.saveToFileRadio.Text = "Save to TXT";
            this.saveToFileRadio.UseVisualStyleBackColor = true;
            // 
            // copyToClipboardRadio
            // 
            this.copyToClipboardRadio.AutoSize = true;
            this.copyToClipboardRadio.Checked = true;
            this.copyToClipboardRadio.Location = new System.Drawing.Point(12, 19);
            this.copyToClipboardRadio.Name = "copyToClipboardRadio";
            this.copyToClipboardRadio.Size = new System.Drawing.Size(112, 17);
            this.copyToClipboardRadio.TabIndex = 0;
            this.copyToClipboardRadio.TabStop = true;
            this.copyToClipboardRadio.Text = "Copy To Clipboard";
            this.copyToClipboardRadio.UseVisualStyleBackColor = true;
            // 
            // variableName
            // 
            this.variableName.Location = new System.Drawing.Point(97, 39);
            this.variableName.Name = "variableName";
            this.variableName.Size = new System.Drawing.Size(168, 20);
            this.variableName.TabIndex = 3;
            this.variableName.Text = "MyFont";
            // 
            // fileName
            // 
            this.fileName.Enabled = false;
            this.fileName.Location = new System.Drawing.Point(97, 13);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(168, 20);
            this.fileName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Variable Name:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(271, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ByteGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 156);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.variableName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ByteGenerator";
            this.Text = "Pixel Grinder";
            this.Load += new System.EventHandler(this.ByteGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton doubleArrayRadio;
        private System.Windows.Forms.RadioButton singleArrayRadio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton saveToFileRadio;
        private System.Windows.Forms.RadioButton copyToClipboardRadio;
        private System.Windows.Forms.TextBox variableName;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}