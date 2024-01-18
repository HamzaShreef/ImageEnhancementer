namespace UI
{
    partial class mainForm
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
            panel1 = new Panel();
            imgBoxOutput = new PictureBox();
            pnl_chart_output = new Panel();
            pnl_chart_input = new Panel();
            imgBoxInput = new PictureBox();
            cmboTechnique = new ComboBox();
            btnApply = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            txtImagePath = new TextBox();
            label2 = new Label();
            btnBrowseImage = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgBoxOutput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgBoxInput).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(57, 57, 57);
            panel1.Controls.Add(imgBoxOutput);
            panel1.Controls.Add(pnl_chart_output);
            panel1.Location = new Point(905, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(561, 802);
            panel1.TabIndex = 2;
            // 
            // imgBoxOutput
            // 
            imgBoxOutput.BackColor = Color.FromArgb(57, 57, 57);
            imgBoxOutput.BorderStyle = BorderStyle.FixedSingle;
            imgBoxOutput.Location = new Point(13, 12);
            imgBoxOutput.Name = "imgBoxOutput";
            imgBoxOutput.Size = new Size(532, 500);
            imgBoxOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBoxOutput.TabIndex = 0;
            imgBoxOutput.TabStop = false;
            // 
            // pnl_chart_output
            // 
            pnl_chart_output.BackColor = Color.FromArgb(57, 57, 57);
            pnl_chart_output.BorderStyle = BorderStyle.FixedSingle;
            pnl_chart_output.Location = new Point(13, 523);
            pnl_chart_output.Name = "pnl_chart_output";
            pnl_chart_output.Size = new Size(532, 273);
            pnl_chart_output.TabIndex = 1;
            // 
            // pnl_chart_input
            // 
            pnl_chart_input.BorderStyle = BorderStyle.FixedSingle;
            pnl_chart_input.Location = new Point(12, 533);
            pnl_chart_input.Name = "pnl_chart_input";
            pnl_chart_input.Size = new Size(532, 273);
            pnl_chart_input.TabIndex = 1;
            // 
            // imgBoxInput
            // 
            imgBoxInput.BorderStyle = BorderStyle.FixedSingle;
            imgBoxInput.Location = new Point(12, 12);
            imgBoxInput.Name = "imgBoxInput";
            imgBoxInput.Size = new Size(532, 500);
            imgBoxInput.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBoxInput.TabIndex = 0;
            imgBoxInput.TabStop = false;
            // 
            // cmboTechnique
            // 
            cmboTechnique.DropDownStyle = ComboBoxStyle.DropDownList;
            cmboTechnique.FormattingEnabled = true;
            cmboTechnique.Items.AddRange(new object[] { "Histogram Equalization", "Convolution" });
            cmboTechnique.Location = new Point(3, 60);
            cmboTechnique.Name = "cmboTechnique";
            cmboTechnique.Size = new Size(342, 28);
            cmboTechnique.TabIndex = 3;
            // 
            // btnApply
            // 
            btnApply.Cursor = Cursors.Hand;
            btnApply.Location = new Point(3, 233);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(348, 29);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 15);
            label1.Name = "label1";
            label1.Size = new Size(350, 31);
            label1.TabIndex = 5;
            label1.Text = "choose enchancement technique";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGreen;
            panel2.Controls.Add(cmboTechnique);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnApply);
            panel2.Location = new Point(551, 532);
            panel2.Name = "panel2";
            panel2.Size = new Size(348, 267);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Controls.Add(txtImagePath);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnBrowseImage);
            panel3.Location = new Point(550, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 137);
            panel3.TabIndex = 7;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(13, 99);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(329, 27);
            txtImagePath.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 15);
            label2.Name = "label2";
            label2.Size = new Size(193, 31);
            label2.TabIndex = 5;
            label2.Text = "choose image file";
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Cursor = Cursors.Hand;
            btnBrowseImage.Location = new Point(13, 60);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(329, 29);
            btnBrowseImage.TabIndex = 4;
            btnBrowseImage.Text = "Browse Image";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 57, 57);
            ClientSize = new Size(1473, 820);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnl_chart_input);
            Controls.Add(imgBoxInput);
            MaximizeBox = false;
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mainForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgBoxOutput).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgBoxInput).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureBox imgBoxOutput;
        private Panel pnl_chart_output;
        private Panel pnl_chart_input;
        private PictureBox imgBoxInput;
        private ComboBox cmboTechnique;
        private Button btnApply;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Button btnBrowseImage;
        private TextBox txtImagePath;
    }
}