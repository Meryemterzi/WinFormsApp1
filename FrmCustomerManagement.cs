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
    public partial class FrmCustomerManagement : Form
    {
        public FrmCustomerManagement()
        {
            InitializeComponent();
        }

        // PostgreSQL Bağlantısı için global conn nesnesi
        private NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=12345;Database=SirketDB");

        private void FrmCustomerManagement_Load(object sender, EventArgs e)
        {
            // DataGridView'de tüm satırı seçmek için ayarlar
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tüm satırı seç
            dataGridView1.MultiSelect = false; // Birden fazla satır seçilmesini engelle
        }
        // Veritabanı bağlantısını açan fonksiyon
        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        // Veritabanı bağlantısını kapatan fonksiyon
        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenConnection(); // Bağlantıyı aç

                // Müşteri ekleme sorgusu
                string sorgu = "INSERT INTO public.\"Müşteriler\" (\"KişiID\", \"Telefon\") VALUES (@kisid, @telefon)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    // Parametreler
                    cmd.Parameters.AddWithValue("@kisid", Convert.ToInt32(textBox2.Text)); // KişiID
                    cmd.Parameters.AddWithValue("@telefon", textBox3.Text); // Telefon

                    // Sorguyu çalıştır
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Müşteri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(); // Bağlantıyı kapat
            }
        }

        private int selectedRowIndex = -1;
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçilmişse
            {
                selectedRowIndex = e.RowIndex; // Satır index'ini güncelle
                MessageBox.Show($"Seçilen satır: {selectedRowIndex}"); // Seçilen satır index'i
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0) // Satır seçilmemişse
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenConnection(); // Bağlantıyı aç

                // Seçilen satırdaki MüşteriID değerini al
                int musteriID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                // Silme sorgusu
                string sorgu = "DELETE FROM public.\"Müşteriler\" WHERE \"MüşteriID\" = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@id", musteriID); // MüşteriID
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Müşteri başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(); // Bağlantıyı kapat
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz müşteriyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Lütfen geçerli bir telefon numarası girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenConnection(); // Bağlantıyı aç

                // Seçilen satırdaki MüşteriID değerini al
                int musteriID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                // Güncelleme sorgusu
                string sorgu = "UPDATE public.\"Müşteriler\" SET \"Telefon\" = @telefon WHERE \"MüşteriID\" = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@telefon", textBox7.Text); // Yeni telefon
                    cmd.Parameters.AddWithValue("@id", musteriID); // MüşteriID
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Müşteri başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                selectedRowIndex = -1; // Seçimi sıfırla
                dataGridView1.ClearSelection(); // DataGridView'deki seçimi kaldır
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(); // Bağlantıyı kapat
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection(); // Bağlantıyı aç

                // Müşterileri listeleme sorgusu
                string sorgu = "SELECT \"MüşteriID\", \"Telefon\", \"KişiID\" FROM public.\"Müşteriler\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // DataGridView'e bağla
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(); // Bağlantıyı kapat
            }
        }
        private void CheckLowRatingProducts()
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=SirketDB";

            // Puanı 1 olan yorumları kontrol eden sorgu
            string sorgu = @"
        SELECT ""YorumID"", ""ÜrünID"", ""YorumMetni"", ""Puan""
        FROM ""Yorumlar""
        WHERE ""Puan"" = 1;
    ";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string yorumId = reader["YorumID"].ToString();
                                string urunId = reader["ÜrünID"].ToString();
                                string yorumMetni = reader["YorumMetni"].ToString();

                                MessageBox.Show($"Ürün ID: {urunId} için düşük puanlı bir yorum bulundu:\n\nYorum ID: {yorumId}\nYorum: {yorumMetni}",
                                    "Düşük Puan Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCommentsAndCheckTrigger()
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=SirketDB";

            // Yorumları çekmek için SQL sorgusu
            string yorumlarSorgu = @"
        SELECT 
            ""YorumID"" AS ""Yorum ID"",
            ""ÜrünID"" AS ""Ürün ID"",
            ""MüşteriID"" AS ""Müşteri ID"",
            ""YorumMetni"" AS ""Yorum"",
            ""Puan"" AS ""Puan""
        FROM ""Yorumlar"";
    ";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Yorumları listele
                    using (NpgsqlCommand cmd = new NpgsqlCommand(yorumlarSorgu, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);
                            dataGridView1.DataSource = table;
                        }
                    }

                    // Puanı 1 olan yorumları kontrol et
                    CheckLowRatingProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LoadCommentsAndCheckTrigger();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 FORM1 = new Form1();
            FORM1.Show(); // Yeni formu açar
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close(); // Formu kapatırrr
        }
    }
}