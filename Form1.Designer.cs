namespace graphics_editor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_line = new System.Windows.Forms.Button();
            this.button_rect = new System.Windows.Forms.Button();
            this.button_ellipse = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.thickness_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thickness_trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fillColor_label = new System.Windows.Forms.Label();
            this.lineColor_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_wipe = new System.Windows.Forms.Button();
            this.button_select = new System.Windows.Forms.Button();
            this.button_group = new System.Windows.Forms.Button();
            this.button_ungroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thickness_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thickness_trackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(112, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(688, 451);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_line
            // 
            this.button_line.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_line.Location = new System.Drawing.Point(9, 36);
            this.button_line.Name = "button_line";
            this.button_line.Size = new System.Drawing.Size(88, 23);
            this.button_line.TabIndex = 2;
            this.button_line.Text = "Line";
            this.button_line.UseVisualStyleBackColor = true;
            this.button_line.Click += new System.EventHandler(this.button_line_Click);
            // 
            // button_rect
            // 
            this.button_rect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_rect.Location = new System.Drawing.Point(9, 65);
            this.button_rect.Name = "button_rect";
            this.button_rect.Size = new System.Drawing.Size(88, 23);
            this.button_rect.TabIndex = 3;
            this.button_rect.Text = "Rectangle";
            this.button_rect.UseVisualStyleBackColor = true;
            this.button_rect.Click += new System.EventHandler(this.button_rect_Click);
            // 
            // button_ellipse
            // 
            this.button_ellipse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ellipse.Location = new System.Drawing.Point(9, 94);
            this.button_ellipse.Name = "button_ellipse";
            this.button_ellipse.Size = new System.Drawing.Size(88, 23);
            this.button_ellipse.TabIndex = 4;
            this.button_ellipse.Text = "Ellipse";
            this.button_ellipse.UseVisualStyleBackColor = true;
            this.button_ellipse.Click += new System.EventHandler(this.button_ellipse_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.Color = System.Drawing.Color.White;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.thickness_numericUpDown);
            this.groupBox1.Controls.Add(this.thickness_trackBar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 99);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(3, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Цвет заливки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Цвет линии:";
            // 
            // thickness_numericUpDown
            // 
            this.thickness_numericUpDown.Location = new System.Drawing.Point(59, 14);
            this.thickness_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thickness_numericUpDown.Name = "thickness_numericUpDown";
            this.thickness_numericUpDown.Size = new System.Drawing.Size(43, 20);
            this.thickness_numericUpDown.TabIndex = 1;
            this.thickness_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thickness_numericUpDown.ValueChanged += new System.EventHandler(this.thickness_numericUpDown_ValueChanged);
            // 
            // thickness_trackBar
            // 
            this.thickness_trackBar.Location = new System.Drawing.Point(1, 32);
            this.thickness_trackBar.Minimum = 1;
            this.thickness_trackBar.Name = "thickness_trackBar";
            this.thickness_trackBar.Size = new System.Drawing.Size(104, 45);
            this.thickness_trackBar.TabIndex = 1;
            this.thickness_trackBar.TabStop = false;
            this.thickness_trackBar.Value = 1;
            this.thickness_trackBar.ValueChanged += new System.EventHandler(this.thickness_trackBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thickness:";
            // 
            // colorDialog2
            // 
            this.colorDialog2.AnyColor = true;
            this.colorDialog2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fillColor_label);
            this.groupBox4.Controls.Add(this.lineColor_label);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(3, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(106, 99);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // fillColor_label
            // 
            this.fillColor_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.fillColor_label.Location = new System.Drawing.Point(3, 73);
            this.fillColor_label.Name = "fillColor_label";
            this.fillColor_label.Size = new System.Drawing.Size(99, 20);
            this.fillColor_label.TabIndex = 1;
            this.fillColor_label.Click += new System.EventHandler(this.fillColor_label_Click);
            // 
            // lineColor_label
            // 
            this.lineColor_label.BackColor = System.Drawing.Color.Black;
            this.lineColor_label.Location = new System.Drawing.Point(3, 35);
            this.lineColor_label.Name = "lineColor_label";
            this.lineColor_label.Size = new System.Drawing.Size(99, 20);
            this.lineColor_label.TabIndex = 1;
            this.lineColor_label.Click += new System.EventHandler(this.lineColor_label_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Fill color:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Line color:";
            // 
            // button_wipe
            // 
            this.button_wipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_wipe.Location = new System.Drawing.Point(12, 416);
            this.button_wipe.Name = "button_wipe";
            this.button_wipe.Size = new System.Drawing.Size(88, 23);
            this.button_wipe.TabIndex = 8;
            this.button_wipe.Text = "Wipe";
            this.button_wipe.UseVisualStyleBackColor = true;
            this.button_wipe.Click += new System.EventHandler(this.button_wipe_Click);
            // 
            // button_select
            // 
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Location = new System.Drawing.Point(9, 7);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(88, 23);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Selection";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_line_Click);
            // 
            // button_group
            // 
            this.button_group.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_group.Location = new System.Drawing.Point(3, 311);
            this.button_group.Name = "button_group";
            this.button_group.Size = new System.Drawing.Size(45, 23);
            this.button_group.TabIndex = 6;
            this.button_group.Text = "Group";
            this.button_group.UseVisualStyleBackColor = true;
            this.button_group.Click += new System.EventHandler(this.button_ellipse_Click);
            // 
            // button_ungroup
            // 
            this.button_ungroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ungroup.Location = new System.Drawing.Point(50, 311);
            this.button_ungroup.Name = "button_ungroup";
            this.button_ungroup.Size = new System.Drawing.Size(56, 23);
            this.button_ungroup.TabIndex = 7;
            this.button_ungroup.Text = "Ungroup";
            this.button_ungroup.UseVisualStyleBackColor = true;
            this.button_ungroup.Click += new System.EventHandler(this.button_ellipse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_wipe);
            this.Controls.Add(this.button_ungroup);
            this.Controls.Add(this.button_group);
            this.Controls.Add(this.button_ellipse);
            this.Controls.Add(this.button_rect);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.button_line);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thickness_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thickness_trackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_line;
        private System.Windows.Forms.Button button_rect;
        private System.Windows.Forms.Button button_ellipse;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown thickness_numericUpDown;
        private System.Windows.Forms.TrackBar thickness_trackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label fillColor_label;
        private System.Windows.Forms.Label lineColor_label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_wipe;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_group;
        private System.Windows.Forms.Button button_ungroup;
    }
}

