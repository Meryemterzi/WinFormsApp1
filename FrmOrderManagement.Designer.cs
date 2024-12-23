namespace WinFormsApp1
{
    partial class FrmOrderManagement
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrderManagement));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            button5 = new Button();
            label8 = new Label();
            textBox8 = new TextBox();
            button6 = new Button();
            button7 = new Button();
            label9 = new Label();
            textBox9 = new TextBox();
            button8 = new Button();
            label10 = new Label();
            textBox10 = new TextBox();
            panel1 = new Panel();
            label11 = new Label();
            button9 = new Button();
            ımageList1 = new ImageList(components);
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(78, 80);
            button1.Name = "button1";
            button1.Size = new Size(135, 30);
            button1.TabIndex = 0;
            button1.Text = "SİPARİŞ EKLE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(250, 80);
            button2.Name = "button2";
            button2.Size = new Size(135, 30);
            button2.TabIndex = 1;
            button2.Text = "SİPARİŞ SİL ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(422, 80);
            button3.Name = "button3";
            button3.Size = new Size(135, 30);
            button3.TabIndex = 2;
            button3.Text = "SİPARİŞ GÜNCELLE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(594, 80);
            button4.Name = "button4";
            button4.Size = new Size(135, 30);
            button4.TabIndex = 3;
            button4.Text = "SİPARİŞ LİSTELE";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 369);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(996, 162);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(42, 140);
            label1.Name = "label1";
            label1.Size = new Size(63, 14);
            label1.TabIndex = 5;
            label1.Text = "MÜŞTERİID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(56, 174);
            label2.Name = "label2";
            label2.Size = new Size(40, 14);
            label2.TabIndex = 6;
            label2.Text = "TARİH";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(49, 206);
            label3.Name = "label3";
            label3.Size = new Size(47, 14);
            label3.TabIndex = 7;
            label3.Text = "DURUM";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(399, 144);
            label4.Name = "label4";
            label4.Size = new Size(40, 14);
            label4.TabIndex = 8;
            label4.Text = "TARİH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(387, 202);
            label5.Name = "label5";
            label5.Size = new Size(47, 14);
            label5.TabIndex = 9;
            label5.Text = "DURUM";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(113, 165);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(113, 197);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(445, 135);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(447, 195);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(10, 235);
            label6.Name = "label6";
            label6.Size = new Size(91, 14);
            label6.TabIndex = 15;
            label6.Text = "TOPLAM TURAR";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(113, 226);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(348, 174);
            label7.Name = "label7";
            label7.Size = new Size(91, 14);
            label7.TabIndex = 17;
            label7.Text = "TOPLAM TUTAR";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(445, 165);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 18;
            // 
            // button5
            // 
            button5.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(766, 80);
            button5.Name = "button5";
            button5.Size = new Size(135, 30);
            button5.TabIndex = 19;
            button5.Text = "İADE OLUŞTUR";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(729, 130);
            label8.Name = "label8";
            label8.Size = new Size(55, 14);
            label8.TabIndex = 20;
            label8.Text = "SİPARİŞID";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(803, 127);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 23;
            // 
            // button6
            // 
            button6.Font = new Font("Sylfaen", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(12, 336);
            button6.Name = "button6";
            button6.Size = new Size(120, 23);
            button6.TabIndex = 24;
            button6.Text = "İSTATİSTİKLER";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(599, 275);
            button7.Name = "button7";
            button7.Size = new Size(195, 23);
            button7.TabIndex = 25;
            button7.Text = "SİPARİŞE GÖRE TOPLAM TUTAR";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(811, 321);
            label9.Name = "label9";
            label9.Size = new Size(55, 14);
            label9.TabIndex = 26;
            label9.Text = "SİPARİŞID";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(872, 314);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 23);
            textBox9.TabIndex = 27;
            // 
            // button8
            // 
            button8.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button8.Location = new Point(811, 275);
            button8.Name = "button8";
            button8.Size = new Size(195, 23);
            button8.TabIndex = 28;
            button8.Text = "SİPARİŞ DETAYLARINI LİSTELE";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sylfaen", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(599, 318);
            label10.Name = "label10";
            label10.Size = new Size(55, 14);
            label10.TabIndex = 29;
            label10.Text = "SİPARİŞID";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(660, 314);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(100, 23);
            textBox10.TabIndex = 30;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(label11);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 62);
            panel1.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Bodoni MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ControlLight;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(137, 57);
            label11.TabIndex = 7;
            label11.Text = "MERİES";
            // 
            // button9
            // 
            button9.BackColor = Color.PaleTurquoise;
            button9.ImageKey = "istockphoto-1455434949-612x612.jpg";
            button9.ImageList = ımageList1;
            button9.Location = new Point(10, 68);
            button9.Name = "button9";
            button9.Size = new Size(27, 24);
            button9.TabIndex = 69;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;
            ımageList1.ImageStream = (ImageListStreamer)resources.GetObject("ımageList1.ImageStream");
            ımageList1.TransparentColor = Color.Transparent;
            ımageList1.Images.SetKeyName(0, "istockphoto-1455434949-612x612.jpg");
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(991, 65);
            label12.Name = "label12";
            label12.Size = new Size(15, 15);
            label12.TabIndex = 71;
            label12.Text = "X";
            label12.Click += label12_Click;
            // 
            // FrmOrderManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1018, 547);
            Controls.Add(label12);
            Controls.Add(button9);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(panel1);
            Controls.Add(textBox10);
            Controls.Add(label10);
            Controls.Add(button8);
            Controls.Add(textBox9);
            Controls.Add(label9);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(button5);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmOrderManagement";
            Text = "FrmOrderManagement";
            Load += FrmOrderManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
        private Button button5;
        private Label label8;
        private TextBox textBox8;
        private Button button6;
        private Button button7;
        private Label label9;
        private TextBox textBox9;
        private Button button8;
        private Label label10;
        private TextBox textBox10;
        private Panel panel1;
        private Label label11;
        private Button button9;
        private ImageList ımageList1;
        private Label label12;
    }
}