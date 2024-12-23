using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmReturnManagement : Form
    {
        public FrmReturnManagement()
        {
            InitializeComponent();
        }

        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SirketDB; user Id=postgres;password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı aç
                conn.Open();

                // TextBox'ların boş olup olmadığını kontrol et
                if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox4.Text == String.Empty)
                {
                    MessageBox.Show("Lütfen tüm kutuları doldurun!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    // SQL INSERT sorgusu hazırlığı (Kişi tablosu için)
                    string addPersonQuery = "INSERT INTO \"Kişi\" (\"Ad\", \"Soyad\", \"Email\") VALUES (@Ad, @Soyad, @Email) RETURNING \"KişiID\";";
                    int personId;

                    using (var personCmd = new NpgsqlCommand(addPersonQuery, conn))
                    {
                        personCmd.Parameters.AddWithValue("@Ad", textBox1.Text);
                        personCmd.Parameters.AddWithValue("@Soyad", textBox2.Text);
                        personCmd.Parameters.AddWithValue("@Email", textBox3.Text);

                        // KişiID'yi al
                        personId = (int)personCmd.ExecuteScalar();
                    }

                    // SQL INSERT sorgusu hazırlığı (Çalışanlar tablosu için)
                    string addEmployeeQuery = "INSERT INTO \"Çalışanlar\" (\"KişiID\", \"Pozisyon\") VALUES (@KişiID, @Pozisyon);";

                    using (var employeeCmd = new NpgsqlCommand(addEmployeeQuery, conn))
                    {
                        employeeCmd.Parameters.AddWithValue("@KişiID", personId);
                        employeeCmd.Parameters.AddWithValue("@Pozisyon", textBox4.Text);

                        // Sorguyu çalıştır
                        employeeCmd.ExecuteNonQuery();
                    }

                    // Başarı mesajı
                    MessageBox.Show("Çalışan başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı göster
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Bağlantının açık olup olmadığını kontrol et
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Seçilen satırdaki ÇalışanID'yi al
                    int selectedEmployeeId;
                    try
                    {
                        selectedEmployeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ÇalışanID"].Value);
                        MessageBox.Show($"Silinecek ÇalışanID: {selectedEmployeeId}");
                    }
                    catch
                    {
                        MessageBox.Show("Seçilen satırdan ÇalışanID alınamadı. Lütfen doğru bir satır seçtiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Silme sorgusu
                    string sorgu = "DELETE FROM public.\"Çalışanlar\" WHERE \"ÇalışanID\" = @p1;";
                    using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                    {
                        command.Parameters.AddWithValue("@p1", selectedEmployeeId);
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Çalışan başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        else
                        {
                            MessageBox.Show("Çalışan silinemedi! ID bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajını göster
                    MessageBox.Show($"Hata: {ex.Message}\n\n{ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Bağlantıyı kapat
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int selectedRowIndex = -1; // Başlangıçta geçersiz değer

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçilmişse
            {
                selectedRowIndex = e.RowIndex; // Satır index'ini güncelle
                MessageBox.Show($"Seçilen satır: {selectedRowIndex}"); // Seçilen satır index'i
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Satır seçilip seçilmediğini kontrol et
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Bağlantıyı kontrol et ve aç
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Seçilen satırdaki ÇalışanID değerini al
                int selectedEmployeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ÇalışanID"].Value);

                // Güncelleme sorgusu (Kişi tablosu için)
                string updatePersonQuery = "UPDATE public.\"Kişi\" SET " +
                                           "\"Ad\" = @Ad, " +
                                           "\"Soyad\" = @Soyad, " +
                                           "\"Email\" = @Email " +
                                           "WHERE \"KişiID\" = (SELECT \"KişiID\" FROM public.\"Çalışanlar\" WHERE \"ÇalışanID\" = @ÇalışanID);";

                using (NpgsqlCommand personCmd = new NpgsqlCommand(updatePersonQuery, conn))
                {
                    // Parametreleri ekle
                    personCmd.Parameters.AddWithValue("@Ad", textBox5.Text); // Ad
                    personCmd.Parameters.AddWithValue("@Soyad", textBox6.Text); // Soyad
                    personCmd.Parameters.AddWithValue("@Email", textBox7.Text); // Email
                    personCmd.Parameters.AddWithValue("@ÇalışanID", selectedEmployeeId); // ÇalışanID

                    // Sorguyu çalıştır
                    personCmd.ExecuteNonQuery();
                }

                // Güncelleme sorgusu (Çalışanlar tablosu için)
                string updateEmployeeQuery = "UPDATE public.\"Çalışanlar\" SET " +
                                             "\"Pozisyon\" = @Pozisyon " +
                                             "WHERE \"ÇalışanID\" = @ÇalışanID;";

                using (NpgsqlCommand employeeCmd = new NpgsqlCommand(updateEmployeeQuery, conn))
                {
                    // Parametreleri ekle
                    employeeCmd.Parameters.AddWithValue("@Pozisyon", textBox8.Text); // Pozisyon
                    employeeCmd.Parameters.AddWithValue("@ÇalışanID", selectedEmployeeId); // ÇalışanID

                    // Sorguyu çalıştır
                    employeeCmd.ExecuteNonQuery();
                }

                // Güncelleme başarı mesajı
                MessageBox.Show("Çalışan başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı aç
                conn.Open();
                MessageBox.Show("Bağlantı başarılı!"); // Bağlantı kontrolü

                // Çalışanları listeleyen sorgu
                string sorgu = "SELECT " +
                               "\"Çalışanlar\".\"ÇalışanID\", " +
                               "\"Kişi\".\"Ad\" AS \"Ad\", " +
                               "\"Kişi\".\"Soyad\" AS \"Soyad\", " +
                               "\"Kişi\".\"Email\" AS \"Email\", " +
                               "\"Çalışanlar\".\"Pozisyon\" AS \"Pozisyon\" " +
                               "FROM \"Çalışanlar\" " +
                               "JOIN \"Kişi\" ON \"Çalışanlar\".\"KişiID\" = \"Kişi\".\"KişiID\" " +
                               "ORDER BY \"ÇalışanID\" ASC;";

                // Veriyi doldurmak için DataAdapter ve DataSet kullanıyoruz
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sorgu, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0) // Veri kontrolü
                {
                    MessageBox.Show($"{ds.Tables[0].Rows.Count} kayıt bulundu."); // Satır sayısını göster
                    dataGridView1.AutoGenerateColumns = true; // Sütunları otomatik oluştur
                    dataGridView1.DataSource = ds.Tables[0]; // Veri kaynağını bağla
                }
                else
                {
                    MessageBox.Show("Hiç kayıt bulunamadı."); // Boş tablo durumu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}"); // Hata mesajı
            }
            finally
            {
                conn.Close(); // Bağlantıyı kapat
            }
        }
        private void FrmReturnManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false; // Birden fazla satır seçilmesini engellemek için
        }

  

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 FORM1 = new Form1();
            FORM1.Show(); // Yeni formu açar
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close(); // Formu kapatır
        }
    }
}
