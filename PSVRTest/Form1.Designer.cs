namespace PSVRTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelByteOffset = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.trackBar15 = new System.Windows.Forms.TrackBar();
            this.trackBar14 = new System.Windows.Forms.TrackBar();
            this.trackBar13 = new System.Windows.Forms.TrackBar();
            this.trackBar16 = new System.Windows.Forms.TrackBar();
            this.trackBar17 = new System.Windows.Forms.TrackBar();
            this.trackBar18 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar18)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(346, 27);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(128, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(346, 65);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(128, 23);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelByteOffset);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(10, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1185, 396);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HID Report";
            // 
            // labelByteOffset
            // 
            this.labelByteOffset.AutoSize = true;
            this.labelByteOffset.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelByteOffset.Location = new System.Drawing.Point(11, 14);
            this.labelByteOffset.Name = "labelByteOffset";
            this.labelByteOffset.Size = new System.Drawing.Size(1153, 13);
            this.labelByteOffset.TabIndex = 8;
            this.labelByteOffset.Text = "00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 " +
    "27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53" +
    " 54 55 56 57 58 59 60 61 62 63";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1163, 355);
            this.listBox1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stateTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 404);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateTextBox.Location = new System.Drawing.Point(9, 18);
            this.stateTextBox.Multiline = true;
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(285, 375);
            this.stateTextBox.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(334, 94);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 293);
            this.textBox3.TabIndex = 4;
            this.textBox3.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(603, 27);
            this.trackBar1.Maximum = 32767;
            this.trackBar1.Minimum = -32767;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(240, 45);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickFrequency = 0;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(603, 65);
            this.trackBar2.Maximum = 32767;
            this.trackBar2.Minimum = -32767;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(240, 45);
            this.trackBar2.TabIndex = 14;
            this.trackBar2.TickFrequency = 0;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(603, 100);
            this.trackBar3.Maximum = 32767;
            this.trackBar3.Minimum = -32767;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(240, 45);
            this.trackBar3.TabIndex = 15;
            this.trackBar3.TickFrequency = 0;
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(603, 133);
            this.trackBar4.Maximum = 32767;
            this.trackBar4.Minimum = -32767;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(240, 45);
            this.trackBar4.TabIndex = 16;
            this.trackBar4.TickFrequency = 0;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(603, 177);
            this.trackBar5.Maximum = 32767;
            this.trackBar5.Minimum = -32767;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(240, 45);
            this.trackBar5.TabIndex = 17;
            this.trackBar5.TickFrequency = 0;
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(603, 210);
            this.trackBar6.Maximum = 32767;
            this.trackBar6.Minimum = -32767;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(240, 45);
            this.trackBar6.TabIndex = 18;
            this.trackBar6.TickFrequency = 0;
            // 
            // trackBar9
            // 
            this.trackBar9.Location = new System.Drawing.Point(603, 328);
            this.trackBar9.Maximum = 32767;
            this.trackBar9.Minimum = -32767;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Size = new System.Drawing.Size(240, 45);
            this.trackBar9.TabIndex = 21;
            this.trackBar9.TickFrequency = 0;
            // 
            // trackBar8
            // 
            this.trackBar8.Location = new System.Drawing.Point(603, 295);
            this.trackBar8.Maximum = 32767;
            this.trackBar8.Minimum = -32767;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(240, 45);
            this.trackBar8.TabIndex = 20;
            this.trackBar8.TickFrequency = 0;
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(603, 244);
            this.trackBar7.Maximum = 32767;
            this.trackBar7.Minimum = -32767;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(240, 45);
            this.trackBar7.TabIndex = 19;
            this.trackBar7.TickFrequency = 0;
            // 
            // trackBar12
            // 
            this.trackBar12.Location = new System.Drawing.Point(942, 132);
            this.trackBar12.Maximum = 32767;
            this.trackBar12.Minimum = -32767;
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(240, 45);
            this.trackBar12.TabIndex = 24;
            this.trackBar12.TickFrequency = 0;
            // 
            // trackBar11
            // 
            this.trackBar11.Location = new System.Drawing.Point(942, 99);
            this.trackBar11.Maximum = 32767;
            this.trackBar11.Minimum = -32767;
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Size = new System.Drawing.Size(240, 45);
            this.trackBar11.TabIndex = 23;
            this.trackBar11.TickFrequency = 0;
            // 
            // trackBar10
            // 
            this.trackBar10.Location = new System.Drawing.Point(942, 65);
            this.trackBar10.Maximum = 32767;
            this.trackBar10.Minimum = -32767;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Size = new System.Drawing.Size(240, 45);
            this.trackBar10.TabIndex = 22;
            this.trackBar10.TickFrequency = 0;
            // 
            // trackBar15
            // 
            this.trackBar15.Location = new System.Drawing.Point(942, 243);
            this.trackBar15.Maximum = 32767;
            this.trackBar15.Minimum = -32767;
            this.trackBar15.Name = "trackBar15";
            this.trackBar15.Size = new System.Drawing.Size(240, 45);
            this.trackBar15.TabIndex = 27;
            this.trackBar15.TickFrequency = 0;
            // 
            // trackBar14
            // 
            this.trackBar14.Location = new System.Drawing.Point(942, 210);
            this.trackBar14.Maximum = 32767;
            this.trackBar14.Minimum = -32767;
            this.trackBar14.Name = "trackBar14";
            this.trackBar14.Size = new System.Drawing.Size(240, 45);
            this.trackBar14.TabIndex = 26;
            this.trackBar14.TickFrequency = 0;
            // 
            // trackBar13
            // 
            this.trackBar13.Location = new System.Drawing.Point(942, 176);
            this.trackBar13.Maximum = 32767;
            this.trackBar13.Minimum = -32767;
            this.trackBar13.Name = "trackBar13";
            this.trackBar13.Size = new System.Drawing.Size(240, 45);
            this.trackBar13.TabIndex = 25;
            this.trackBar13.TickFrequency = 0;
            // 
            // trackBar16
            // 
            this.trackBar16.Enabled = false;
            this.trackBar16.Location = new System.Drawing.Point(943, 361);
            this.trackBar16.Maximum = 32767;
            this.trackBar16.Minimum = -32767;
            this.trackBar16.Name = "trackBar16";
            this.trackBar16.Size = new System.Drawing.Size(240, 45);
            this.trackBar16.TabIndex = 30;
            this.trackBar16.TickFrequency = 0;
            // 
            // trackBar17
            // 
            this.trackBar17.Enabled = false;
            this.trackBar17.Location = new System.Drawing.Point(943, 328);
            this.trackBar17.Maximum = 32767;
            this.trackBar17.Minimum = -32767;
            this.trackBar17.Name = "trackBar17";
            this.trackBar17.Size = new System.Drawing.Size(240, 45);
            this.trackBar17.TabIndex = 29;
            this.trackBar17.TickFrequency = 0;
            // 
            // trackBar18
            // 
            this.trackBar18.Enabled = false;
            this.trackBar18.Location = new System.Drawing.Point(943, 294);
            this.trackBar18.Maximum = 32767;
            this.trackBar18.Minimum = -32767;
            this.trackBar18.Name = "trackBar18";
            this.trackBar18.Size = new System.Drawing.Size(240, 45);
            this.trackBar18.TabIndex = 28;
            this.trackBar18.TickFrequency = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "[19-20]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "[21-22] Gyro Yaw";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "[23-24] Gyro Pitch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "[29-30] motion Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "[27-28] motion X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "[25-26] Gyro Roll";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(502, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "[35-36]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(502, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "[33-34]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(502, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 12);
            this.label9.TabIndex = 37;
            this.label9.Text = "[31-32] motion Z";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(849, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "[41-42] Gyro Roll";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(849, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 41;
            this.label11.Text = "[39-40] Gyro Pitch";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(849, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 12);
            this.label12.TabIndex = 40;
            this.label12.Text = "[37-38] Gyro Yaw";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(849, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 12);
            this.label13.TabIndex = 45;
            this.label13.Text = "[47-48] motion Z";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(849, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 12);
            this.label14.TabIndex = 44;
            this.label14.Text = "[45-46] motion Y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(849, 179);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "[43-44] motion X";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(849, 294);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 46;
            this.label18.Text = "debug";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 823);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar16);
            this.Controls.Add(this.trackBar17);
            this.Controls.Add(this.trackBar18);
            this.Controls.Add(this.trackBar15);
            this.Controls.Add(this.trackBar14);
            this.Controls.Add(this.trackBar13);
            this.Controls.Add(this.trackBar12);
            this.Controls.Add(this.trackBar11);
            this.Controls.Add(this.trackBar10);
            this.Controls.Add(this.trackBar9);
            this.Controls.Add(this.trackBar8);
            this.Controls.Add(this.trackBar7);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PSVR Raw Input";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar18)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelByteOffset;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.TrackBar trackBar15;
        private System.Windows.Forms.TrackBar trackBar14;
        private System.Windows.Forms.TrackBar trackBar13;
        private System.Windows.Forms.TrackBar trackBar16;
        private System.Windows.Forms.TrackBar trackBar17;
        private System.Windows.Forms.TrackBar trackBar18;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
    }
}

