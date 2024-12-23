namespace WinFormsApp1
{
    partial class FrmCustomerManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerManagement));
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            button5 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            button6 = new Button();
            ımageList1 = new ImageList(components);
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox7
            // 
            textBox7.Location = new Point(575, 188);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 36;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(575, 151);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 35;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(79, 195);
            label4.Name = "label4";
            label4.Size = new Size(58, 16);
            label4.TabIndex = 32;
            label4.Text = "TELEFON";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(79, 165);
            label3.Name = "label3";
            label3.Size = new Size(39, 16);
            label3.TabIndex = 31;
            label3.Text = "KİŞİID";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(153, 192);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 28;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(153, 155);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 27;
            // 
            // button4
            // 
            button4.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(732, 93);
            button4.Name = "button4";
            button4.Size = new Size(142, 34);
            button4.TabIndex = 24;
            button4.Text = "MÜŞTERİ LİSTELE";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(525, 93);
            button3.Name = "button3";
            button3.Size = new Size(142, 34);
            button3.TabIndex = 23;
            button3.Text = "MÜŞTERİ GÜNCELLE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(318, 93);
            button2.Name = "button2";
            button2.Size = new Size(142, 34);
            button2.TabIndex = 22;
            button2.Text = "MÜŞTERİ SİL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(111, 93);
            button1.Name = "button1";
            button1.Size = new Size(142, 34);
            button1.TabIndex = 21;
            button1.Text = "MÜŞTERİ EKLE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(507, 195);
            label1.Name = "label1";
            label1.Size = new Size(58, 16);
            label1.TabIndex = 43;
            label1.Text = "TELEFON";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(507, 158);
            label5.Name = "label5";
            label5.Size = new Size(39, 16);
            label5.TabIndex = 42;
            label5.Text = "KİŞİID";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 369);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(996, 162);
            dataGridView1.TabIndex = 44;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // button5
            // 
            button5.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(801, 251);
            button5.Name = "button5";
            button5.Size = new Size(205, 23);
            button5.TabIndex = 45;
            button5.Text = "MÜŞTERİ YORUMLARINI LİSTELE";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Teal;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Enabled = false;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1018, 62);
            flowLayoutPanel1.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bodoni MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 57);
            label2.TabIndex = 6;
            label2.Text = "MERİES";
            // 
            // button6
            // 
            button6.BackColor = Color.PaleTurquoise;
            button6.ImageKey = "istockphoto-1455434949-612x612.jpg";
            button6.ImageList = ımageList1;
            button6.Location = new Point(10, 68);
            button6.Name = "button6";
            button6.Size = new Size(27, 24);
            button6.TabIndex = 69;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;
            ımageList1.ImageStream = (ImageListStreamer)resources.GetObject("ımageList1.ImageStream");
            ımageList1.TransparentColor = Color.Transparent;
            ımageList1.Images.SetKeyName(0, "istockphoto-1455434949-612x612.jpg");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(991, 65);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 70;
            label6.Text = "X";
            label6.Click += label6_Click;
            // 
            // FrmCustomerManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1018, 534);
            Controls.Add(button6);
            Controls.Add(label6);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button5);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCustomerManagement";
            Text = "FrmCustomerManagement";
            Load += FrmCustomerManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox7;
        private TextBox textBox6;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private Label label5;
        private DataGridView dataGridView1;
        private Button button5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Button button6;
        private ImageList ımageList1;
        private Label label6;
    }
}