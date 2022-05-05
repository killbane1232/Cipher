namespace WinForm
{
    partial class Form1
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
            this.AlgoName = new System.Windows.Forms.ComboBox();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.AlgoBox = new System.Windows.Forms.GroupBox();
            this.MoveButton = new System.Windows.Forms.Button();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.AlgoBox.SuspendLayout();
            this.InputGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlgoName
            // 
            this.AlgoName.FormattingEnabled = true;
            this.AlgoName.Items.AddRange(new object[] {
            "Shannon-Fano",
            "Huffman",
            "Arithmetic",
            "LZ77",
            "LZ78",
            "BWT&RLE"});
            this.AlgoName.Location = new System.Drawing.Point(6, 22);
            this.AlgoName.Name = "AlgoName";
            this.AlgoName.Size = new System.Drawing.Size(164, 23);
            this.AlgoName.TabIndex = 0;
            this.AlgoName.Text = "Choose Algorithm";
            this.AlgoName.SelectedIndexChanged += new System.EventHandler(this.AlgoName_SelectedIndexChanged);
            // 
            // EncodeButton
            // 
            this.EncodeButton.Location = new System.Drawing.Point(176, 21);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(75, 23);
            this.EncodeButton.TabIndex = 1;
            this.EncodeButton.Text = "Encode";
            this.EncodeButton.UseVisualStyleBackColor = true;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // DecodeButton
            // 
            this.DecodeButton.Location = new System.Drawing.Point(257, 21);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(75, 23);
            this.DecodeButton.TabIndex = 2;
            this.DecodeButton.Text = "Decode";
            this.DecodeButton.UseVisualStyleBackColor = true;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // AlgoBox
            // 
            this.AlgoBox.Controls.Add(this.MoveButton);
            this.AlgoBox.Controls.Add(this.AlgoName);
            this.AlgoBox.Controls.Add(this.DecodeButton);
            this.AlgoBox.Controls.Add(this.EncodeButton);
            this.AlgoBox.Location = new System.Drawing.Point(12, 12);
            this.AlgoBox.Name = "AlgoBox";
            this.AlgoBox.Size = new System.Drawing.Size(776, 58);
            this.AlgoBox.TabIndex = 3;
            this.AlgoBox.TabStop = false;
            this.AlgoBox.Text = "Algorithm";
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(338, 21);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(114, 23);
            this.MoveButton.TabIndex = 3;
            this.MoveButton.Text = "Output => Input";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.OpenFileButton);
            this.InputGroupBox.Controls.Add(this.InputTextBox);
            this.InputGroupBox.Location = new System.Drawing.Point(12, 76);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(380, 362);
            this.InputGroupBox.TabIndex = 4;
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.Text = "Input";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(6, 328);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 1;
            this.OpenFileButton.Text = "Open";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(6, 22);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(368, 300);
            this.InputTextBox.TabIndex = 0;
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.SaveButton);
            this.OutputGroupBox.Controls.Add(this.OutputTextBox);
            this.OutputGroupBox.Location = new System.Drawing.Point(408, 76);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(380, 362);
            this.OutputGroupBox.TabIndex = 5;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(6, 328);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(6, 22);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(368, 300);
            this.OutputTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.AlgoBox);
            this.Name = "Form1";
            this.Text = "TK_labs";
            this.AlgoBox.ResumeLayout(false);
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AlgoName;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.GroupBox AlgoBox;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button MoveButton;
    }
}
