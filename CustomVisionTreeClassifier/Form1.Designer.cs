namespace CustomVisionTreeClassifier
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.buttonUrl = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.buttonPSMode = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.radioButtonDetection = new System.Windows.Forms.RadioButton();
            this.radioButtonClassification = new System.Windows.Forms.RadioButton();
            this.labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(31, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 420);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(583, 303);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(194, 29);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonPaste
            // 
            this.buttonPaste.Location = new System.Drawing.Point(583, 348);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(194, 30);
            this.buttonPaste.TabIndex = 2;
            this.buttonPaste.Text = "Paste Image";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // buttonUrl
            // 
            this.buttonUrl.Location = new System.Drawing.Point(583, 394);
            this.buttonUrl.Name = "buttonUrl";
            this.buttonUrl.Size = new System.Drawing.Size(194, 28);
            this.buttonUrl.TabIndex = 4;
            this.buttonUrl.Text = "Paste Url";
            this.buttonUrl.UseVisualStyleBackColor = true;
            this.buttonUrl.Click += new System.EventHandler(this.buttonUrl_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.BackColor = System.Drawing.Color.Khaki;
            this.textBoxUrl.Location = new System.Drawing.Point(31, 12);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.ReadOnly = true;
            this.textBoxUrl.Size = new System.Drawing.Size(746, 20);
            this.textBoxUrl.TabIndex = 5;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(800, 127);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(206, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(895, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "10 %";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(583, 48);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(194, 239);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView1_ItemMouseHover);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "N";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Træart";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Probability, %";
            this.columnHeader3.Width = 90;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(429, 486);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.Visible = false;
            // 
            // buttonProcess
            // 
            this.buttonProcess.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonProcess.Location = new System.Drawing.Point(583, 439);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(194, 29);
            this.buttonProcess.TabIndex = 12;
            this.buttonProcess.Text = "Process Image";
            this.buttonProcess.UseVisualStyleBackColor = false;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxTag
            // 
            this.textBoxTag.Location = new System.Drawing.Point(63, 483);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(120, 20);
            this.textBoxTag.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tag";
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(203, 481);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTag.TabIndex = 15;
            this.buttonAddTag.Text = "Add Tag";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // buttonPSMode
            // 
            this.buttonPSMode.Location = new System.Drawing.Point(809, 303);
            this.buttonPSMode.Name = "buttonPSMode";
            this.buttonPSMode.Size = new System.Drawing.Size(180, 29);
            this.buttonPSMode.TabIndex = 16;
            this.buttonPSMode.Text = "Predict/Select Mode";
            this.buttonPSMode.UseVisualStyleBackColor = true;
            this.buttonPSMode.Click += new System.EventHandler(this.buttonPSMode_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(809, 394);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(180, 29);
            this.buttonSend.TabIndex = 17;
            this.buttonSend.Text = "Upload Image";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelStatus.Location = new System.Drawing.Point(821, 48);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(51, 20);
            this.labelStatus.TabIndex = 18;
            this.labelStatus.Text = "label3";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(809, 348);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(180, 30);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.Text = "Clear Selections";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Enabled = false;
            this.buttonTrain.Location = new System.Drawing.Point(809, 439);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(180, 28);
            this.buttonTrain.TabIndex = 20;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // radioButtonDetection
            // 
            this.radioButtonDetection.AutoSize = true;
            this.radioButtonDetection.Checked = true;
            this.radioButtonDetection.Location = new System.Drawing.Point(825, 207);
            this.radioButtonDetection.Name = "radioButtonDetection";
            this.radioButtonDetection.Size = new System.Drawing.Size(96, 17);
            this.radioButtonDetection.TabIndex = 21;
            this.radioButtonDetection.TabStop = true;
            this.radioButtonDetection.Text = "Tree Detection";
            this.radioButtonDetection.UseVisualStyleBackColor = true;
            this.radioButtonDetection.CheckedChanged += new System.EventHandler(this.radioButtonDetection_CheckedChanged);
            // 
            // radioButtonClassification
            // 
            this.radioButtonClassification.AutoSize = true;
            this.radioButtonClassification.Location = new System.Drawing.Point(825, 246);
            this.radioButtonClassification.Name = "radioButtonClassification";
            this.radioButtonClassification.Size = new System.Drawing.Size(111, 17);
            this.radioButtonClassification.TabIndex = 22;
            this.radioButtonClassification.Text = "Tree Classification";
            this.radioButtonClassification.UseVisualStyleBackColor = true;
            this.radioButtonClassification.CheckedChanged += new System.EventHandler(this.radioButtonClassification_CheckedChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(34, 54);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(35, 13);
            this.labelInfo.TabIndex = 23;
            this.labelInfo.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 514);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.radioButtonClassification);
            this.Controls.Add(this.radioButtonDetection);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonPSMode);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonUrl);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Tree scpecies";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.Button buttonUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonPSMode;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.RadioButton radioButtonDetection;
        private System.Windows.Forms.RadioButton radioButtonClassification;
        private System.Windows.Forms.Label labelInfo;
    }
}

