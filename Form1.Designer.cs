using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kaynakları temizleme.
        /// </summary>
        /// <param name="disposing">Managed kaynakları temizle.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer tarafından oluşturulan kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(707, 225);
            button1.Name = "button1";
            button1.Size = new Size(161, 63);
            button1.TabIndex = 0;
            button1.Text = "ÜRÜN YÖNETİMİ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(521, 225);
            button2.Name = "button2";
            button2.Size = new Size(161, 63);
            button2.TabIndex = 1;
            button2.Text = "MÜŞTERİ YÖNETİMİ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(331, 225);
            button3.Name = "button3";
            button3.Size = new Size(161, 63);
            button3.TabIndex = 2;
            button3.Text = "SİPARİŞ YÖNETİMİ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(139, 225);
            button4.Name = "button4";
            button4.Size = new Size(161, 63);
            button4.TabIndex = 3;
            button4.Text = "ÇALIŞAN YÖNETİMİ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 100);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bodoni MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(3, 43);
            label2.Name = "label2";
            label2.Size = new Size(137, 57);
            label2.TabIndex = 8;
            label2.Text = "MERİES";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bodoni MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(878, 43);
            label1.Name = "label1";
            label1.Size = new Size(137, 57);
            label1.TabIndex = 5;
            label1.Text = "MERİES";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(33, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Teal;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 447);
            panel2.Name = "panel2";
            panel2.Size = new Size(1018, 100);
            panel2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bodoni MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(881, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 57);
            label4.TabIndex = 10;
            label4.Text = "MERİES";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bodoni MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(137, 57);
            label3.TabIndex = 9;
            label3.Text = "MERİES";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Teal;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(133, 347);
            panel3.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Teal;
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(885, 100);
            panel4.Name = "panel4";
            panel4.Size = new Size(133, 347);
            panel4.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(864, 103);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 71;
            label6.Text = "X";
            label6.Click += label6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1018, 547);
            Controls.Add(label6);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Ana Form";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label6;
    }
}
