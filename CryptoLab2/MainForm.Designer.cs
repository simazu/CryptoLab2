
namespace CryptoLab2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sequenceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sequencePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sequenceLabel = new System.Windows.Forms.Label();
            this.sequenceLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.getButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.decryptButton = new System.Windows.Forms.Button();
            this.testsOutputLabel = new System.Windows.Forms.Label();
            this.testsButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.testsOutputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sequencePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sequenceLengthNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sequenceRichTextBox
            // 
            this.sequenceRichTextBox.Location = new System.Drawing.Point(3, 19);
            this.sequenceRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sequenceRichTextBox.Name = "sequenceRichTextBox";
            this.sequenceRichTextBox.Size = new System.Drawing.Size(388, 323);
            this.sequenceRichTextBox.TabIndex = 0;
            this.sequenceRichTextBox.Text = "";
            // 
            // sequencePanel
            // 
            this.sequencePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.sequencePanel.Controls.Add(this.label1);
            this.sequencePanel.Controls.Add(this.comboBox1);
            this.sequencePanel.Controls.Add(this.sequenceLabel);
            this.sequencePanel.Controls.Add(this.sequenceLengthNumericUpDown);
            this.sequencePanel.Controls.Add(this.settingsLabel);
            this.sequencePanel.Controls.Add(this.getButton);
            this.sequencePanel.Controls.Add(this.sequenceRichTextBox);
            this.sequencePanel.Location = new System.Drawing.Point(12, 12);
            this.sequencePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sequencePanel.Name = "sequencePanel";
            this.sequencePanel.Size = new System.Drawing.Size(394, 400);
            this.sequencePanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Get sequence";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Random",
            "From file"});
            this.comboBox1.Location = new System.Drawing.Point(142, 346);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.AutoSize = true;
            this.sequenceLabel.Location = new System.Drawing.Point(3, 2);
            this.sequenceLabel.Name = "sequenceLabel";
            this.sequenceLabel.Size = new System.Drawing.Size(58, 15);
            this.sequenceLabel.TabIndex = 4;
            this.sequenceLabel.Text = "Sequence";
            // 
            // sequenceLengthNumericUpDown
            // 
            this.sequenceLengthNumericUpDown.Location = new System.Drawing.Point(142, 375);
            this.sequenceLengthNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sequenceLengthNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.sequenceLengthNumericUpDown.Name = "sequenceLengthNumericUpDown";
            this.sequenceLengthNumericUpDown.Size = new System.Drawing.Size(106, 23);
            this.sequenceLengthNumericUpDown.TabIndex = 3;
            this.sequenceLengthNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Location = new System.Drawing.Point(1, 377);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(135, 15);
            this.settingsLabel.TabIndex = 2;
            this.settingsLabel.Text = "L = 93, sequence length:";
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(268, 349);
            this.getButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(123, 49);
            this.getButton.TabIndex = 2;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.decryptButton);
            this.panel1.Controls.Add(this.testsOutputLabel);
            this.panel1.Controls.Add(this.testsButton);
            this.panel1.Controls.Add(this.encryptButton);
            this.panel1.Controls.Add(this.testsOutputRichTextBox);
            this.panel1.Location = new System.Drawing.Point(412, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 401);
            this.panel1.TabIndex = 2;
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(256, 350);
            this.decryptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(114, 49);
            this.decryptButton.TabIndex = 4;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // testsOutputLabel
            // 
            this.testsOutputLabel.AutoSize = true;
            this.testsOutputLabel.Location = new System.Drawing.Point(3, 1);
            this.testsOutputLabel.Name = "testsOutputLabel";
            this.testsOutputLabel.Size = new System.Drawing.Size(45, 15);
            this.testsOutputLabel.TabIndex = 3;
            this.testsOutputLabel.Text = "Output";
            // 
            // testsButton
            // 
            this.testsButton.Location = new System.Drawing.Point(5, 350);
            this.testsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testsButton.Name = "testsButton";
            this.testsButton.Size = new System.Drawing.Size(123, 49);
            this.testsButton.TabIndex = 2;
            this.testsButton.Text = "Test";
            this.testsButton.UseVisualStyleBackColor = true;
            this.testsButton.Click += new System.EventHandler(this.testsButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(134, 350);
            this.encryptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(116, 49);
            this.encryptButton.TabIndex = 2;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // testsOutputRichTextBox
            // 
            this.testsOutputRichTextBox.Location = new System.Drawing.Point(3, 17);
            this.testsOutputRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testsOutputRichTextBox.Name = "testsOutputRichTextBox";
            this.testsOutputRichTextBox.Size = new System.Drawing.Size(367, 326);
            this.testsOutputRichTextBox.TabIndex = 0;
            this.testsOutputRichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sequencePanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MSequence";
            this.sequencePanel.ResumeLayout(false);
            this.sequencePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sequenceLengthNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox sequenceRichTextBox;
        private System.Windows.Forms.Panel sequencePanel;
        private System.Windows.Forms.NumericUpDown sequenceLengthNumericUpDown;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label testsOutputLabel;
        private System.Windows.Forms.Button testsButton;
        private System.Windows.Forms.RichTextBox testsOutputRichTextBox;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

